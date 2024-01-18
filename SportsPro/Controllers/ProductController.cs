﻿using Microsoft.AspNetCore.Mvc;
using SportsPro.Models;
using System.Linq;

namespace SportsPro.Controllers
{
    public class ProductController : Controller
    {
        private SportsProContext context { get; set; }

        public ProductController(SportsProContext ctx)
        {
            context = ctx;
        }

        [HttpGet]
        public IActionResult Add() 
        {
            ViewBag.Action = "Add";
            return View("Edit", new Product());
        }
        [HttpGet]
        public IActionResult Edit(int id) 
        {
            ViewBag.Action = "Edit";
            var product = context.Products.Find(id);
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(Product product) 
        {
            if (ModelState.IsValid)
            {
               if (product.ProductID == 0) 
               
                    context.Products.Add(product);
               else
                    context.Products.Update(product);
                     context.SaveChanges();
                return RedirectToAction("List");

            }
            else
            {
                ViewBag.Action = (product.ProductID == 0) ? "Add": "Edit";
                return View(product);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = context.Products.Find(id);
            return View(product);
        }
        [HttpPost]
        public IActionResult Delete(Product product)
        {
            context.Products.Remove(product);
            context.SaveChanges();
            return RedirectToAction("List");
        }

        public IActionResult List() 
        { 
            var products = context.Products.ToList();
            return View(products); 
        }  
    }
}
