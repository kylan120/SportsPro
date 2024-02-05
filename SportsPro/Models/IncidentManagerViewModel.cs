using System.Collections.Generic;

namespace SportsPro.Models
{
    public class IncidentManagerViewModel
    {
        public List<Incident> Incidents { get; set; }
        public string Filter { get; set; }

        public string CheckActiveCategory(string category) =>
            category == Filter ? "active" : "";
    }

}
