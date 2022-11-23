using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using TestWeb.Models;
using TestWeb.Repositories;
using TestWeb.ViewModels;

namespace TestWeb.Controllers
{
    public class Container<T>
    {
        public T item { get; set; }
        public int count { get; set; }
    }

    public class HomeController : Controller
    {
        private readonly IRepository<Localization> _LocalizationRepository;
        private readonly IRepository<Symptom> _SymptomRepository;
        private readonly IRepository<Client> _ClientRepository;
        private readonly IRepository<Gender> _GenderRepository;
        private readonly IRepository<DiseaseBySymptom> _DiseaseBySymptomRepository;
        private readonly IRepository<Disease> _Disease;

        public HomeController(IRepository<Localization> localizationRepository, IRepository<Symptom> symptomRepository, IRepository<Client> clientRepository, IRepository<Gender> genderRepository, IRepository<DiseaseBySymptom> diseaseBySymptomRepository, IRepository<Disease> disease)
        {
            _LocalizationRepository = localizationRepository;
            _SymptomRepository = symptomRepository;
            _ClientRepository = clientRepository;
            _GenderRepository = genderRepository;
            _DiseaseBySymptomRepository = diseaseBySymptomRepository;
            _Disease = disease;
        }

        public ViewResult Index()
        {
            var obj = new ClientGenderViewModel() { AllGenders = _GenderRepository.GetAll() };

            return View(obj);
        }

        [HttpPost]
        public ActionResult Index(ClientGenderViewModel clientGender)
        {
            if (ModelState.IsValid)
            {
                var client = new Client() { Name = clientGender.Name, Age = clientGender.Age, GenderId = clientGender.GenderId, ClientGender = _GenderRepository.GetAll().FirstOrDefault(x => x.GenderId == clientGender.GenderId) };

                _ClientRepository.Create(client);
                return RedirectToAction(nameof(List));
            }

            return View(clientGender);
        }

        public ViewResult List()
        {
            var obj = new LocalizationListViewModel();
            obj.AllLocalizations = _LocalizationRepository.GetAll();
            obj.AllSymptoms = _SymptomRepository.GetAll();

            return View(obj);
        }

        [HttpPost]
        public ActionResult List([FromBody] dynamic requestData)
        {
            string str = System.Text.Json.JsonSerializer.Serialize(requestData);

            JToken jArray = JToken.Parse(str);

            List<string> listSymptoms = jArray.ToObject<List<string>>();

            var client = _ClientRepository.GetAll().LastOrDefault();

            var symptoms = new List<Symptom>();

            foreach (var item in listSymptoms)
            {
                symptoms.Add(_SymptomRepository.Get(Convert.ToInt32(item)));
            }

            return View();
        }

        public ViewResult Diagnostic()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Diagnostic([FromBody] dynamic requestData)
        {
            string str = System.Text.Json.JsonSerializer.Serialize(requestData);

            JToken jArray = JToken.Parse(str);

            List<string> listSymptoms = jArray.ToObject<List<string>>();

            var client = _ClientRepository.GetAll().LastOrDefault();

            client.ClientGender = _GenderRepository.GetAll().FirstOrDefault(x => x.GenderId == client.GenderId);

            var symptoms = new List<Symptom>();

            foreach (var item in listSymptoms)
            {
                if (item is not null)
                    symptoms.Add(_SymptomRepository.Get(Convert.ToInt32(item)));
            }

            var diseases = new List<Disease>();

            foreach (var item in symptoms)
            {
                var list = _DiseaseBySymptomRepository.GetAll().Where(x => x.SymptomId == item.SymptomId);

                if (list is not null)
                {

                    foreach (var item2 in list)
                    {
                        diseases.Add(_Disease.Get(item2.DiseaseId));
                    }
                }
            }

            var resultDiseases = new List<Container<Disease>>();

            foreach (var item in diseases)
            {
                int count = diseases.Select(x => x.DiseaseId == item.DiseaseId).Count();

                if (resultDiseases.Count == 0)
                {
                    resultDiseases.Add(new Container<Disease> { item = item, count = count });

                }

                if (resultDiseases.FirstOrDefault(x => x.item == item) == null)
                {
                    resultDiseases.Add(new Container<Disease> { item = item, count = count });
                }
            }

            var temp = new List<Container<Disease>>();
            foreach (var item in resultDiseases)
            {
                temp.Add(item);
            }

            foreach (var item in temp)
            {
                if (!(item.item.DiseaseGender == client.ClientGender && item.item.Lower_age_limit <= client.Age && client.Age <= item.item.Upper_age_limit))
                {
                    resultDiseases.Remove(item);
                }
            }

            if (resultDiseases is null || resultDiseases.Count == 0)
            {
                var viewModel1 = new DiagnosticViewModel { Name = client.Name, Age = client.Age, Symptoms = symptoms.ToArray(), Disease = "По вашим симптомам ничего не найдено", Gender = client.ClientGender.Name };

                return Json(viewModel1);
            }

            int maxCount = resultDiseases.Select(x => x.count).ToArray().Max();

            var items = resultDiseases.Where(x => x.count == maxCount);

            string result = "Наиболее вероятные заболевания: ";

            var temp2 = new List<Container<Disease>>();
            foreach (var item in items)
            {
                temp2.Add(item);
            }
            foreach (var item in temp2)
            {
                if (temp2.Last() == item)
                    result += item.item.Name;

                else
                    result += item.item.Name + ", ";

                resultDiseases.Remove(item);
            }

            if (resultDiseases.Count == 0)
            {
                var viewModel2 = new DiagnosticViewModel { Name = client.Name, Age = client.Age, Symptoms = symptoms.ToArray(), Disease = result, Gender = client.ClientGender.Name };

                return Json(viewModel2);
            }

            result += Environment.NewLine + ", Наименее вероятные заболевания: ";

            foreach (var item in resultDiseases)
            {
                result += item.item.Name + ", ";
            }

            var viewModel = new DiagnosticViewModel { Name = client.Name, Age = client.Age, Symptoms = symptoms.ToArray(), Disease = result, Gender = client.ClientGender.Name };

            return Json(viewModel);
        }



        public IActionResult GetSymptom(Symptom symptom)
        {
            if (ModelState.IsValid)
            {
                _SymptomRepository.Create(symptom);
                //TempData["Success"] = "Запись успешно добавлена";
                return RedirectToAction(nameof(Index));
            }
            return View(symptom);
        }

    }
}
