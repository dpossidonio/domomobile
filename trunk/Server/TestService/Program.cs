using System.IO;
using System.Reflection;
using System.Xml.Linq;
using DomoMobile.Common;
using ServerStateSimulation;


namespace TestService
{
    public class Program
    {
        static void Main(string[] args)
        {
            ParseState c = new ParseState();
            string name = c.GetXmlFilePath("CasaState1.xml");

            //Load the received xml document
            XDocument doc = XDocument.Load(name);
            House a = c.getHouse(doc);
            ;
        }
    }
}
