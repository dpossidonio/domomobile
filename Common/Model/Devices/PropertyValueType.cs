using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DomoMobile.Common
{

    public abstract class PropertyValueType
    {
        public int ID { get; set; }
        public string Name { get; set; }

    }

    public class ScalarValueType : PropertyValueType
    {
        public Scalar TypeOfValue { get; set; }
    }


    public class EnumeratedValueType : PropertyValueType
    {
        public IList<Enumerated> TypeOfValue { get; set; }
    }

    public class VectorValueType : PropertyValueType
    {
        public Vector TypeOfValue { get; set; }
    }

    


    public class Scalar
    {
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
        public int NumBits { get; set; }
        public int Step { get; set; }
        public string Units { get; set; }
        public Conversion Expressions { get; set; }
    }

    public class Vector
    {
        
        public int Size { get; set; }
        public Conversion Expressions { get; set; }
    }

    public class Enumerated
    {
        public string Description { get; set; }
        public string Value { get; set; }
    }

    public abstract class Conversion {
        public int ID { get; set; }
        public string Name { get; set; }
        public int DecimalPlaces { get; set; }

    }

    public class ConversionObject : Conversion
    {
        public string UserToSystemObj { get; set; }
        public string SystemToUserObj { get; set; }
    }


    public class ConversionFormula : Conversion
    {
        public string UserToSystem { get; set; }
        public string SystemToUser { get; set; }
    }
}
