using Microsoft.AspNetCore.Mvc;
using Store.Data.Interfaces;
using Store.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Controllers
{
    public class BandController : Controller
    {
        private readonly IBandRepository _bandRepository;

        public BandController(IBandRepository bandRepository)
        {
            _bandRepository = bandRepository;
        }

        [Route("Band")]
        public IActionResult List()
        {
            var bands = _bandRepository.GetAllWithAlbums();

            if(bands.Count() == 0)
                return View("Empty");

            return View(bands);
        }

        public IActionResult Update(int id)
        {
            var band = _bandRepository.GetById(id);

            if (band == null)
                return NotFound();

            return View(band);
        }

        [HttpPost]
        public IActionResult Update(Band band)
        {
            if (!ModelState.IsValid)
                return View(band);

            _bandRepository.Update(band);
            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            var band = _bandRepository.GetById(id);

            _bandRepository.Delete(band);

            return RedirectToAction("List");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Band band)
        {
            _bandRepository.Create(band);

            return RedirectToAction("List");
        }
    }
}
