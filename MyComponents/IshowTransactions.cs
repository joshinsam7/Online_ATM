using System.Collections.Generic;
using System.ServiceModel;

namespace MyComponents
{
    [ServiceContract]
    public interface IshowTransactions
    {
        [OperationContract]
        List<Transaction> GetTransactionHistory();
    }
}