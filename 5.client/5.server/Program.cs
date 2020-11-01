using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace _5.server
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----------------WCF хост---------------");

            using (ServiceHost serviceHost = new ServiceHost(typeof(Service1)))
            {
                serviceHost.Open();
                Console.WriteLine("Сервис запущен...");
                Console.WriteLine("Нажать Enter для остановки....");
                Console.ReadLine();
            }
        }
    }
}
