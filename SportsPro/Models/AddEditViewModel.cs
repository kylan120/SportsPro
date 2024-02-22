using System.Collections.Generic;

namespace SportsPro.Models
{
    public class AddEditViewModel
    {
        public List<Customer> Customers { get; set; }
        public List<Product> Products { get; set; }
        public List<Technician> Technicians { get; set; }

        public string Incidents { get; set; }
        public string Categor(string categories) => categories == Incidents ? "active" : "";

    }
}
