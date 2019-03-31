using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz
{
    public class VendorRepository
    {
        private List<Vendor> vendors;
        /// <summary>
        /// Retrieve one vendor.
        /// </summary>
        /// <param name="vendorId">Id of the vendor to retrieve.</param>
        public Vendor Retrieve(int vendorId)
        {
            // Create the instance of the Vendor class
            Vendor vendor = new Vendor();

            // Code that retrieves the defined customer

            // Temporary hard coded values to return 
            if (vendorId == 1)
            {
                vendor.VendorId = 1;
                vendor.CompanyName = "ABC Corp";
                vendor.Email = "abc@abc.com";
            }
            return vendor;
        }

        public List<Vendor> Retrieve()
        {
            if (vendors == null)
            {
                vendors = new List<Vendor>();
                vendors.Add(new Vendor() { VendorId = 1, CompanyName = "ABC", Email = "me@ABC.com" });
            }

            Console.WriteLine(vendors[0]);
            return vendors;
        }


        public Dictionary<string, Vendor> RetrieveWithKeys()
        {
            var vendorsDict = new Dictionary<string, Vendor>()
            {
                { "ABC Corp",
                    new Vendor() { VendorId = 5, CompanyName = "ABC Corp", Email = "abc@abc.com" } },
                { "XYZ Inc",
                    new Vendor() { VendorId = 8, CompanyName = "XYZ Inc", Email = "xyz@xyz.com" } },
            };
            return vendorsDict;
        }
        

        /// <summary>
        /// Save data for one vendor.
        /// </summary>
        /// <param name="vendor">Instance of the vendor to save.</param>
        /// <returns></returns>
        public bool Save(Vendor vendor)
        {
            var success = true;

            // Code that saves the vendor

            return success;
        }

        // Generics: A technique for defining data types using a variable. 
        public T RetrieveValue<T>(string sql, T defaultValue)
        {
            T value = defaultValue;

            return value;
        }
    }
}
