using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Travelo.Models
{
    public class User_Tabel
    {

        [Required(ErrorMessage = "Please enter FirstName")]
        [Display(Name = "FirstName")]
        [RegularExpression("^().{4,50}$", ErrorMessage = "Please Write  Minimum 4 characters ")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter LastName")]
        [Display(Name = "LastName")]
        [RegularExpression("^().{4,50}$", ErrorMessage = "Please Write  Minimum 4 characters ")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z]).{8,50}$", ErrorMessage = "Password must contain: Minimum 8 characters atleast 1 UpperCase Alphabet, 1 LowerCase Alphabet, 1 Number")]
        public string Password { get; set; }

        [Display(Name = "Confirm password")]
        [Required(ErrorMessage = "Please enter confirm password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        [DataType(DataType.Password)]
        public string Confirmpwd { get; set; }

        [Key]
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Please enter your email address")]
        [EmailAddress( ErrorMessage = "Please enter correct email")]
        public string Email { get; set; }

        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Please Select the gender")]
        public string Gender { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number Required!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{5})$",
                      ErrorMessage = "Entered phone format is not valid.")]
        public string PhoneNumber { get; set; }

        
        [Required, Range(1, int.MaxValue, ErrorMessage = "Please Choose Your Country")]
        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "If You Have Another City Please,Write its Name")]
        public string Other_City { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "Profile Image")]
        [Required(ErrorMessage = "Please choose Your Profile Image to upload")]
        public string Image { get; set; }

    }
   
 
    
    public class TravelODBContext : DbContext
    {
        public TravelODBContext()
        { }
        public DbSet<User_Tabel> UserTabel { get; set; }
        public DbSet<User_Messages> UserMessage { get; set; }
        public DbSet<Booking> booking { get; set; }
    }

    public class User_Messages
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Please enter Your Name")]
        [Display(Name = "Full Name")]
        [RegularExpression("^().{8,50}$", ErrorMessage = "Please Write  Minimum 8 characters ")]
        public string fullName { get; set; }
         
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Please enter your email address")]
        [EmailAddress(ErrorMessage = "Please enter correct email")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Please enter Your Subject")]
        [Display(Name = "Subject")]
        [RegularExpression("^().{10,50}$", ErrorMessage = "Please Write  Minimum 10 characters ")]
        public string Subject { get; set; }


        [Required(ErrorMessage = "Please enter Your Message")]
        [Display(Name = "Message")]
        [RegularExpression("^().{15,50}$", ErrorMessage = "Please Write  Minimum 15 character ")]
        public string Message { get; set; }
    }
    


    }