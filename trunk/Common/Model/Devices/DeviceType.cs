using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomoMobile.Common
{
    public class DeviceType
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public IList<PropertyType> PropertyTypes { get; set; }
    }
}
