using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigma_Automation.Dto
{
    public class CoversData
    {
        public CoversData()
        {
            Description = new List<string>();
            CoversToLeft = new List<string>();
        }
        public List<string> Description { get; set; }
        public List<string> CoversToLeft { get; set; }

        public void SetCoversToLeft(string[] coversToLeft)
        {
            foreach(var cov in coversToLeft)
            {
                CoversToLeft.Add(cov);
            }
        }

    }
}
