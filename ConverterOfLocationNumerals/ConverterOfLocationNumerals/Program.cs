using System;

namespace ConverterOfLocationNumerals
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true) 
            {
                Console.WriteLine("*************************");
                Console.WriteLine("*IN THIS PROGRAM*");
                Console.WriteLine("*THE MAXIMUM OF INTEGER IS 18446744073709551615*");
                Console.WriteLine("*THE MAXIMUM OF LOCATION NUMERAL IS");
                Console.WriteLine("\"abcdefghijkl-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz\"*");
                Console.WriteLine("");
                Console.WriteLine("*Select an option please.*");
                Console.WriteLine("1. Convert integer to location numeral");
                Console.WriteLine("2. Convert location numeral to integer");
                Console.WriteLine("3. Convert location numeral to its abbreviated form");
                Console.WriteLine("*************************");


                int option = 0;
                if (Int32.TryParse(Console.ReadLine(), out option) && option >= 1 && option <= 3) 
                {
                    switch (option)
                    {
                        case 1:
                            ConvertIntegerToLocationNumeral();
                            break;
                        case 2:
                            ConvertLocationNumeralToInteger();
                            break;
                        case 3:
                            ConvertLocationNumeralToAbbreviated();
                            break;
                        default:
                            break;
                    }
                }
                else 
                {
                    Console.WriteLine("Please select an option within 1 to 3. Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        static void ConvertIntegerToLocationNumeral() 
        {
            Console.WriteLine("-Please enter a positive number. Negative number and 0 are not supported.");
            UInt64 number = 0;
            UInt64.TryParse(Console.ReadLine(), out number);
            if (number <= 0)
            {
                Console.WriteLine("Input invalid, back to main menu. Press any key to continue...");
                Console.ReadKey();
            }
            else
            {
                string ret = LocationNumeralsConverter.ConverIntegerToLocationNumerals(number);
                Console.WriteLine(ret);

                Console.WriteLine("Conversion completed. Press any key to continue...");
                Console.ReadKey();
            }
        }

        static void ConvertLocationNumeralToInteger() 
        {
            Console.WriteLine("-Please enter a location numeral. All of the letters are supposed to be within a ~ z in lower case. You can use connector '-' to connect different part of the location numeral.");
            string locationNumeral = Console.ReadLine();
            if (CheckLocationNumeralWithinAZ(locationNumeral))
            {
                UInt64 ret = LocationNumeralsConverter.ConverLocationNumeralsToInteger(locationNumeral);
                Console.WriteLine(ret);

                Console.WriteLine("Conversion completed. Press any key to continue...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Input invalid, back to main menu. Press any key to continue...");
                Console.ReadKey();
            }
        }
        static void ConvertLocationNumeralToAbbreviated() 
        {
            Console.WriteLine("-Please enter a location numeral. All of the letters are supposed to be within a ~ z in lower case. You can use connector '-' to connect different part of the location numeral.");
            string locationNumeral = Console.ReadLine();
            if (CheckLocationNumeralWithinAZ(locationNumeral))
            {
                string ret = LocationNumeralsConverter.ConverLocationNumeralsToAbbreviation(locationNumeral);
                Console.WriteLine(ret);

                Console.WriteLine("Conversion completed. Press any key to continue...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Input invalid, back to main menu. Press any key to continue...");
                Console.ReadKey();
            }
        }

        static bool CheckLocationNumeralWithinAZ(string locationNumeral) 
        {
            bool ret = true;
            for (int i = 0; i < locationNumeral.Length; i++)
            {
                char letter = locationNumeral[i];
                if ((letter < 97 || letter > 122) && letter != 45)
                {
                    ret = false;
                    break;
                }
            }
            return ret;
        }
    }
}
