using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using System.Reflection;
using DomoMobile.Common;

namespace PDA
{
    public class Parser
    {

        /// <summary>
        /// Returns the complete path of the XML document.
        /// </summary>
        /// <returns></returns>
        public string GetXmlFilePath(string oldname)
        {
            //Assembly.GetExecutingAssembly().GetName().CodeBase return the full path of the current executing assembly
            string dir = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
            string name = System.IO.Path.Combine(dir, oldname);
            return name;
        }

        /// <summary>
        /// Returns the complete Home Description present on the xml file.
        /// </summary>
        /// <returns></returns>
        public House getHouse(XDocument xd)
        {
            var h = xd.Root.Element("House");
            var house = new House();

            house.ID = int.Parse(h.Attribute("ID").Value);
            house.Name = h.Attribute("Name").Value;
            house.Adress = h.Attribute("Address").Value;
            house.PhoneNumber = h.Attribute("Phone").Value;

            getAccessLevels(house, xd);
            readFloors(house, h);
            getConversions(house, xd);
            getHouseUsers(house, xd);
            getValueTypes(house, xd);
            getDeviceTypes(house, xd);
            getServices(house, xd);
            getDevices(house, xd);

            return house;
        }

        /// <summary>
        /// Reads the access Levels
        /// </summary>
        /// <returns></returns>
        public void getAccessLevels(House house, XDocument xd)
        {
            foreach (var item in xd.Root.Element("AccessLevelList").Elements("AccessLevel"))
            {
                var acl = new AccessLevel();
                acl.Level = int.Parse(item.Attribute("Level").Value);
                acl.Name = item.Attribute("Name").Value;
                house.AccessLevels.Add(acl);
            }
        }

        /// <summary>
        /// Reads the Converions of the Value Types
        /// </summary>
        /// <returns></returns
        public void getConversions(House house, XDocument xd)
        {
            foreach (var item in xd.Root.Element("ConversionFormulaList").Elements("ConversionFormula"))
            {
                var conv = new ConversionFormula();
                conv.ID = int.Parse(item.Attribute("ID").Value);
                conv.Name = item.Attribute("Name").Value;
                conv.SystemToUser = item.Attribute("SystemToUser").Value;
                conv.UserToSystem = item.Attribute("UserToSystem").Value;
                conv.DecimalPlaces = int.Parse(item.Attribute("DecimalPlaces").Value);
                house.Conversions.Add(conv);
            }
            foreach (var item in xd.Root.Element("ConversionObjectList").Elements("ConversionObject"))
            {
                var conv = new ConversionObject();
                conv.ID = int.Parse(item.Attribute("ID").Value);
                conv.Name = item.Attribute("Name").Value;
                conv.SystemToUserObj = item.Attribute("SystemToUserObj").Value;
                conv.UserToSystemObj = item.Attribute("UserToSystemObj").Value;
                conv.DecimalPlaces = int.Parse(item.Attribute("DecimalPlaces").Value);
                house.Conversions.Add(conv);
            }
        }

