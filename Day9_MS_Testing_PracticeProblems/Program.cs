using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9_MS_Testing_PracticeProblems
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Ms-Testing Problems.");

            Console.WriteLine("Enter space-separated prices:");
            string input = Console.ReadLine();

            PriceProcessor priceProcessor = new PriceProcessor();

            priceProcessor.ProcessPrices(input);

            Console.WriteLine("Prices of items sold only once:");
            var pricesSoldOnce = priceProcessor.GetPricesSoldOnce();
            foreach (var price in pricesSoldOnce)
            {
                Console.WriteLine($"Price: {price}");
            }

            Console.WriteLine("Prices of items sold more than once:");
            var pricesSoldMoreThanOnce = priceProcessor.GetPricesSoldMoreThanOnce();
            foreach (var price in pricesSoldMoreThanOnce)
            {
                Console.WriteLine($"Price: {price}");
            }

            Console.WriteLine("Price of earlier sold item in case of ties:");
            foreach (var price in pricesSoldMoreThanOnce)
            {
                var earlierItem = priceProcessor.GetEarlierSoldItem(pricesSoldMoreThanOnce);
                Console.WriteLine($"Price: {price}, Earlier Sold Item: {earlierItem}");
            }

            Console.ReadLine();
        }
    }
}
