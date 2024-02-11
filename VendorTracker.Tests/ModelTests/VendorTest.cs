using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using VendorTracker.Controllers;
using VendorTracker.Models;

namespace VendorTracker.Tests
{
    [TestClass]
    public class VendorsControllerTests
    {
        [TestMethod]
        public void Index_ReturnsViewResult_WithListOfVendors()
        {

            var controller = new VendorsController();

            var result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Model, typeof(List<Vendor>));
        }

        [TestMethod]
        public void Show_ValidVendorId_ReturnsViewResult_WithVendor()
        {
            var controller = new VendorsController();
            var vendorId = 1; 

            var result = controller.Show(vendorId) as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Model, typeof(Vendor));
        }

        [TestMethod]
        public void New_ReturnsViewResult()
        {
            var controller = new VendorsController();

            var result = controller.New() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Create_ValidVendor_ReturnsRedirectToActionResult()
        {
            var controller = new VendorsController();
            var name = "Test Vendor";
            var description = "Test Description";

            var result = controller.Create(name, description) as RedirectToActionResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ActionName);
        }

        [TestMethod]
        public void Create_InvalidVendor_ReturnsNotFoundResult()
        {
            var controller = new VendorsController();
            var name = ""; 

            var result = controller.Create(name, "") as NotFoundResult;

            Assert.IsNotNull(result);
        }
    }
}