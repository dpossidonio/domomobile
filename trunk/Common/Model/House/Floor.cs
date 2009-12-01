using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomoMobile.Common
{
    public class Floor
    {
        public Floor()
        {
            Divisions = new List<Division>();
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public string HeightOrder { get; set; }
        public IList<Division> Divisions { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
