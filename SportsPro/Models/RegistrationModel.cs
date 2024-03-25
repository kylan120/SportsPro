using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsPro.Models
{
    public class RegistrationModel
    {
        public int RegistrationID { get; set; }
        public int CustomerID { get; set; }     // foreign key property
        public Customer Customer { get; set; }  // navigation property
        public int ProductID { get; set; }     // foreign key property
        public Product Product { get; set; }   // navigation property
        public DateTime RegistrationDate { get; set; }
    }

}
