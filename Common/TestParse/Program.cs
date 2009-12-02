using System;
using System.Collections.Generic;
using System.Linq;
using PDA;
using System.Xml.Linq;
using DomoMobile.Common;


namespace TestParse
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser c = new Parser();
            string name = c.GetXmlFilePath("Casa1.xml");

            //Load the received xml document
            XDocument doc = XDocument.Load(name);
            House a = c.getHouse(doc);
            ;
        }
    }
}
