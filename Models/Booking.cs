using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Travelo.Models
{
    
    public class Booking
    {
        [Key]
        public int ID { get; set; }
    
        [Display(Name = "Hotel Name")]
        public string Hotel_Name { get; set; }

        [Display(Name = "Hotel Price")]
        public string Hotel_Price { get; set; }

        [Display(Name = "Flight Price")]
        public string Flight_Price { get; set; }

        [Display(Name = "Flight Date")]
        public string Flight_Date { get; set; }

        [Required(ErrorMessage = "Please Choose Your Check In Date")]
        [Display(Name = "Check In")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public string Check_In { get; set; }

        [Required(ErrorMessage = "Please Choose Your Check Out Date")]
        [Display(Name = "Check Out")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public string Check_Out { get; set; }

        [Required, Range(1, int.MaxValue, ErrorMessage = "Please Choose The Duration")]
        [Display(Name = "Duration")]
        public string Duration { get; set; }

        [Required, Range(1, int.MaxValue, ErrorMessage = "Please Choose Number Of Your  Members")]
        [Display(Name = "Members")]
        public string Members { get; set; }

        
        [Display(Name = "Hotel Location")]
        public string Hotel_Location { get; set; }

        
        [Display(Name = "From")]
        public string From { get; set; }

        [Required(ErrorMessage = "Please Choose Your Departure Date")]
        [Display(Name = "Departure")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public string Departure { get; set; }

        [Required(ErrorMessage = "Please Choose Your Return Date")]
        [Display(Name = "Return")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public string Return { get; set; }

        [Required, Range(1, int.MaxValue, ErrorMessage = "Please Choose Number of Your Adults")]
        [Display(Name = "Adults")]
        public string Adults { get; set; }

        [Required, Range(1, int.MaxValue, ErrorMessage = "Please Choose Number of Your Childs")]
        [Display(Name = "Childs")]
        public string Childs { get; set; }


        
        [Display(Name = "TO")]
        public string TO { get; set; }

        [Required, Range(1, int.MaxValue, ErrorMessage = "Please Choose Your Class")]
        [Display(Name = "Class")]
        public string Class { get; set; }

    }
}