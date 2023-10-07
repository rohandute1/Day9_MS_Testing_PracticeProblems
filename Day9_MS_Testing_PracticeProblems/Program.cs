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

            bool continueExecution = true;
            while (continueExecution)
            {
                Console.WriteLine("Please choose program to perform:");
                Console.WriteLine("1.Purchase List\n2.Swap Competition");
                int select = Convert.ToInt32(Console.ReadLine());

                switch (select)
                {
                    case 1:

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
                        break;

                    case 2:
                        Console.WriteLine("Enter the number of groups:");
                        int n = int.Parse(Console.ReadLine());

                        for (int i = 0; i < n; i++)
                        {
                            Console.WriteLine($"Group {i + 1}:");
                            Console.WriteLine("Enter the first player's word:");
                            string word1 = Console.ReadLine();
                            Console.WriteLine("Enter the second player's word:");
                            string word2 = Console.ReadLine();

                            bool isEligible = SwapChecker.IsEligible(word1, word2);

                            if (isEligible)
                            {
                                Console.WriteLine("YES");
                            }
                            else
                            {
                                Console.WriteLine("NO");
                            }
                        }
                        break;
                }
                Console.WriteLine("Do you want to continue.(yes/no)");
                string userInput = Console.ReadLine();
                if (userInput != "yes")
                {
                    continueExecution = false;
                }
            }

            Console.ReadLine();
        }
    }
}
