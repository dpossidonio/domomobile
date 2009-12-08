using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomoMobile.Common
{
    public class House
    {
        public string Name { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
        public int ID { get; set; }

        public IList<User> Users { get; set; }
        public IList<Floor> Floors { get; set; }

        public IList<DeviceType> DeviceTypes { get; set; }
        public IList<Device> Devices { get; set; }
        public IList<PropertyValueType> PropertyValueTypes { get; set; }
        public IList<Conversion> Conversions { get; set; }
        public IList<Service> Services { get; set; }
        public IList<AccessLevel> AccessLevels { get; set; }


        public House()
        {
            Users = new List<User>();
            AccessLevels = new List<AccessLevel>();
            Floors = new List<Floor>();
            DeviceTypes = new List<DeviceType>();
            Devices = new List<Device>();
            PropertyValueTypes = new List<PropertyValueType>();
            Conversions = new List<Conversion>();
            Services = new List<Service>();
        }


    }
}
