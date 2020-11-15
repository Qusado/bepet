using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace service7
{
   [ServiceContract(CallbackContract = typeof(IServerChatCallback))]
    public interface IService1
    {
        [OperationContract]
        int Connect(string name);

        [OperationContract]
        void Disconnect(int id);

        [OperationContract(IsOneWay = true)]
        void SendMess(string msg, int id);
    }

    public interface IServerChatCallback
    {
        [OperationContract(IsOneWay = true )]
        void MsgCallback(string msg);
    }
}
