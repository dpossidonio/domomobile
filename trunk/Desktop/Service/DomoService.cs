using System;
using System.IO;
using System.Reflection;

namespace Service
{
    public class DomoService : IDomoService
    {
        #region IDomoService Members

        public string[] GetHouses()
        {
            //See available houses
            Console.WriteLine("GetHouses : Casa de Campo, Apartamento Las Vegas, Casa Lisboa");
            return new string[] { "Casa de Campo"};
        }

        public string GetHouseDescription(int id)
        {
            Console.WriteLine("GetHouseDescription : vou enviar descrição da casa com id:"+id);
            string oldname = "";
            switch (id)
            {
                case 0: oldname = "Casa1.xml"; break;
                case 1: oldname = "Casa2.xml"; break;
                default: break;
            }

            string dir = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
            string name = System.IO.Path.Combine(dir, oldname);
            var file = new StreamReader(name.Substring(6, name.Length - 6));
            string text = file.ReadToEnd();
            file.Close();
            return text;
        }

        public int Set(int RefDevice, int RefProperty, string Value)
        {
            Console.WriteLine("SET : Foi Alterada a propriedade:"+RefProperty+" do Device:"+RefDevice+" para o valor #"+Value);
            return 1;
        }

        public string Get(int RefDevice, int RefProperty)
        {
            Console.WriteLine("GET : Foi lida a propriedade:" + RefProperty + " do Device:" + RefDevice);
            
            return "1";
        }

        #endregion
    }
}
