using Microsoft.AspNetCore.Mvc;
using System;
using TestWeb.Models;
using TestWeb.Repositories;
using TestWeb.ViewModels;

namespace TestWeb.Controllers
{
    public class SymptomController : Controller
    {
        private readonly IRepository<Localization> _LocalizationRepository;
        private readonly IRepository<Symptom> _SymptomRepository;

        public SymptomController(IRepository<Localization> localizationRepository, IRepository<Symptom> symptomRepository)
        {
            _LocalizationRepository = localizationRepository;
            _SymptomRepository = symptomRepository;
        }

        public ViewResult List()
        {
            ViewBag.Title = "Симптомы";

            var obj = new LocalizationListViewModel();
            obj.AllLocalizations = _LocalizationRepository.GetAll();
            obj.AllSymptoms = _SymptomRepository.GetAll();

            return View(obj);
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
