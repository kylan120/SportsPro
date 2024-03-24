using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using SportsPro.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.IdentityModel.Tokens;

namespace SportsPro.Controllers
{
    public class Validation : Controller
    {
       private SportsProContext _context {  get; set; }
        public Validation(SportsProContext ctx) => _context = ctx;

        public JsonResult CheckEmail(string email)
        {
            bool emailExists = _context.Customers.Any(c => c.Email == email);
            if (emailExists)
            {
                return Json($"Emaill address {email} is already registered");
            }
            else
            {
                return Json(true);
            }
        }

    }
}
