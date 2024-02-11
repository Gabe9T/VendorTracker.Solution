using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VendorTracker.Models;

namespace VendorTracker.Controllers
{
    public class VendorsController : Controller
    {
        [HttpGet("/vendors")]
        public IActionResult Index()
        {
            List<Vendor> allVendors = Vendor.GetAll();
            return View(allVendors);
        }

        [HttpGet("/vendors/new")]
        public IActionResult New()
        {
            return View();
        }

        [HttpGet("/vendors/{id}/show")]
        public IActionResult Show(int id)
        {
            var vendor = Vendor.Find(id);
            if (vendor == null)
            {
                return NotFound();
            }
            return View(vendor);
        }

        [HttpPost("/vendors/create")]
public IActionResult Create(string name, string description)
{
    if (string.IsNullOrEmpty(name)) 
    {
        return NotFound();
    }

    Vendor newVendor = new Vendor(name, description);
    return RedirectToAction("Index");
}

        [HttpPost("/vendors/{vendorId}/orders")]
        public ActionResult Create(int vendorId, string title, string description, double price, DateTime date)
        {
            var selectedVendor = Vendor.Find(vendorId);
            if (selectedVendor == null)
            {
                return NotFound();
            }

            var newOrder = new Order(title, description, price, date);
            selectedVendor.Orders.Add(newOrder);

            return RedirectToAction("Index", "Orders", new { id = vendorId });
        }
    }
}