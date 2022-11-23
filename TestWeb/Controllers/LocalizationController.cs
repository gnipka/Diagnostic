using Microsoft.AspNetCore.Mvc;
using System;
using TestWeb.Models;
using TestWeb.Repositories;

namespace TestWeb.Controllers
{
    public class LocalizationController : Controller
    {
        private readonly IRepository<Localization> _LocalizationRepository;

        public LocalizationController(IRepository<Localization> localizationRepository)
        {
            _LocalizationRepository = localizationRepository;
        }


        public ViewResult GetLocalization()
        {
            return View(_LocalizationRepository.GetAll());
        }

        public IActionResult GetSymptom(Localization localization)
        {
            if (ModelState.IsValid)
            {
                _LocalizationRepository.Create(localization);
                //TempData["Success"] = "Запись успешно добавлена";
                return RedirectToAction(nameof(Index));
            }
            return View(localization);
        }
    }
}
