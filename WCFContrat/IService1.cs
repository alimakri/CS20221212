using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCFContrat
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string Majuscule(string s);
    }
}
