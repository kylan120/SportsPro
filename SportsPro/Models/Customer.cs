using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace SportsPro.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "First Name must be between 1 and 50 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Last Name must be between 1 and 50 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Address must be between 1 and 50 characters.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "City is required.")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "City must be between 1 and 50 characters.")]
        public string City { get; set; }

        [Required(ErrorMessage = "State is required.")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "State must be between 1 and 50 characters.")]
        public string State { get; set; }

        [Required(ErrorMessage = "Postal Code is required.")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Postal Code must be between 1 and 20 characters.")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Country is required.")]
        public string CountryID { get; set; }
        public Country Country { get; set; }

        [StringLength(14, ErrorMessage = "Phone number must be in the format (999) 999-9999.")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [StringLength(50, ErrorMessage = "Email must be between 1 and 50 characters.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Not a valid email address.")]
        [Remote("CheckEmail", "Validation")] // Assuming you have a ValidationController with a CheckEmail action
        public string Email { get; set; }

        public string FullName => FirstName + " " + LastName;

        public ICollection<Incident> Incidents { get; set; }
    }
}