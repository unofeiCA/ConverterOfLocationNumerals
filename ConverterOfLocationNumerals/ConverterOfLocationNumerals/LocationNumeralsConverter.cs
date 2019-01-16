using System;
namespace ConverterOfLocationNumerals
{
    public class LocationNumeralsConverter
    {
        static readonly char[] Letters = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};
        const char CONNECTOR = '-';
        const int POWER_2_26 = 67108864;

        public static string ConverIntegerToLocationNumerals(int num) 
        {
            string ret = "";
            int temp = num;
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

        public static int ConverLocationNumeralsToInteger(string locationNum)
        {
            string[] nums = locationNum.Split(CONNECTOR);
            int ret = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                ret += (int)Math.Pow(POWER_2_26, nums.Length - 1 - i) * LocationNumeralToInteger(nums[i]);
            }
            return 0;
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
