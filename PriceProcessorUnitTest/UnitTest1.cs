using Day9_MS_Testing_PracticeProblems;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace PriceProcessorUnitTest
{
    [TestClass]
    public class PriceProcessorTest
    {
        [TestMethod]
        public void TestProcessPrices()
        {
            // Arrange
            string input = "10 20 10 30 20";
            PriceProcessor priceProcessor = new PriceProcessor();

            // Act
            priceProcessor.ProcessPrices(input);

            // Assert
            Dictionary<string, int> itemCounts = GetItemCounts(priceProcessor);
            Dictionary<string, int> itemIndex = GetItemIndex(priceProcessor);

            // Check item counts
            Assert.AreEqual(2, itemCounts["10"]);
            Assert.AreEqual(2, itemCounts["20"]);
            Assert.AreEqual(1, itemCounts["30"]);

            // Check item indexes
            Assert.AreEqual(0, itemIndex["10"]);
            Assert.AreEqual(1, itemIndex["20"]);
            Assert.AreEqual(3, itemIndex["30"]);
        }

        [TestMethod]
        public void TestGetPricesSoldOnce()
        {
            // Arrange
            string input = "10 20 10 30 20";
            PriceProcessor priceProcessor = new PriceProcessor();

            // Act
            priceProcessor.ProcessPrices(input);
            List<string> pricesSoldOnce = priceProcessor.GetPricesSoldOnce();

            // Assert
            Assert.AreEqual(1, pricesSoldOnce.Count);
            Assert.IsTrue(pricesSoldOnce.Contains("30"));
        }

        [TestMethod]
        public void TestGetPricesSoldMoreThanOnce()
        {
            // Arrange
            string input = "10 20 10 30 20";
            PriceProcessor priceProcessor = new PriceProcessor();

            // Act
            priceProcessor.ProcessPrices(input);
            List<string> pricesSoldMoreThanOnce = priceProcessor.GetPricesSoldMoreThanOnce();

            // Assert
            Assert.AreEqual(2, pricesSoldMoreThanOnce.Count);
            Assert.IsTrue(pricesSoldMoreThanOnce.Contains("10"));
            Assert.IsTrue(pricesSoldMoreThanOnce.Contains("20"));
        }

        [TestMethod]
        public void TestGetEarlierSoldItem()
        {
            // Arrange
            string input = "10 20 10 30 20";
            PriceProcessor priceProcessor = new PriceProcessor();

            // Act
            priceProcessor.ProcessPrices(input);
            List<string> pricesSoldMoreThanOnce = priceProcessor.GetPricesSoldMoreThanOnce();

            // Assert
            string earlierSoldItem1 = priceProcessor.GetEarlierSoldItem(new List<string> { "10", "20" });
            string earlierSoldItem2 = priceProcessor.GetEarlierSoldItem(new List<string> { "20", "10" });

            Assert.AreEqual("10", earlierSoldItem1);
            Assert.AreEqual("10", earlierSoldItem2);
        }

        private Dictionary<string, int> GetItemCounts(PriceProcessor priceProcessor)
        {
            // Use reflection to access private field "itemCounts"
            var fieldInfo = typeof(PriceProcessor).GetField("itemCounts", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            return (Dictionary<string, int>)fieldInfo.GetValue(priceProcessor);
        }

        private Dictionary<string, int> GetItemIndex(PriceProcessor priceProcessor)
        {
            // Use reflection to access private field "itemIndex"
            var fieldInfo = typeof(PriceProcessor).GetField("itemIndex", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            return (Dictionary<string, int>)fieldInfo.GetValue(priceProcessor);
        }
    }
}
