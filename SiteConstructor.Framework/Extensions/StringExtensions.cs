using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SiteConstructor.Framework.Helpers
{
    public static class StringExtensions
    {
        public static string FirstUpper(this string str)
        {
            string[] s = str.Split(' ');

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i].Length > 1)
                    s[i] = s[i].Substring(0, 1).ToUpper() + s[i].Substring(1, s[i].Length - 1).ToLower();
                else s[i] = s[i].ToUpper();
            }
            return string.Join(" ", s);
        }

        public static string MoneyFormat(this decimal dec)
        {
            NumberFormatInfo nfi = new NumberFormatInfo
            {
                CurrencyDecimalDigits = 2,
                NumberDecimalDigits = 2,
                NumberGroupSeparator = " ",
                CurrencyGroupSeparator = " ",
                CurrencyDecimalSeparator = ",",
                NumberDecimalSeparator = ","
            };
            string result = dec.ToString("N", nfi);
            return result;
        }

        public static string MoneyFormat(this decimal? dec)
        {
            if (dec == null) return "";
            else return MoneyFormat(dec.Value);
        }


        public static string FIOshort(this string fio)
        {
            string[] s = fio.Split(' ');

            for (int i = 0; i < s.Length; i++)
            {
                if (i > 0)
                    s[i] = s[i].Substring(0, 1).ToUpper() + ".";
            }
            return string.Join(" ", s);
        }

        public static int? ToNullableInt(this string s)
        {
            int i;
            if (int.TryParse(s, out i)) return i;
            return null;
        }

    }
}
