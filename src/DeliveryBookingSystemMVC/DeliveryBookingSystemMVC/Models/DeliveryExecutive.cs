using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryBookingSystemMVC.Models
{
    public class DeliveryExecutive
    {
        [Key]
        [Display(Name = "Executive Id")]
        public int ExecutiveId { get; set; }


        [Required(ErrorMessage = "Please Enter Name")]
        [Display(Name = "Name")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "special characters are not allowed.")]
        public string Name { get; set; }


        [Display(Name = "Username")]
        [Required(ErrorMessage = "Please Enter Username")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "special characters are not allowed.")]
        public string Username { get; set; }


        [Required(ErrorMessage = "Please Enter Password")]
        [MinLength(8)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }


        [Range(0, 120, ErrorMessage = "Age must be between 1-120 in years.")]
        [Required(ErrorMessage = "Please Enter Age")]
        [Display(Name = "Age")]
        public int Age { get; set; }


        [Required(ErrorMessage ="Please Enter Phone Number")]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        

        public string Phone { get; set; }


        [Required(ErrorMessage = "Please Enter Address")]
        [Display(Name = " Address")]
        public string Address { get; set; }


        [Required(ErrorMessage = "Please Enter City")]
        [Display(Name = "City")]
        public string City { get; set; }


        [Display(Name = " Verification")]
        public string IsVerified { get; set; }
    }
}
