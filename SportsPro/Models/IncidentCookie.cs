using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

namespace SportsPro.Models
{
    public class IncidentCookie
    {
        private const string Incident = "incident";
        private const string Delimeter = "-";

        private IRequestCookieCollection requestCookies { get; set; }
        private IResponseCookies responseCookies { get; set; }

        public IncidentCookie(IRequestCookieCollection cookies)
        {
            requestCookies = cookies;
        }

        public IncidentCookie(IResponseCookies cookies)
        {
            responseCookies = cookies;
        }

        public void SetIncidentID(List<Incident> incidents)
        {
            List<int> ids = incidents.Select(i => i.IncidentID).ToList();
            string idsString = string.Join(Delimeter, ids);
            RemoveMyIncidentID();

        }
        public string[] GetIncidentID()
        {
            string cookie = requestCookies[Incident];
            if (string.IsNullOrEmpty(cookie))
                return new string[] { };   
            else
                return cookie.Split(Delimeter);
        }

        public void RemoveMyIncidentID()
        {
            responseCookies.Delete(Incident);
        }

    }
}