        /// <summary>
        /// Reads the Value Types
        /// </summary>
        /// <returns></returns
        private void getValueTypes(House house, XDocument xd)
        {
            // Scalar Types
            foreach (var item in xd.Root.Element("ScalarValueTypeList").Elements("ScalarValueType"))
            {
                var scalarType = new ScalarValueType();
                var scalar = new Scalar();

                scalarType.ID = int.Parse(item.Attribute("ID").Value);
                scalarType.Name = item.Attribute("Name").Value;
                scalar.MaxValue = int.Parse(item.Attribute("MaxValue").Value);
                scalar.MinValue = int.Parse(item.Attribute("MinValue").Value);
                scalar.NumBits = int.Parse(item.Attribute("NumBits").Value);
                scalar.Step = int.Parse(item.Attribute("Step").Value);
                scalar.Units = item.Attribute("Units").Value;
                scalarType.TypeOfValue = scalar;
                ///Conversion  
                var tipoConv = item.Element("ValueConversion").Attribute("Type").Value;
                if (!tipoConv.Equals("NONE"))
                {
                    var convID = int.Parse(item.Element("ValueConversion").Attribute("Ref").Value);
                    if (tipoConv.Equals("FORMULA"))
                        scalar.Expressions = house.Conversions.First(x => x is ConversionFormula && x.ID == convID);
                    else if (tipoConv.Equals("OBJECT"))
                        scalar.Expressions = house.Conversions.First(x => x is ConversionObject && x.ID == convID);
                }

                house.PropertyValueTypes.Add(scalarType);
            }
            //// Enum Types
            foreach (var enumt in xd.Root.Element("EnumValueTypeList").Elements("EnumValueType"))
            {
                var enumtType = new EnumeratedValueType();
                enumtType.TypeOfValue = new List<Enumerated>();
                enumtType.ID = int.Parse(enumt.Attribute("ID").Value);
                enumtType.Name = enumt.Attribute("Name").Value;

                foreach (var enumerated in enumt.Elements("Enumerated"))
                {
                    var enumtValue = new Enumerated();
                    enumtValue.Value = enumerated.Attribute("Value").Value;
                    enumtValue.Description = enumerated.Attribute("Description").Value;
                    enumtType.TypeOfValue.Add(enumtValue);
                }
                house.PropertyValueTypes.Add(enumtType);
            }
            //// Vector Types
            foreach (var item in xd.Root.Element("ArrayValueTypeList").Elements("ArrayValueType"))
            {
                var vectorType = new VectorValueType();
                var vector = new Vector();

                vector.Size = int.Parse(item.Attribute("MaxLen").Value);
                vectorType.ID = int.Parse(item.Attribute("ID").Value);
                vectorType.Name = item.Attribute("Name").Value;
                vectorType.TypeOfValue = vector;
                var tipoConv = item.Element("ValueConversion").Attribute("Type").Value;

                if (!tipoConv.Equals("NONE"))
                {
                    var convID = int.Parse(item.Element("ValueConversion").Attribute("Ref").Value);
                    if (tipoConv.Equals("FORMULA"))
                        vector.Expressions = house.Conversions.First(x => x is ConversionFormula && x.ID == convID);
                    else if (tipoConv.Equals("OBJECT"))
                        vector.Expressions = house.Conversions.First(x => x is ConversionObject && x.ID == convID);
                }
                house.PropertyValueTypes.Add(vectorType);
            }
        }

        /// <summary>
        /// Reads the Device Types
        /// </summary>
        /// <returns></returns
        private void getDeviceTypes(House house, XDocument xd)
        {
            foreach (var devtype in xd.Root.Element("DeviceTypeList").Elements("DeviceType"))
            {
                var deviceType = new DeviceType();
                deviceType.PropertyTypes = new List<PropertyType>();

                deviceType.ID = int.Parse(devtype.Attribute("ID").Value);
                deviceType.Name = devtype.Attribute("Name").Value;
                foreach (var proptype in devtype.Element("PropertyTypeList").Elements("PropertyType"))
                {
                    var prop = new PropertyType();
                    prop.ID = int.Parse(proptype.Attribute("ID").Value);
                    prop.Name = proptype.Attribute("Name").Value;

                    var am = Enum.Parse(typeof(PropertyType.AcessModes), proptype.Attribute("AccessMode").Value, true);
                    prop.AcessMode = (PropertyType.AcessModes)am;

                    var valueType = Enum.Parse(typeof(PropertyType.TypeOfValues), proptype.Attribute("ValueType").Value, true);
                    prop.TypeOfValue = (PropertyType.TypeOfValues)am;

                    var refID = int.Parse(proptype.Attribute("RefValueType").Value);

                    Console.WriteLine(valueType.ToString() + " + " + prop.TypeOfValue);

                    if (valueType.ToString().Equals("SCALAR"))
                        prop.ValueType = house.PropertyValueTypes.First(x => x is ScalarValueType && x.ID == refID);

                    else if (valueType.ToString().Equals("ENUM"))
                        prop.ValueType = house.PropertyValueTypes.First(x => x is EnumeratedValueType && x.ID == refID);

                    else if (valueType.ToString().Equals("VECTOR"))
                        prop.ValueType = house.PropertyValueTypes.First(x => x is VectorValueType && x.ID == refID);

                    deviceType.PropertyTypes.Add(prop);
                }
                house.DeviceTypes.Add(deviceType);
            }
        }

