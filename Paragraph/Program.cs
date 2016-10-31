using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Util
{
    public class Paragraph
    {
        public static string ChangeDateFormat(string paragraph)
        {
            Regex rgx = new Regex(@"\d{2}/\d{2}/\d{4}");
            MatchCollection mat = rgx.Matches(paragraph);
            foreach (Match m in mat)
            {
                DateTime myDate;
                myDate = DateTime.Parse(m.Value, CultureInfo.InvariantCulture, DateTimeStyles.None);

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
