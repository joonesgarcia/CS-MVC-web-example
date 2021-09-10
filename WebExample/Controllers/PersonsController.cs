﻿using Microsoft.AspNetCore.Mvc;
using WebExample.Services;
using WebExample.Models;

namespace WebExample.Controllers
{
    public class PersonsController : Controller
    {
        private readonly PersonService _personService; //dependency with PersonService

        public PersonsController(PersonService personService) => _personService = personService;

        public IActionResult Index() //uses a service to get persons List<> and passes it to index view
        {
            return View(_personService.FindAll());
        }
        public IActionResult Insert() //redirects to insert view
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Insert(Person p) // uses service to insert to db and redirects to index view
        {
            _personService.Insert(p);
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Delete(int? id) // confirms id selected is not null and redirects to confirm delete view
        {
            if (id == null) return NotFound();

            var p = _personService.FindById(id.Value);

            if (p == null) return NotFound();

            return View(p);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Delete(int id) // uses service to delete a person by id from db and redirects to index view
        {
            _personService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}