using Microsoft.AspNetCore.Mvc;
using VendorTracker.Models; 
using VendorTracker.Data; 
using System.Collections.Generic;

namespace VendorTracker.Controllers
{
    public class VendorsController : Controller
    {
        private static List<Vendor> _vendors = new List<Vendor>();

        [HttpGet("/vendors")]
        public ActionResult Index()
        {
            return View(_vendors);
        }

        [HttpGet("/vendors/new")]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost("/vendors/create")]
        public ActionResult Create(string name, string description)
        {
            Vendor newVendor = new Vendor(name, description);
            _vendors.Add(newVendor);
            return RedirectToAction("Index");
        }

        [HttpGet("/vendors/{id}")]
        public ActionResult Show(int id)
        {
            Vendor vendor = _vendors.Find(v => v.Id == id);
            return View(vendor);
        }

[HttpGet("/Vendors/{id}/Orders/NewOrder")]
public ActionResult NewOrder(int id)
{
    Vendor vendor = _vendors.Find(v => v.Id == id);
    ViewBag.VendorId = id;
    return View("~/Views/Orders/NewOrder.cshtml", vendor);
}

    }
}