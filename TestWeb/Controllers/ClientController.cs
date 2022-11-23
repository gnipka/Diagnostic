using Microsoft.AspNetCore.Mvc;
using System;
using TestWeb.Models;
using TestWeb.Repositories;

namespace TestWeb.Controllers
{
    public class ClientController : Controller
    {
        private readonly IRepository<Client> _ClientRepository;

        public ClientController(IRepository<Client> clientRepository)
        {
            _ClientRepository = clientRepository;
        }

        [ValidateAntiForgeryToken]
        public IActionResult Create(Client client)
        {
            if (ModelState.IsValid)
            {
                _ClientRepository.Create(client);
                TempData["Success"] = "Запись успешно добавлена";
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }
    }
}
