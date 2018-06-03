using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.Data.Interfaces;
using Store.Data.Model;
using Store.Models.ViewModel;

namespace Store.Controllers
{
    public class LendController : Controller
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly ICustomerRepository _customerRepository;

        public LendController(IAlbumRepository albumRepository, ICustomerRepository customerRepository)
        {
            _albumRepository = albumRepository;
            _customerRepository = customerRepository;
        }

        [Route("Lend")]
        public IActionResult List()
        {
            //dostepne plyty
            var availableAlbums = _albumRepository.FindWithBand(x => x.BorrowerId == 0);

            if(availableAlbums.Count() == 0)
            {
                return View("Empty");
            }
            else
            {
                return View(availableAlbums);
            }
        }

        public IActionResult LendAlbum(int albumId)
        {
            var lendVM = new LendViewModel()
            {
                Album = _albumRepository.GetById(albumId),
                Customers = _customerRepository.GetAll()
            };

            return View(lendVM);
        }

       [HttpPost]
       public IActionResult LendAlbum(LendViewModel lendViewModel)
       {
            var album = _albumRepository.GetById(lendViewModel.Album.AlbumId);
            var customer = _customerRepository.GetById(lendViewModel.Album.BorrowerId);

            album.Borrower = customer;
           _albumRepository.Update(album);

            return RedirectToAction("List");
       }   
    }
}