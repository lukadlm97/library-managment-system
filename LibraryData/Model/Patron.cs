using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryData.Model
{
    public class Patron
    {
        public int Id { get; set; }
        
        [Required]
        [Display(Name ="First Name")]
        [StringLength(30,ErrorMessage ="Limit first name to 30 characters.")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(30, ErrorMessage = "Limit Last name to 30 characters.")]
        public string LastName { get; set; }
        
        [Required]  
        public string Address { get; set; }
        
        [Required]
        public DateTime DateOfBirth { get; set; }
        public string TelephoneNumber { get; set; }

        [Required]
        [Display(Name ="Library Card")]
        
        public virtual LibraryCard LibraryCard { get; set; }

        public virtual LibraryBranch HomeLibraryBranch { get; set; }
    }
}
