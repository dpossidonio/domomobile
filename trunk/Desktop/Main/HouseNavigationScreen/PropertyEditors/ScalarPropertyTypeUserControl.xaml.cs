using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using DomoMobile.Common;

namespace Main.UserControls
{
    /// <summary>
    /// Interaction logic for ScalarPropertyTypeUserControl.xaml
    /// </summary>
    public partial class ScalarPropertyTypeUserControl : UserControl, INotifyPropertyChanged, IPropertyEditor
    {
        private int _value;
        public int Value
        {
            get { return _value; }
            set { _value = value; Notify("Value");}
        }

        public ScalarPropertyTypeUserControl()
        {
            InitializeComponent();
        }

        public Context CurrentContext { get; set; }
        public IServiceManager ServiceManager { get; set; }

        public ScalarPropertyTypeUserControl(Context context, IServiceManager service, Property scalarPropertyType)
        {
            PropertyType = scalarPropertyType.Type;
            ScalarValue = ((ScalarValueType) PropertyType.ValueType);
            CurrentContext = context;
            ServiceManager = service;
            this.DataContext = this;
            string val = ServiceManager.Get(PropertyType.ID);
            Value = int.Parse(val);

            InitializeComponent();
        }

        public PropertyType PropertyType { get; set; }
        public ScalarValueType ScalarValue { get; set; }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        public void Notify(string propname)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propname));
        }

        public void SaveChanges()
        {
            ServiceManager.Set(PropertyType.ID, Value.ToString());
        }
    }
}
