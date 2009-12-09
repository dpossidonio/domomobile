using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Channels;
using TestProxy.ServiceProxy;

namespace TestProxy
{
    public class Program
    {
        static void Main(string[] args)
        {
            string myip = "asdisfjlk";


            try
            {
                Binding binding = new BasicHttpBinding();
                EndpointAddress remoteAddress = new EndpointAddress("http://192.168.0.15:8000/DomoService");

                var Client = new DomoServiceClient();
                Client.Echo();
                Console.WriteLine(Client.GetHouseDescription("David", 1));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

            }

            Console.ReadLine();
           

        }

        public void Connect(String ip)
        {

        }
    }
}
