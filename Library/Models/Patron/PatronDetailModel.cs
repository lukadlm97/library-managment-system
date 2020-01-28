using LibraryData.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.Patron
{
    public class PatronDetailModel
    {
        public int Id { get; set; }
        public string FirstaName { get; set; }
        public string LastName { get; set; }
        public string FullName 
        { 
            get  {return FirstaName + " " + LastName;}
        }
        public int LibraryCardId { get; set; }
        public string Address { get; set; }
        public DateTime MemberSince { get; set; }
        public string Telephone { get; set; }
        public string HomeLibraryBranch { get; set; }
        public decimal OverdueFees { get; set; }
        public IEnumerable<Checkout> AssetsCheckOut { get; set; }
        public IEnumerable<CheckoutHistory> CheckOutHistory { get; set; }
        public IEnumerable<Hold> Holds { get; set; }
    }
}
