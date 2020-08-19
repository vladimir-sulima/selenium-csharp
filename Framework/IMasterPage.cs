using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigma_Automation
{
    public interface IMasterPage<out TPage> where TPage : new()
    {
        TPage Logoff();
    }
}
