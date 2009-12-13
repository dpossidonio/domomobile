using System;
using System.Windows.Controls;
using DomoMobile.Common;
using Main.UserControls;

namespace Main.ViewModels
{
    public static class PropertyTypeUserControlFactory
    {
        public static UserControl GetUserControl(Context context, IServiceManager service, Property prop)
        {
            if (prop.Type.TypeOfValue == PropertyType.TypeOfValues.ENUM)
            {
                return new EnumPropertyTypeUserControl(context, service, prop);
            }
            else if (prop.Type.TypeOfValue == PropertyType.TypeOfValues.SCALAR)
            {
                return new ScalarPropertyTypeUserControl(context, service, prop);
            }
            else if (prop.Type.TypeOfValue == PropertyType.TypeOfValues.VECTOR)
            {
                return new VectorPropertyTypeUserControl(context, service, prop);
            }
            else
            {
                throw new Exception("PropertyTypeNotSuported by PropertyTypeUserControlFactory");
            }
        }
    }
}