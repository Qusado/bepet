using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace host
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(service7.Service1)))
            {
                host.Open();
                Console.WriteLine("Хост стартовал!");
                Console.ReadKey();
            }
        }
    }
}
