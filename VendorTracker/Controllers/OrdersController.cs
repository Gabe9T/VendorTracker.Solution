using Microsoft.AspNetCore.Mvc;
using VendorTracker.Models;
using VendorTracker.Data;

namespace VendorTracker.Controllers
{
    public class OrdersController : Controller
    {
        [HttpPost("/vendors/{vendorId}/orders")]
        public ActionResult Create(int vendorId, string title, string description, double price, DateTime date)
        {
            Vendor vendor = VendorData.Vendors.Find(v => v.Id == vendorId);
            if (vendor != null)
            {
                Order newOrder = new Order(title, description, price, date);
                vendor.Orders.Add(newOrder);
            }
            return RedirectToAction("Show", "Vendors", new { id = vendorId });
        }
    }
}