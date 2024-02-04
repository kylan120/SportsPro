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
        [Route("incidents")]
        public IActionResult Incident()
        {
            var incidents = context.Incidents
                .Include(i => i.Customer)
                .Include(i => i.Product)
                .Include(i => i.Technician)
                .ToList();

            return View(incidents);
        }
        
        [HttpGet]
        public IActionResult EditIncident(int id)
        {
            var incident = context.Incidents.Find(id);
            if (incident == null)
            {
                return NotFound();
            }

            var viewModel = new AddEditViewModel
            {
                Customers = context.Customers.ToList(),
                Products = context.Products.ToList(),
                Technicians = context.Technicians.ToList(),
                CurrentIncident = incident,
                Operation = "Edit" 
            };

            return View("AddOrEdit", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEditIncident(AddEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (viewModel.Operation == "Add")
                {
                    context.Incidents.Add(viewModel.CurrentIncident);
                }
                else if (viewModel.Operation == "Edit")
                {
                    context.Incidents.Update(viewModel.CurrentIncident);
                }

                context.SaveChanges();

                return RedirectToAction("Incident");
            }

            // If ModelState is not valid, return to the same view with the viewModel
            viewModel.Customers = context.Customers.ToList();
            viewModel.Products = context.Products.ToList();
            viewModel.Technicians = context.Technicians.ToList();
            return View("AddOrEdit", viewModel);
        }
        
        /*
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
        */
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