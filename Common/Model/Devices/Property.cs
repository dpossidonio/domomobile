using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomoMobile.Common
{
    public class Property
    {
        public PropertyType Type { get; set; }
        public String Value { get; set; }

        public override string ToString()
        {
            return Type.Name;
        }

    }
}
