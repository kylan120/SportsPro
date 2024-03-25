using System.Collections.Generic;

namespace SportsPro.Models
{
    public class CustomerRegistrationsViewModel
    {
        public Customer Customer { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
