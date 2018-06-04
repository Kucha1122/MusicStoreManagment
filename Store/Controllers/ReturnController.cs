using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.Data.Interfaces;

namespace Store.Controllers
{
    public class ReturnController : Controller
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly ICustomerRepository _customerRepository;

        public ReturnController(IAlbumRepository albumRepository, ICustomerRepository customerRepository)
        {
            _albumRepository = albumRepository;
            _customerRepository = customerRepository;
        }

        [Route("Return")]
        public IActionResult List()
        {
            var borrowedAlbums = _albumRepository.FindWithBandAndBorrower(x => x.BorrowerId != 0);

            if (borrowedAlbums == null || borrowedAlbums.ToList().Count() == 0)
                return View("Empty");

            return View(borrowedAlbums);
        }

        public IActionResult ReturnAnAlbum(int albumId)
        {
            var album = _albumRepository.GetById(albumId);

            album.Borrower = null;
            album.BorrowerId = 0;

            _albumRepository.Update(album);

            return RedirectToAction("List");
        }

    }
}