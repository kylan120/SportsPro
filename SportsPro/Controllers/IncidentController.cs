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
        public IActionResult List()
        {
            var incident = context.Incidents.ToList();
            return View(incident);
        }

        [HttpGet]
        public IActionResult AddOrEditIncident()
        {
            var viewModel = new AddEditIncidentViewModel
            {
                Customers = context.Customers.ToList(),
                Products = context.Products.ToList(),
                Technicians = context.Technicians.ToList(),
                CurrentIncident = new Incident(),
                Operation = "Add" // Set the operation to Add
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult EditIncident(int id)
        {
            var incident = context.Incidents.Find(id);
            if (incident == null)
            {
                return NotFound();
            }

            var viewModel = new AddEditIncidentViewModel
            {
                Customers = context.Customers.ToList(),
                Products = context.Products.ToList(),
                Technicians = context.Technicians.ToList(),
                CurrentIncident = incident,
                Operation = "Edit" // Set the operation to Edit
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEditIncident(AddEditIncidentViewModel viewModel)
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
                
                return RedirectToAction("IncidentManager");
            }

            // If ModelState is not valid, return to the same view with the viewModel
            viewModel.Customers = context.Customers.ToList();
            viewModel.Products = context.Products.ToList();
            viewModel.Technicians = context.Technicians.ToList();
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult DeleteIncident(int id)
        {
            var incident = context.Incidents.Find(id);
            if (incident == null)
            {
                return NotFound();
            }

            return View(incident);
        }

        [HttpPost, ActionName("DeleteIncident")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var incident = context.Incidents.Find(id);
            if (incident == null)
            {
                return NotFound();
            }

            context.Incidents.Remove(incident);
            context.SaveChanges();
            return RedirectToAction("IncidentManager");
        }
    }

}
