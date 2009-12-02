using System.IO;
using System.Reflection;
namespace TestService
{
    public class Program
    {
        public static string GetHouseDescription(int id)
        {
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

        static void Main(string[] args)
        {
            System.Console.WriteLine(GetHouseDescription(0));
            System.Console.ReadLine();

        }
    }
}
