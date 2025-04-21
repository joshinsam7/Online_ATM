using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MyComponents
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "Iencryptdecrypt" in both code and config file together.
    [ServiceContract]
    public interface Iencryptdecrypt
    {
        [OperationContract]
        string encrypt(string plainText);

        [OperationContract]
        string decrypt(string cipherText);
    }
}
