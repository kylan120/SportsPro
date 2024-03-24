﻿using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace SportsPro.Models
{
    public class Customer
    {
		public int CustomerID { get; set; }

		[Required]
		[StringLength(51)]
		public string FirstName { get; set; }

		[Required]
        [StringLength(51)]
        public string LastName { get; set; }

		[Required]
        [StringLength(51)]
        public string Address { get; set; }

		[Required]
        [StringLength(51)]
        public string City { get; set; }

		[Required]
        [StringLength(51)]
        public string State { get; set; }

		[Required]
		[StringLength(21)]
		public string PostalCode { get; set; }

		[Required]
		public string CountryID { get; set; }
        public Country Country { get; set; }

		[Required]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string Phone { get; set; }

		[Required]
        [StringLength(51)]
        [DataType(DataType.EmailAddress)]
		[Remote("CheckEmail", "Validation")]
        public string Email { get; set; }

		public string FullName => FirstName + " " + LastName;   // read-only property

		public ICollection<Incident> Incidents { get; set; } // navigation property
	}
}