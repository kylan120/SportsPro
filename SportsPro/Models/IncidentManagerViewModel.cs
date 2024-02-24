using System.Collections.Generic;

namespace SportsPro.Models
{
    public class IncidentManagerViewModel : Incident
    {
        
      
       public List<Customer> Customers;
       public List<Product> Products;
       public List<Technician> Technicians;
       public List<Incident> Incidents { get; set; }
       public Incident incident { get; set; }
       public Technician technician { get; set; }
        public string Filter { get; set; }
        public string CheckActiveCategory(string category) =>
            category == Filter ? "active" : "";
    }

}
