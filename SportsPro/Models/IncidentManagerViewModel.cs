using System.Collections.Generic;

namespace SportsPro.Models
{
    public class IncidentManagerViewModel : Incident
    {
        
       public List<Incident> Incidents;
       public List<Customer> Customers;
       public List<Product> Products;
       public List<Technician> Technicians;
       public string Filter { get; set; }
        public string CheckActiveCategory(string category) =>
            category == Filter ? "active" : "";
    }

}
