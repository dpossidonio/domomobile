using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomoMobile.Common;
using System.Xml.Linq;
using ServerStateSimulation;

namespace Service
{
    partial class DomoService : IDomoService
    {
        private static Dictionary<int, House> Houses { get; set; }
        private static Dictionary<int, string> HouseFilePath { get; set; }

        static DomoService()
        {
            Houses = new Dictionary<int, House>();
            HouseFilePath = new Dictionary<int,string>();
            //Parser p = new Parser();
            string filePath;
            string descriptionfilePath;
            //TODO
            int NUMBER_OF_AVAILABLE_HOUSES = 1;

            for (int i = 1; i < NUMBER_OF_AVAILABLE_HOUSES + 1; i++)
            {
                //Console.WriteLine("Vou ler o ficheiro:" + string.Format("Casa{0}.xml", i));
                //filePath = p.GetXmlFilePath(string.Format("Casa{0}.xml", i));
                //XDocument doc = XDocument.Load(filePath);
                //try
                //{
                //    AddHouse(p.getHouse(doc),filePath);    
                //}
                //catch (Exception e)
                //{
                //    Console.WriteLine("The given source does not contain a house description.");
                //}

                // Emulationg the House state 
                try
                {
                    ParseState c = new ParseState();
                    filePath = c.GetXmlFilePath("StateSimulation\\CasaState1.xml");
                    descriptionfilePath = c.GetXmlFilePath("HouseDescriptions\\Casa1.xml");

                    XDocument doc = XDocument.Load(filePath);
                    AddHouse(c.getHouse(doc), descriptionfilePath);   
                }
                catch (Exception e) {
                    Console.WriteLine("The given source does not contain a house description.");
                }
            }
        }
        private static void AddHouse(House house,string fp)
        {
            Houses.Add(house.ID, house);
            HouseFilePath.Add(house.ID,fp);
        }
        private static int UserAccessLevel(string Username, int houseId) {
            return Houses[houseId].Users.First(x => x.Username.ToString().Equals(Username)).AcessLevel;
        }
    }
}
