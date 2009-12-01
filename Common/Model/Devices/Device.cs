using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomoMobile.Common
{
    /// <summary>
    /// This class represents a Device
    /// </summary>
    public class Device 
    {
        /// <summary>
        /// Name of device
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// ID of device
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Fisical address of device #DOMOBus
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Access Level Monitorization
        /// </summary>
        public int MonitorizationAcessLevel { get; set; }
        /// <summary>
        /// Access Level Monitorization
        /// </summary>
        public int CommandAcessLevel { get; set; }
        /// <summary>
        /// ID of the Blocker : command fuctions
        /// </summary>
        public int CommandBlockID { get; set; }
        /// <summary>
        /// ID of the Blocker :Monitorization fuctions
        /// </summary>
        public int MonitorizationBlockID { get; set; }
        /// <summary>
        /// Device Type I
        /// </summary> 
        public DeviceType MyDeviceType { get; set; }
        /// <summary>
        /// Property List
        /// </summary>       
        public IList<Property> Properties { get; set; }

        public Device()
        {
            Properties = new List<Property>();
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
