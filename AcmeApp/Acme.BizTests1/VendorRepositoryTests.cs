using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acme.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz.Tests
{
    [TestClass()]
    public class VendorRepositoryTests
    {
        [TestMethod()]
        public void RetrieveValueTest()
        {
            // Arrange
            var repository = new VendorRepository();
            var expected = 42;

            // Act
            var actual = repository.RetrieveValue("Select ...", 42);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RetrieveTest()
        {
            // Arrange
            var repository = new VendorRepository();
            var v = new Vendor();

            // Act
            List<Vendor> actualVendors = repository.Retrieve();

            // Assert
            Assert.AreEqual(v, actualVendors[0]);
        }

        [TestMethod()]
        public void RetrieveWithKeysTest()
        {
            var repository = new VendorRepository();

            var expected = new Dictionary<string, Vendor>()
            {
                { "ABC Corp",
                    new Vendor() { VendorId = 5, CompanyName = "ABC Corp", Email = "abc@abc.com" } },
                { "XYZ Inc",
                    new Vendor() { VendorId = 8, CompanyName = "XYZ Inc", Email = "xyz@xyz.com" } },
            };

            var actual = repository.RetrieveWithKeys();

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}