using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsPro.Models
{
    public class RegistrationModel
    {
        public int RegistrationID { get; set; }
        public int CustomerID { get; set; }
        public int ProductID { get; set; }
        public DateTime RegistrationDate { get; set; }

        [ForeignKey("CustomerID")]
        public Customer Customer { get; set; }

        [ForeignKey("ProductID")]
        public Product Product { get; set; }
    }

}
