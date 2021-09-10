﻿using Microsoft.AspNetCore.Mvc;
using WebExample.Models;
using WebExample.Services;

namespace WebExample.Controllers
{
    public class SegmentsController : Controller
    {

        private readonly SegmentService _segmentService; //dependency with SegmentService

        public SegmentsController(SegmentService segmentService) => _segmentService = segmentService;
        
        public IActionResult Index() //uses a service to get persons List<> and redirects it to index view
        {
            return View(_segmentService.FindAll());
        }
        public IActionResult Insert() /// redirects to insert view
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Insert(Segment s) // uses a service to insert a segment to db and redirects to index view
        {
            _segmentService.Insert(s);
            return RedirectToAction(nameof(Index));           
        }

        public IActionResult Delete(int? id) // redirects to delete view
        {
            if (id == null) return NotFound();

            var p = _segmentService.FindById(id.Value);

            if (p == null) return NotFound();

            return View(p);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Delete(Segment s) // uses a service to insert a segment to db and redirects to index view
        {
            _segmentService.Delete(s);
            return RedirectToAction(nameof(Index));
        }

    }
}