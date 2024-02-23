using System.Collections.Generic;
using System.Xml;
using Microsoft.AspNetCore.Http;

namespace SportsPro.Models
{
    public class IncidentSession
    {
        
        private const string Incident = "incident";
        private const string Technician = "technician";
        private const string TechIDKey = "techid";

        

       
        private ISession session {  get; set; }
        public IncidentSession(ISession session) 
        {
            this.session = session; 
        }
        public void SetTechIDKey(int techID)
        {
            session.SetInt32(TechIDKey, techID);
        }

        public int? GetTechID => session.GetInt32(TechIDKey);

        public string? GetTechnicain => session.GetString(Technician);            
        public void SetTechnician(Technician technicians)
        {
            session.SetObject(Technician, technicians);
           
        }
       
        public List<Incident> GetIncident() =>
           session.GetObject<List<Incident>>(Incident) ?? new List<Incident>();
        public void SetIncident(List<Incident> incidents)
        {
            session.SetObject(Incident, incidents);
        }

        public void RemoveIncidents()
        {
            session.Remove(Incident);

        }

    }
}
