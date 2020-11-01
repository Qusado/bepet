using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace _5.server
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IService1" в коде и файле конфигурации.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string RecCheck(string id_exp, string id_h, string date, string stay);


        [OperationContract]
        DataTable GetHallSelectData();

        [OperationContract]
        DataTable GetExpSelectData();


        [OperationContract]
        DataTable GetData();

        [OperationContract]
        string InsertMethod(string id_exp, string id_h, string date);
    }
}
