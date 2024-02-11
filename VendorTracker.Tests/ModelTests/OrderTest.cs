using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using VendorTracker.Controllers;
using VendorTracker.Models;

namespace VendorTracker.Tests
{
    [TestClass]
    public class OrdersControllerTests
    {
        [TestMethod]
        public void Index_ReturnsViewResult_WithVendorAndOrders()
        {
            var controller = new OrdersController();
            var vendor = new Vendor("Test Vendor", "Test Description");

            var result = controller.Index(vendor.Id) as ViewResult;

            Assert.IsNotNull(result);
            var model = result.Model as Dictionary<string, object>;
            Assert.IsNotNull(model);
            Assert.AreEqual(vendor, model["vendor"]);
            Assert.IsInstanceOfType(model["orders"], typeof(List<Order>));
        }

        [TestMethod]
        public void New_ReturnsViewResult_WithVendor()
        {
            var controller = new OrdersController();
            var vendor = new Vendor("Test Vendor", "Test Description");

            var result = controller.New(vendor.Id) as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(vendor, result.Model);
        }

        [TestMethod]
        public void Create_ValidOrder_ReturnsRedirectToActionResult()
        {
            var controller = new OrdersController();
            var vendor = new Vendor("Test Vendor", "Test Description");
            var title = "Test Order";
            var description = "Test Description";
            var price = 10.5;
            var date = DateTime.Now;

            var result = controller.Create(vendor.Id, title, description, price, date) as RedirectToActionResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ActionName);
        }

        [TestMethod]
        public void Create_InvalidOrder_ReturnsNotFoundResult()
        {
            var controller = new OrdersController();
            var vendor = new Vendor("Test Vendor", "Test Description");
            var title = "";
            var description = "Test Description";
            var price = 10.5;
            var date = DateTime.Now;

            var result = controller.Create(vendor.Id, title, description, price, date) as NotFoundResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Create_OrderForNonExistentVendor_ReturnsNotFoundResult()
        {
            var controller = new OrdersController();
            var vendorId = 9999; // Not real 
            var title = "Test Order";
            var description = "Test Description";
            var price = 10.5;
            var date = DateTime.Now;

            var result = controller.Create(vendorId, title, description, price, date) as NotFoundResult;

            Assert.IsNotNull(result);
        }
    }
}