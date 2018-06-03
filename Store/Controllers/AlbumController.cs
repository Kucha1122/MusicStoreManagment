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
    public class AlbumController : Controller
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly IBandRepository _bandRepository;

        public AlbumController(IAlbumRepository albumRepository, IBandRepository bandRepository)
        {
            _albumRepository = albumRepository;
            _bandRepository = bandRepository;
        }

        [Route("Album")]
        public IActionResult List(int? bandId, int? borrowerId)
        {
            if(bandId == null && borrowerId == null)
            {
                //all albums
                var albums = _albumRepository.GetAllWithBand();

                return CheckAlbums(albums);
            }
            else if(bandId != null)
            {
                //filter by bandID
                var band = _bandRepository.GetWithAlbums((int)bandId);

                if(band.Albums.Count() == 0)
                {
                    return View("BandEmpty", band);
                }
                else
                {
                    return View(band.Albums);
                }
            }
            else if(borrowerId != null)
            {
                //filter by borrowerId
                var albums = _albumRepository.FindWithBandAndBorrower(album => album.BorrowerId == borrowerId);

                return CheckAlbums(albums);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public IActionResult CheckAlbums(IEnumerable<Album> albums)
        {
            if(albums.Count() == 0)
            {
                return View("Empty");
            }
            else
            {
                return View(albums);
            }
        }

        public IActionResult Create()
        {
            var albumVM = new AlbumViewModel()
            {
                Bands = _bandRepository.GetAll()
            };

            return View(albumVM);
        }

        [HttpPost]
        public IActionResult Create(AlbumViewModel albumViewModel)
        {
            if (!ModelState.IsValid)
            {
                albumViewModel.Bands = _bandRepository.GetAll();

                return View(albumViewModel);
            }

            _albumRepository.Create(albumViewModel.Album);

            return RedirectToAction("List");
        }

        public IActionResult Update(int id)
        {
            var albumVM = new AlbumViewModel()
            {
                Album = _albumRepository.GetById(id),
                Bands = _bandRepository.GetAll()
            };

            return View(albumVM);
        }

        [HttpPost]
        public IActionResult Update(AlbumViewModel albumViewModel)
        {
            if (!ModelState.IsValid)
            {
                albumViewModel.Bands = _bandRepository.GetAll();
                return View(albumViewModel);
            }

            _albumRepository.Update(albumViewModel.Album);

            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            var album = _albumRepository.GetById(id);

            _albumRepository.Delete(album);

            return RedirectToAction("List");
        }
    }
}