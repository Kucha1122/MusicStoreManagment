using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.Data.Interfaces;
using Store.Models;
using Store.Models.ViewModel;

namespace Store.Controllers
{
    public class HomeController : Controller
    {

        private readonly IAlbumRepository _albumRepository;
        private readonly IBandRepository _bandRepository;
        private readonly ICustomerRepository _customerRepository;

        public HomeController(IAlbumRepository albumRepository, IBandRepository bandRepository, ICustomerRepository customerRepository)
        {
            _albumRepository = albumRepository;
            _bandRepository = bandRepository;
            _customerRepository = customerRepository;
        }

        public IActionResult Index()
        {
            var homeVM = new HomeViewModel()
            {
                BandCount = _bandRepository.Count(x => true),
                CustomerCount = _customerRepository.Count(x => true),
                AlbumCount = _albumRepository.Count(x => true),
                LendAlbumCount = _albumRepository.Count(x => x.Borrower != null)
            };

            return View(homeVM);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Autor";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
