using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsPro.Models;
using System;
using System.Linq;

namespace SportsPro.Controllers
{
    
    public class IncidentController : Controller
    {
        private SportsProContext context { get; set; }

        public IncidentController(SportsProContext ctx)
        {
            context = ctx;
        }

        public IActionResult List()
        {
            var incidents = context.Incidents
                .Include(i => i.Customer)
                .Include(i => i.Product)
                .Include(i => i.Technician)
                .ToList();

            return View(incidents);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            PopulateDropdowns();
            return View("Edit", new Incident());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            PopulateDropdowns();
            var incident = context.Incidents.Find(id);
            return View("Edit", incident);
        }

        [HttpPost]
        public IActionResult Edit(Incident incident)
        {
            if (ModelState.IsValid)
            {
                if (incident.IncidentID == 0)
                {
                    incident.DateOpened = DateTime.Now;
                    context.Incidents.Add(incident);
                }
                else
                {
                    context.Incidents.Update(incident);
                }

                context.SaveChanges();
                return RedirectToAction("List", "Incident");
            }
            else
            {
                ViewBag.Action = (incident.IncidentID == 0) ? "Add" : "Edit";
                PopulateDropdowns();
                return View("Edit", incident);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var incident = context.Incidents.Find(id);
            return View(incident);
        }

        [HttpPost]
        public IActionResult Delete(Incident incident)
        {
            context.Incidents.Remove(incident);
            context.SaveChanges();
            return RedirectToAction("List", "Incident");
        }

        private void PopulateDropdowns()
        {
            ViewBag.Customers = context.Customers.ToList();
            ViewBag.Products = context.Products.ToList();
            ViewBag.Technicians = context.Technicians.ToList();
        }
    }

}
