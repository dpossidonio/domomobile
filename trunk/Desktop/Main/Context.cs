using DomoMobile.Common;

namespace Main
{
    public class Context
    {
        public string Endpoint { get; set; }

        public string CurrentUser { get; set; }
        public House CurrentHouse { get; set; }
        public Device CurrentDevice { get; set; }
        public PropertyType CurrentPropertyType { get; set; }

        public Context()
        {
            CurrentUser = "David";
        }
    }
}