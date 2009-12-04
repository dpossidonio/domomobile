using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomoMobile.Common;
using PDA;
using System.Xml.Linq;

namespace Service
{
    partial class DomoService : IDomoService
    {
        private static IList<House> Houses { get; set; }
        private static House House { get; set; }

        static DomoService()
        {
            Houses = new List<House>();
            House = new House();
            Parser p = new Parser();
            string filePath = p.GetXmlFilePath("Casa1.xml");

            XDocument doc = XDocument.Load(filePath);
            House = p.getHouse(doc);
        }

    }
}
