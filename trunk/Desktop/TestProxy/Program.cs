using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Channels;

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

                var Client = new DomoServiceClient("BasicHttpBinding_IDomoService");
                Client.Echo();
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
