﻿using Acme.Common;
using static Acme.Common.LoggingService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz
{
    /// <summary>
    /// Manages products carried in inventory.
    /// </summary>
    public class Product
    {
        #region Constructors
        public Product()
        {
            createColorsArrays();
            initArray();
            var states = new Dictionary<string, string>()
            {
                {"CA", "California" },
                {"WA", "Washington" },
                {"NY", "New York" },
            };
        }
        public Product(int productId,
                        string productName,
                        string description) : this()
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.Description = description;
            createColorsArrays();
        }
        #endregion
        public void createColorsArrays()
        {
            var colorOptions = new string[4];
            colorOptions[0] = "Red";
            colorOptions[1] = "Espresso";
            colorOptions[2] = "White";
            colorOptions[3] = "Navy";
        }

        public void initArray()
        {
            string[] colorOptions = { "Red", "White", "Espresso", "Navy" };
            foreach (var color in colorOptions)
            {
                Console.WriteLine($"The color is {color}");
            }
        }

        #region Properties
        public DateTime? AvailabilityDate { get; set; }

        public decimal Cost { get; set; }

        public string Description { get; set; }

        public int ProductId { get; set; }

        private string productName;
        public string ProductName
        {
            get {
                var formattedValue = productName?.Trim();
                return formattedValue;
            }
            set
            {
                if (value.Length < 3)
                {
                    ValidationMessage = "Product Name must be at least 3 characters";
                }
                else if (value.Length > 20)
                {
                    ValidationMessage = "Product Name cannot be more than 20 characters";

                }
                else
                {
                    productName = value;

                }
            }
        }

        private Vendor productVendor;
        public Vendor ProductVendor
        {
            get {
                if (productVendor == null)
                {
                    productVendor = new Vendor();
                }
                return productVendor;
            }
            set { productVendor = value; }
        }

        public string ValidationMessage { get; private set; }

        #endregion

        /// <summary>
        /// Calculates the suggested retail price
        /// </summary>
        /// <param name="markupPercent">Percent used to mark up the cost.</param>
        /// <returns></returns>
        public OperationResult<decimal> CalculateSuggestedPrice(decimal markupPercent)
        {
            var message = "";
            if (markupPercent <= 0m)
            {
                message = "Invalid markup percentage";
            }
            else if (markupPercent < 10)
            {
                message = "Below recommended markup percentage";
            }
            var value = this.Cost + (this.Cost * markupPercent / 100);

            var operationResult = new OperationResult<decimal>(value, message);
            return operationResult;
        }
          
        public override string ToString()
        {
            return this.ProductName + " (" + this.ProductId + ")";
        }
    }
}
