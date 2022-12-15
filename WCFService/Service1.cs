using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFContrat;

namespace WCFService
{
    public class Service1 : IService1
    {
        public string Majuscule(string s)
        {
            return s.ToUpper();
        }
    }
}
