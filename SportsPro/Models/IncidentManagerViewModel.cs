using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SportsPro.Models
{
    public class IncidentManagerViewModel : Incident
    {
        
      
       public List<Customer> Customers;
       public List<Product> Products;

       [Required(ErrorMessage = "Please select a tech")]
       public List<Technician> Technicians;
       public List<Incident> Incidents { get; set; }
       public string Filter { get; set; }
        public string CheckActiveCategory(string category) =>
            category == Filter ? "active" : "";
    }

}
