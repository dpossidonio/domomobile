using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Runtime.Serialization;
using System.Net;

namespace Service
{
    public class Program
    {
      public static string GetLocalIp()
        {
    
          string strHostName = Dns.GetHostName ();
              Console.WriteLine ("Local Machine's Host Name: " +  strHostName);
                 
          // Then using host name, get the IP address list..
          IPHostEntry ipEntry = Dns.GetHostByName(strHostName);
          IPAddress [] addr = ipEntry.AddressList;
          
          for (int i = 0; i < addr.Length; i++)
          {
              Console.WriteLine ("IP Address {0}: {1} ", i, addr[i].ToString ());
          }
          return addr[0].ToString();
        }    
     

        static void Main(string[] args)
        {
            string Port = "8000";

           string LocalIp = GetLocalIp();
           Uri baseAddress = new Uri(String.Format("http://{0}:{1}/DomoService", LocalIp, Port));

            //Uri baseAddress = new Uri("http://192.168.0.15:8000/DomoService");
            ServiceHost localhost = new ServiceHost(typeof(DomoService), baseAddress);

            try
            {
                localhost.AddServiceEndpoint(typeof(IDomoService), new BasicHttpBinding(), "DomoService");
                var smp = new ServiceMetadataBehavior();
                smp.HttpGetEnabled = true;
                localhost.Description.Behaviors.Add(smp);

                localhost.Open();
                Console.WriteLine("Tou a correr um serviço em: "+baseAddress.ToString());
                Console.ReadLine();
                localhost.Close();
            }
            catch (CommunicationException e)
            {
                localhost.Abort();
                Console.WriteLine("Erro");
            }
        }


    }

}
