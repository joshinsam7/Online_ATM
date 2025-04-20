using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Xml.Linq;
using System.Xml.XPath;
using System.IO;

namespace MyComponents
{
    [ServiceContract]
    public interface IwithdrawDeposit
    {
        [OperationContract]
        Boolean deposit(int value, string user);

        [OperationContract]
        Boolean withdraw(int value, string user);
    }
}
