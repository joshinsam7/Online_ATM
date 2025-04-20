using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MyComponents
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IwithdrawDeposit" in both code and config file together.
    [ServiceContract]
    public interface IwithdrawDeposit
    {
        [OperationContract]
        Boolean deposit(int value, string user);

        [OperationContract]
        Boolean withdraw(int value, string user);
    }
}
