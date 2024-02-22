using System.Collections.Generic;
using System.Xml;
using Microsoft.AspNetCore.Http;

namespace SportsPro.Models
{
    public class IncidentSession
    {
        private const string Customer = "customer";
        private const string Product = "product";
        private const string Incident = "incident";
        private const string Technician = "technician";
        private ISession session {  get; set; }
        public IncidentSession(ISession session) 
        {
            this.session = session; 
        }


        public List<Technician> GetTechnicians() =>
            session.GetObject<List<Technician>>(Technician) ?? new List<Technician>();
        public void SetTechnician(List<Technician> technicians)
        {
            session.SetObject(Technician, technicians);
        }
        public List<Incident> GetIncident() =>
           session.GetObject<List<Incident>>(Incident) ?? new List<Incident>();
        public void SetIncident(List<Incident> incidents)
        {
            session.SetObject(Incident, incidents);
        }

        public List<Customer> GetCustomer() =>
           session.GetObject<List<Customer>>(Customer) ?? new List<Customer>();
        public void SetCustomer(List<Customer> customers)
        {
            session.SetObject(Customer, customers);
        }

        public List<Product> GetProduct() =>
           session.GetObject<List<Product>>(Product) ?? new List<Product>();
        public void SetProduct(List<Product> products)
        {
            session.SetObject(Product, products);
        }

    }
}
