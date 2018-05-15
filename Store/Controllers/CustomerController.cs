using Microsoft.AspNetCore.Mvc;
using Store.Data.Interfaces;
using Store.Data.Model;
using Store.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IAlbumRepository _albumRepository;

        public CustomerController(ICustomerRepository customerRepository, IAlbumRepository albumRepository)
        {
            _customerRepository = customerRepository;
            _albumRepository = albumRepository;
        }

        public IActionResult List()
        {
            var customerVM = new List<CustomerViewModel>();

            var customers = _customerRepository.GetAll();

            if(customers.Count() == 0)
            {
                return View("Empty");
            }

            foreach (var customer in customers)
            {
                customerVM.Add(new CustomerViewModel
                {
                    Customer = customer,
                    AlbumCount = _albumRepository.Count(x => x.BorrowerId == customer.CustomerId)
                });
            }

            return View(customerVM);
        }

        public IActionResult Delete(int id)
        {
            var customer = _customerRepository.GetById(id);

            _customerRepository.Delete(customer);

            return RedirectToAction("List");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            _customerRepository.Create(customer);

            return RedirectToAction("List");
        }

        public IActionResult Update(int id)
        {
            var customer = _customerRepository.GetById(id);
            return View(customer);
        }

        [HttpPost]
        public IActionResult Update(Customer customer)
        {
            _customerRepository.Update(customer);

            return RedirectToAction("List");
        }
        
    }
}
