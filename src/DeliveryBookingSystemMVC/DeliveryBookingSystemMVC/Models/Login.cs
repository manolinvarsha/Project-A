using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryBookingSystemMVC.Models
{
    public class Login
    {
       [Required]
        public string Username { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Password")]

        public string Password { get; set; } 
    }
}
