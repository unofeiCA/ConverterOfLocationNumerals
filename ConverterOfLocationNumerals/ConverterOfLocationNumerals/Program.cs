using System;

namespace ConverterOfLocationNumerals
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a positive number. Negative number and 0 are not supported.");
            int number = 0;
            Int32.TryParse(Console.ReadLine(), out number);
            if (number <= 0)
            {
                Console.WriteLine("Please enter a positive number. Negative number and 0 are not supported.");

            }
            else
            {
                Console.WriteLine(LocationNumeralsConverter.ConverIntegerToLocationNumerals(number));

            }
            Console.ReadLine();
        }
    }
}