        /// <summary>
        /// Reads the Devices
        /// </summary>
        /// <returns></returns
        private void getDevices(House house, XDocument xd)
        {

            foreach (var item in xd.Root.Element("DeviceList").Elements("Device"))
            {
                var dev = new Device();
                dev.ID = int.Parse(item.Attribute("ID").Value);
                dev.Name = item.Attribute("Name").Value;

                var c = item.Attribute("AccessLevel").Value.Split(',');
                dev.MonitorizationAcessLevel = int.Parse(c[0]);
                if (c.Length > 1)
                    dev.CommandAcessLevel = int.Parse(c[1]);
                else
                    dev.CommandAcessLevel = int.Parse(c[0]);

                dev.Address = item.Attribute("Address").Value;
                var userBlock = item.Attribute("UserBlocked").Value.Split(',');

                if (userBlock[0].Equals('-'))
                    dev.MonitorizationBlockID = int.Parse(userBlock[0]);
                if (userBlock.Length > 1 && userBlock[1].Equals('-'))
                    dev.CommandBlockID = int.Parse(userBlock[1]);
                else if (userBlock.Length == 1)
                    dev.CommandBlockID = int.Parse(userBlock[0]);

                var divisionID = int.Parse(item.Attribute("RefDivision").Value);
                var division = (from a in house.Floors
                                from d in a.Divisions
                                where d.ID == divisionID
                                select d).First();
                division.Devices.Add(dev);

                foreach (var item2 in item.Element("DeviceServiceList").Elements("DeviceService"))
                {
                    int servID = int.Parse(item2.Attribute("RefService").Value);
                    var service = (from a in house.Services
                                   where a.ID == servID
                                   select a).First();
                    service.Devices.Add(dev);
                }
            }
        }

        /// <summary>
        /// Reads the Services
        /// </summary>
        /// <returns></returns
        private void getServices(House house, XDocument xd)
        {
            foreach (var item in xd.Root.Element("ServiceList").Elements("Service"))
            {
                var serv = new Service();
                serv.ID = int.Parse(item.Attribute("ID").Value);
                serv.Name = item.Attribute("Name").Value;
                house.Services.Add(serv);
            }
        }

        private void getHouseUsers(House house, XDocument xd)
        {
            foreach (var user in xd.Root.Element("UserList").Elements("User"))
            {
                var usr = new User();
                usr.Username = user.Attribute("Name").Value;
                usr.UserID = int.Parse(user.Attribute("ID").Value);
                usr.AcessLevel = int.Parse(user.Attribute("AccessLevel").Value);
                usr.Password = user.Attribute("Password").Value;
                house.Users.Add(usr);
            }
        }


        /// <summary>
        /// Reads the Floors of the House
        /// </summary>
        /// <returns></returns
        private void readFloors(House house, XElement floor)
        {
            foreach (var item in floor.Element("FloorList").Elements("Floor"))
            {
                var f = new Floor();
                f.Name = item.Attribute("Name").Value;
                f.ID = int.Parse(item.Attribute("ID").Value);
                f.HeightOrder = item.Attribute("HeightOrder").Value;
                readDivisions(f, item);
                house.Floors.Add(f);
            }
        }

        /// <summary>
        /// Reads the Divisions of the House
        /// </summary>
        /// <returns></returns
        private void readDivisions(Floor f, XElement floor)
        {
            foreach (var division in floor.Element("DivisionList").Elements("Division"))
            {
                Division d = new Division();

                d.ID = int.Parse(division.Attribute("ID").Value);
                d.AcessLevel = int.Parse(division.Attribute("AccessLevel").Value);
                d.Name = division.Attribute("Name").Value;
                f.Divisions.Add(d);
            }
        }
    }
}
