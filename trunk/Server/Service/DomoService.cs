using System;
using System.IO;
using System.Reflection;

namespace Service
{
    partial class DomoService : IDomoService
    {
        string Name = "";
        public DomoService()
        {
        }
        #region IDomoService Members

        public string Echo() {
            Console.WriteLine("Echo");
            return "Echo";
        }

        public bool Login(string Token, string Password) {
            Console.WriteLine("Login: "+Token);
            //foreach (var item in Myhouse.Users)
            //{
            //    if (item.Username.ToString().Equals(Token) && item.Password.ToString().Equals(Password))
            //    return true;            
            //}
            //return false;

            Name = Token;
            return true;
        }

        public string[] GetHouses(string Token)
        {
            //See available houses
            Console.WriteLine("GetHouses : Casa de Campo, Apartamento Las Vegas, Casa Lisboa");
            return new string[] { "Casa de Campo"};
        }

        public string GetHouseDescription(string Token,int HouseId)
        {
            Console.WriteLine("GetHouseDescription : vou enviar descrição da casa com id:" + HouseId);
            string oldname = "";
            switch (HouseId)
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

        public int Set(string Token,int RefDevice, int RefProperty, string Value)
        {
            Console.WriteLine("SET : Foi Alterada a propriedade:"+RefProperty+" do Device:"+RefDevice+" para o valor #"+Value);
            return 1;
        }

        public string Get(string Token,int RefDevice, int RefProperty)
        {
            Console.WriteLine("GET : Foi lida a propriedade:" + RefProperty + " do Device:" + RefDevice);
            
            return "1";
        }

        #endregion
    }
}
