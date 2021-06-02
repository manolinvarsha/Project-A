using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryBookingSystemMVC.Models
{
    public class Booking
    {
        [Key]
        [Display(Name = "Order Id")]
        public int OrderId { get; set; }


        [Display(Name = "Customer Id")]
        public int CustomerId { get; set; }


        [Required(ErrorMessage = "Please select an Executive Id")]
        [Display(Name = "Executive Id")]
        public int ExecutiveId { get; set; }


        [Required(ErrorMessage = "Please select Date and Time of Pickup")]
        [Display(Name = "Date And Time Of Pickup")]
        public DateTime DateAndTimeOfPickup { get; set; }


        [Required(ErrorMessage = " Please Enter the Weight of Package")]
        [Display(Name = "Weight Of Package In Grams")]
        public string WeightOfPackage { get; set; }


        [Required(ErrorMessage = "Please Enter Address")]
        [Display(Name = "Address")]
        public string Address { get; set; }


        [Required(ErrorMessage = "Please Enter City")]
        [Display(Name = "City")]
        public string City { get; set; }


        [Required(ErrorMessage = "Please Enter Pincode")]
        [Display(Name = "Pincode")]
       
       
        //[RegularExpression("^[0-9]*$", ErrorMessage = "Invalid Pin")]

        public int PinCode { get; set; }


        [Required(ErrorMessage = "Please Enter Phone Number")]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
       

        public string Phone { get; set; }


        [Display(Name = "Price")]
        public int Price { get; set; } = 100;


        [Display(Name = "Status")]
        public string Status { get; set; } = "Requested";

    }
}
