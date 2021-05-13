using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DemoApp.WebUI.Attributes;

namespace DemoApp.WebUI.Models
{
    public class UserModel
    {

        [MaxLength(100), Display(Name = "Name"), Required(ErrorMessage = "Please enter name")]
        public string Name { get; set; }
        [MaxLength(100), EmailAddress(ErrorMessage = "Please enter valid email"), Display(Name = "User Name (Email)"), Required(ErrorMessage = "Please enter user name")]
        public string UserName { get; set; }
        [MaxLength(25), RegularExpression("^(?=.{8,16}$)(?=.*?[a-z])(?=.*?[A-Z])(?=.*?[0-9]).*$", ErrorMessage = "Minimun length of 8 & at least one digit, lower case and one uppper case"), Display(Name = "Password"), Required(ErrorMessage = "Please enter password")]
        public string Password { get; set; }

        [MaxLength(25), RegularExpression("^(?=.{8,16}$)(?=.*?[a-z])(?=.*?[A-Z])(?=.*?[0-9]).*$", ErrorMessage = "Minimun length of 8 & at least one digit, lower case and one uppper case"), Display(Name = "Confirm Password"), Required(ErrorMessage = "Please enter confirm password"), Compare("Password", ErrorMessage = "Password and confirm password must be same")]
        public string ConfirmPassword { get; set; }

        [MaxLength(10), Display(Name = "Contact"), RegularExpression("^[6-9]\\d{9}$", ErrorMessage = "enter valid mobile number")]
        public string Contcat { get; set; }

        [Required(ErrorMessage = "Please select country"), Display(Name = "Country")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Please select city"), Display(Name = "City")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please select gender"), Display(Name = "Gender")]
        public string Gender { get; set; }
        [CustomValidations(ErrorMessage = "Please accept terms")]
        public bool Terms { get; set; }

    }
}
