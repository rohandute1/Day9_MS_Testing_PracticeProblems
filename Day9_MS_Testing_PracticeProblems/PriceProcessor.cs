using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9_MS_Testing_PracticeProblems
{
    public class PriceProcessor
    {
        private Dictionary<string, int> itemCounts = new Dictionary<string, int>();
        private Dictionary<string, int> itemIndex = new Dictionary<string, int>();

        public void ProcessPrices(string input)
        {
            string[] pricesArray = input.Split(' ');

            for (int i = 0; i < pricesArray.Length; i++)
            {
                string price = pricesArray[i];

                if (!itemCounts.ContainsKey(price))
                {
                    itemCounts[price] = 1;
                    itemIndex[price] = i;
                }
                else
                {
                    itemCounts[price]++;
                }
            }
        }

        public List<string> GetPricesSoldOnce()
        {
            List<string> pricesSoldOnce = new List<string>();
            foreach (var kvp in itemCounts)
            {
                if (kvp.Value == 1)
                {
                    pricesSoldOnce.Add(kvp.Key);
                }
            }
            return pricesSoldOnce;
        }

        public List<string> GetPricesSoldMoreThanOnce()
        {
            List<string> pricesSoldMoreThanOnce = new List<string>();
            foreach (var kvp in itemCounts)
            {
                if (kvp.Value > 1)
                {
                    pricesSoldMoreThanOnce.Add(kvp.Key);
                }
            }
            return pricesSoldMoreThanOnce;
        }

        public string GetEarlierSoldItem(List<string> items)
        {
            string earlierItem = null;
            int earliestIndex = int.MaxValue;

            foreach (var item in items)
            {
                if (itemIndex.ContainsKey(item) && itemIndex[item] < earliestIndex)
                {
                    earlierItem = item;
                    earliestIndex = itemIndex[item];
                }
            }

            return earlierItem;
        }
    }
}
