using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sigma_Automation.Helpers
{
    public static class StringHelper
    {
        public static string ExtractValueBetweenSquareBrackets(this string value)
        {
            Regex regax = new Regex(@"\[(.*)\]");
            var v = regax.Match(value);
            string valueBetweenQuareBrackets = v.Groups[1].ToString();

            return valueBetweenQuareBrackets;
        }
    }
}
