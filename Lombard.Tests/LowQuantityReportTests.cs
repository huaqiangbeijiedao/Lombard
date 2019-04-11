using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Lombard.Logic;

namespace Lombard.Tests
{
    class LowQuantityReportTests
    {
        [Test]
        public void CheckProductQuantity_LowQuantity_ReturnsFalse()
        {
            var quantityReport = new LowQuantityReport();

            var item = new Item() {Quantity = 0 };

            var result = quantityReport.CheckProductQuantity(item);

            Assert.IsFalse(result);
        }

        [Test]
        public void CheckProductQuantity_HighQuantity_ReturnsTrue()
        {
            var quantityReport = new LowQuantityReport();

            var item = new Item() { Quantity = 10 };

            var result = quantityReport.CheckProductQuantity(item);

            Assert.IsTrue(result);
        }
    }
}
