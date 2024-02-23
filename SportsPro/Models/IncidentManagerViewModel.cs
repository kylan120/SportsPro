using System.Collections.Generic;

namespace SportsPro.Models
{
    public class IncidentManagerViewModel
    {
        
        private List<Incident> incidents;

        public List<Incident> Incidents
        {
            get => incidents;
            set
            {
                incidents = new List<Incident> {
                    new Incident { IncidentID = 0, Description = "All"}
                };
                incidents.AddRange(value);
            }
        }


        private List<Customer> customers;
        public List<Customer> Customers
        {
            get => customers;
            set
            {
                customers = new List<Customer> {
                    new Customer { CustomerID = 0, FirstName = "All", LastName = "All"}
                };
                customers.AddRange(value);
            }
        }
        private List<Product> products;
        public List<Product> Products
        {
            get => products;
            set
            {
                products = new List<Product> {
                    new Product { Name = "All", ProductID = 0}
                };
                products.AddRange(value);
            }
        }
        private List<Technician> technicianes;

        public List<Technician> Technicians
        {
            get => technicianes;
            set
            {
                technicianes = new List<Technician> {
                    new Technician {Name = "All", TechnicianID = 0}
                };
                technicianes.AddRange(value);
            }
        }

        public string Filter { get; set; }
        public string CheckActiveCategory(string category) =>
            category == Filter ? "active" : "";
    }

}
