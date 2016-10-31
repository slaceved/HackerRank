using System;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Paragraph
{
    public class Solution
    {
        public static string ChangeDateFormat(string paragraph)
        {
            var rgx = new Regex(@"\d{2}/\d{2}/\d{4}");
            var mat = rgx.Matches(paragraph);
            foreach (Match m in mat)
            {
                var myDate = DateTime.Parse(m.Value, CultureInfo.InvariantCulture, DateTimeStyles.None);
                paragraph = Regex.Replace(paragraph, m.Value, myDate.ToString("dd/MM/yyyy"));
            }
            return paragraph;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine(ChangeDateFormat("Last time it rained was on 07/25/2013 and today is 08/09/2013."));
            Console.ReadKey();
        }
    }
}
