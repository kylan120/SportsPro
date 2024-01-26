using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SportsPro.Models
{
    public class Incident
    {
		
		public int IncidentID { get; set; }
        [Required(ErrorMessage = "Customer is required.")]
        public int CustomerID { get; set; }     // foreign key property
        
        public Customer Customer { get; set; }  // navigation property
		[Required(ErrorMessage ="Product is required")]
		public int ProductID { get; set; }     // foreign key property
        
        public Product Product { get; set; }   // navigation property

		public int? TechnicianID { get; set; }     // foreign key property - nullable
		public Technician Technician { get; set; }   // navigation property

		[Required(ErrorMessage = "Title is required.")]
		public string Title { get; set; }

		[Required(ErrorMessage = "Description is required.")]
		public string Description { get; set; }

        [Required(ErrorMessage = "Date Opened is required.")]
        public DateTime DateOpened { get; set; } = DateTime.Now;

		public DateTime? DateClosed { get; set; } = null;
	}

    public class IncidentManagerViewModel
    {
        public List<Incident> Incidents { get; set; }
        public string Filter { get; set; }
    }

    public class AddEditIncidentViewModel
    {
        public List<Customer> Customers { get; set; }
        public List<Product> Products { get; set; }
        public List<Technician> Technicians { get; set; }
        public Incident CurrentIncident { get; set; }
        public string Operation { get; set; } // Indicates whether it's an Add or Edit operation
    }

}