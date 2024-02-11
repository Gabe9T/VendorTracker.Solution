using Microsoft.AspNetCore.Mvc;
using VendorTracker.Models;
using System;

namespace VendorTracker.Controllers
{
    public class OrdersController : Controller
    {
        [HttpGet("/vendors/{id}/orders")]
        public ActionResult Index(int id)
        {
            var selectedVendor = Vendor.Find(id);
            if (selectedVendor == null)
            {
                return NotFound();
            }

            var model = new Dictionary<string, object>
            {
                { "vendor", selectedVendor },
                { "orders", selectedVendor.Orders }
            };

            return View(model);
        }

        [HttpGet("/vendors/{id}/orders/new")]
        public ActionResult New(int id)
        {
            var selectedVendor = Vendor.Find(id);
            if (selectedVendor == null)
            {
                return NotFound();
            }

            return View(selectedVendor);
        }

        [HttpPost("/vendors/{id}/orders/create")]
public ActionResult Create(int id, string title, string description, double price, DateTime date)
{
    var selectedVendor = Vendor.Find(id);
    if (selectedVendor == null || string.IsNullOrEmpty(title))
    {
        return NotFound();
    }

    var newOrder = new Order(title, description, price, date);
    selectedVendor.Orders.Add(newOrder);

    return RedirectToAction("Index", new { id });
}
    }
}