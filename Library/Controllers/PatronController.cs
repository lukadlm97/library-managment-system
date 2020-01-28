using Library.Models.Patron;
using LibraryData;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
    public class PatronController:Controller
    {
        private readonly IPatron _patron;

        public PatronController(IPatron patron)
        {
            _patron = patron;
        }
        public IActionResult Index()
        {
            var allPatrons = _patron.GetAll();

            var patronModels = allPatrons
                .Select(patron => new PatronDetailModel
                {
                    Id = patron.Id,
                    FirstaName = patron.FirstName,
                    LastName = patron.LastName,
                    LibraryCardId = patron.LibraryCard.Id,
                    OverdueFees = patron.LibraryCard.Fees,
                    HomeLibraryBranch = patron.HomeLibraryBranch.Name
                }).ToList();
            var model = new PatronIndexModel
            {
                Patrons = patronModels
            };
            return View(model);
        }
        public IActionResult Detail(int id)
        {
            var patron = _patron.Get(id);
            var model = new PatronDetailModel
            {
                LastName = patron.LastName,
                FirstaName = patron.FirstName,
                Address = patron.Address,
                HomeLibraryBranch = patron.HomeLibraryBranch.Name,
                MemberSince = patron.LibraryCard.Created,
                OverdueFees = patron.LibraryCard.Fees,
                LibraryCardId = patron.LibraryCard.Id,
                Telephone = patron.TelephoneNumber,
                AssetsCheckOut = _patron.GetCheckouts(id).ToList() ?? new List<LibraryData.Model.Checkout>(),
                CheckOutHistory = _patron.GetCheckoutHistory(id),
                Holds = _patron.GetHolds(id)
            };
            return View(model);
        }
    }
}
