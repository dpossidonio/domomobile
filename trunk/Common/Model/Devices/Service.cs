using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomoMobile.Common
{
    public class Service
    {
        public Service()
        {
            Devices = new List<Device>();
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public IList<Device> Devices { get; set; }

    }
}
