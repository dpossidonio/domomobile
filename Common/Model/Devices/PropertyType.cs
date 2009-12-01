using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace DomoMobile.Common
{
    public class PropertyType
    {
        public enum AcessModes {RO,WO,RW}
        public enum TypeOfValues { SCALAR, ENUM, VECTOR }

        public int ID { get; set; }
        public string Name { get; set; }
        public AcessModes AcessMode { get; set; }
        public TypeOfValues TypeOfValue { get; set; }
        public PropertyValueType ValueType { get; set; }

    }


}
