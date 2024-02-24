using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace SportsPro.Controllers
{

    public class IncidentController : Controller
    {
        private SportsProContext context { get; set; }

        public IncidentController(SportsProContext ctx)
        {
            context = ctx;
        }
        
         
        [Route("incidents")]
        public IActionResult Incident()
        {
            var incidents = context.Incidents
                .Include(i => i.Customer)
                .Include(i => i.Product)
                .Include(i => i.Technician)
                .ToList();
            
            var model = new IncidentManagerViewModel
            {
                Incidents = incidents
            };

            return View(model);
        }

        [Route("TechnicianIncident")]
        [HttpGet]
        public ViewResult ListByTech()
        {
            var incidents = context.Incidents
               .Include(i => i.Customer)
               .Include(i => i.Product)
               .Include(i => i.Technician)
               .ToList();
            
            var session = new IncidentSession(HttpContext.Session);
            var model = new IncidentManagerViewModel
            {
                Technicians = context.Technicians.ToList(),
                TechnicianID = session.GetTechID 

            };
          
            
            return View(model);
        }

        public ViewResult IncidentByTech()
        {
            var incidents = context.Incidents
               .Include(i => i.Customer)
               .Include(i => i.Product)
               .Include(i => i.Technician)
               .ToList();

            var session = new IncidentSession(HttpContext.Session);
            var model = new IncidentManagerViewModel
            {
                Technicians = context.Technicians.ToList(),
                TechnicianID = session.GetTechID

            };

            return View(model);
        }

       
        
        
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            PopulateDropdowns();
            return View("Edit", new Incident());
        }

        [HttpPost]
        public IActionResult Add(Incident incident)
        {
            if (ModelState.IsValid)
            {
                incident.DateOpened = DateTime.Now;
                context.Incidents.Add(incident);
                context.SaveChanges();
                return RedirectToAction("Incident");
            }
            else
            {
                ViewBag.Action = "Add";
                PopulateDropdowns();
                return View("Add", incident);
            }
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
                context.Incidents.Update(incident);
                context.SaveChanges();
                return RedirectToAction("Incident");
            }
            else
            {
                ViewBag.Action = "Edit";
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
            return RedirectToAction("Incident");
        }

        private void PopulateDropdowns()
        {
            ViewBag.Customers = context.Customers.ToList();
            ViewBag.Products = context.Products.ToList();
            ViewBag.Technicians = context.Technicians.ToList();
        }
    }

}