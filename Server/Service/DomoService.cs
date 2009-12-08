using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using DomoMobile.Common;

namespace Service
{
    partial class DomoService : IDomoService
    {
        #region IDomoService Members

        public string Echo() {
            Console.WriteLine("Echo");
            return "Echo";
        }

        public bool Login(string Username, string Password) {
            foreach (var house in Houses)
            {
                foreach (var user in house.Value.Users)
                {
                    if (user.Username.ToString().Equals(Username) && user.Password.ToString().Equals(Password))
                    {
                        Console.WriteLine("Login: " + Username);
                        return true;
                    }
                }
            }
            Console.WriteLine("Login not valid for username: " + Username);
            return false;
        }

        /// <summary>
        /// Return a string[] with name of houses
        /// </summary>
        /// <param name="Token"></param>
        /// <returns>
        /// string[odd] - Description
        /// string[even] - Id
        /// </returns>
        public string[] GetHouses(string Token)
        {
            //See available houses
            var houseNames = new List<string>();
            Console.Write("GetHouses: ");
            foreach (var house in Houses)
            {
                foreach (var user in house.Value.Users)
                {
                    if (user.Username.ToString().Equals(Token))
                    {
                        houseNames.Add(house.Value.Name);
                        houseNames.Add(string.Format("{0}", house.Key));
                        Console.Write(house.Value.Name);
                    }
                }
            }
            Console.WriteLine("");
            return houseNames.ToArray();

        }
        
        public string GetHouseDescription(string Token,int HouseId)
        {
            Console.WriteLine("GetHouseDescription : vou enviar descrição da casa com ID:" + HouseId);
            string filepath = HouseFilePath[HouseId].Substring(6, HouseFilePath[HouseId].Length - 6);
            var file = new StreamReader(filepath);
            string text = file.ReadToEnd();
            file.Close();
            return text;
        }

        /// <summary>
        ///   Set a new value of a property to a given device
        /// </summary>
        /// <param name="Token"></param>
        /// <param name="HouseId"></param>
        /// <param name="RefDevice"></param>
        /// <param name="RefProperty"></param>
        /// <param name="Value"></param>
        /// <returns>
        ///  0 - Can't Connect to Device
        ///  1 - Property Sucessefuly changed
        ///  2 - Permission denied
        ///  3 - Property ReadOnly
        /// </returns>
        public int Set(string Token, int HouseId, int RefDevice, int RefProperty, string Value)
        {
            int userAccessLevel = UserAccessLevel(Token, HouseId);
            Console.WriteLine("User access level is :"+userAccessLevel);
            var dev = Houses[HouseId].Devices.First(x => x.ID == RefDevice);
            var prop = dev.Properties.First(x => x.Type.ID == RefProperty);
            var blockLevel = 0;
            if (dev.CommandBlockID > 0)
                blockLevel = Houses[HouseId].Users.First(x => x.UserID.Equals(dev.CommandBlockID)).AcessLevel;

            if (dev.CommandAcessLevel > userAccessLevel || blockLevel > userAccessLevel)
            {
                Console.WriteLine("SET : Não tem permissoes para alterar a propriedade. Nivel :{0} Nivel requerido: {1}",userAccessLevel,dev.CommandAcessLevel);
                return 2;
            }

            if (prop.Type.AcessMode.Equals(PropertyType.AcessModes.RO))
            {
                Console.WriteLine("SET : O Modo suportado para a propriedade :{0} do dispositivo :{1} é apenas Leitura.",prop.Type.ID,dev.ID);
                return 3;
            }
            //connect to device
            //DomoBus-SET(Ref,Ref,Value)
            //if('no response')
            // return 0
            //else
            prop.Value = Value;
            Console.WriteLine("SET : Foi Alterada a propriedade:"+RefProperty+" do Device:"+RefDevice+" para o valor #"+Value);
            return 1;
        }

        /// <summary>
        ///   get the value of a property to a given device
        /// </summary>
        /// <param name="Token"></param>
        /// <param name="HouseId"></param>
        /// <param name="RefDevice"></param>
        /// <param name="RefProperty"></param>
        /// <param name="Value"></param>
        /// <returns>
        ///  "#0" - Can't Connect to Device
        ///  "#1" - Permission denied
        ///  "#2" - Property Write Only
        ///"value" - the value of the property
        /// </returns>
        /// 
        public string Get(string Token, int HouseId, int RefDevice, int RefProperty)
        {
            int userAccessLevel = UserAccessLevel(Token, HouseId);
            Console.WriteLine("User access level is :" + userAccessLevel);
            var dev = Houses[HouseId].Devices.First(x => x.ID == RefDevice);
            var prop = dev.Properties.First(x => x.Type.ID == RefProperty);
            var blockLevel = 0;

            if (dev.MonitorizationBlockID > 0)
                blockLevel = Houses[HouseId].Users.First(x => x.UserID.Equals(dev.MonitorizationBlockID)).AcessLevel;

            if (dev.MonitorizationAcessLevel > userAccessLevel || blockLevel > userAccessLevel)
            {
                Console.WriteLine("GET : Não tem permissoes para visualizar o valor da propriedade.");
                return "#1";
            }

            //if (prop.Type.AcessMode.Equals(PropertyType.AcessModes.WO))
            //{
            //    Console.WriteLine("SET : O Modo suportado para a propriedade :{0} do dispositivo :{1} é apenas Escrita.", prop.Type.ID, dev.ID);
            //    return "#2";
            //}
            //TODO : connect to device
            //DomoBus-SET(Ref,Ref,Value)
            //if('no response')
            // return 0
            //else
            Console.WriteLine("GET : Foi lida a propriedade:" + RefProperty + " do Device:" + RefDevice);
            return prop.Value;
        }
        #endregion
    }
}
