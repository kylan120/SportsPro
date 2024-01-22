using System;
using System.ComponentModel.DataAnnotations;

namespace SportsPro.Models
{
    public class Incident
    {
		public int IncidentID { get; set; }

		public int CustomerID { get; set; }     // foreign key property
        [Required(ErrorMessage = "Customer is required.")]
        public Customer Customer { get; set; }  // navigation property

		public int ProductID { get; set; }     // foreign key property
        [Required(ErrorMessage = "Product is required.")]
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
}