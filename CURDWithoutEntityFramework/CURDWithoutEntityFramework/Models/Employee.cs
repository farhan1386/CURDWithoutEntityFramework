using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CURDWithoutEntityFramework.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Please enter first name")]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter last name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please choose gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Please enter your age")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Please enter your position")]
        public string Position { get; set; }

        [Required(ErrorMessage = "Please enter your office loaction")]
        public string Office { get; set; }

        [Required(ErrorMessage = "Please enter your salary")]
        public int Salary { get; set; }
    }
}