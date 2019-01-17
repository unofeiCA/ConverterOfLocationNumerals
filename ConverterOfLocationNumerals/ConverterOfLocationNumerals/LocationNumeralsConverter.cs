using System;
namespace ConverterOfLocationNumerals
{
    public class LocationNumeralsConverter
    {
        //I am not sure what you are looking for by "breaking the limit of 2^26", 
        //what I am doing is if the number is larger than 2^26 I create other location numerals
        //then I connect them together using connector '-'
        //as I use UInt64 in my code, all the input number should be less than or equal 18446744073709551615
        //and the maximum of location numeral should be "abcdefghijkl-abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz"

        static readonly char[] Letters = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};
        const char CONNECTOR = '-';
        const int POWER_2_26 = 67108864;

        public static string ConverIntegerToLocationNumerals(UInt64 num) 
        {
            string ret = "";
            UInt64 temp = num;
            int counter = 0;
            while (temp > 0) 
            {
                string tempRet = "";
                for (int i = 0; i < Letters.Length; i++)
                {
                    if ((temp & 0x01) != 0)
                    {
                        tempRet += Letters[i];
                    }
                    temp = temp >> 1;
                }
                if (counter > 0)
                {
                    ret = CONNECTOR + ret;

                }
                ret = tempRet + ret;
                counter++;
            }

            return ret;
        }

        public static UInt64 ConverLocationNumeralsToInteger(string locationNum)
        {
            string[] nums = locationNum.Split(CONNECTOR);
            UInt64 ret = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                ret += (UInt64)(Math.Pow(POWER_2_26, nums.Length - 1 - i) * LocationNumeralToInteger(nums[i]));
            }
            return ret;
        }

        public static string ConverLocationNumeralsToAbbreviation(string locationNum)
        {
            return ConverIntegerToLocationNumerals(ConverLocationNumeralsToInteger(locationNum));

        }

        private static int LocationNumeralToInteger(string locationNum)
        {
            int ret = 0;
            for (int i = 0; i < locationNum.Length; i++)
            {
                int index = Array.IndexOf(Letters, locationNum[i]);
                ret += (int)Math.Pow(2, index);
            }
            return ret;
        }
    }
}
