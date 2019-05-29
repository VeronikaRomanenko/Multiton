using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiton
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine(IPCam.GetInstance("255.255.255.255").IPAddres);
                Console.WriteLine(IPCam.GetInstance("255.255.255.254").IPAddres);
                Console.WriteLine(IPCam.GetInstance("255.255.255.254").IPAddres);
                Console.WriteLine(IPCam.GetInstance("255.255.255.253").IPAddres);
                Console.WriteLine(IPCam.GetInstance("255.255.255.252").IPAddres);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    class IPCam
    {
        private static Dictionary<string, IPCam> dict = new Dictionary<string, IPCam>();
        public static IPCam GetInstance(string ipaddres)
        {
            if (dict.Count >= 3)
            {
                throw (new Exception("Не больше трех!"));
            }
            if (!dict.ContainsKey(ipaddres))
            {
                dict.Add(ipaddres, new IPCam(ipaddres));
            }
            return dict[ipaddres];
        }
        public string IPAddres { get; private set; }
        private IPCam(string ipaddres)
        {
            IPAddres = ipaddres;
        }
    }
}