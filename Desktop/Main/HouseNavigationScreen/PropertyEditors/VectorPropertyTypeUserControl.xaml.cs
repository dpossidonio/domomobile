using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using DomoMobile.Common;

namespace Main.UserControls
{
    /// <summary>
    /// Interaction logic for VectorPropertyTypeUserControl.xaml
    /// </summary>
    public partial class VectorPropertyTypeUserControl : UserControl, IPropertyEditor, INotifyPropertyChanged
    {
        private string _value;
        public string Value
        {
            get { return _value; }
            set { _value = value;
                Notify("Value"); }
        }

        public VectorPropertyTypeUserControl()
        {
            InitializeComponent();
        }

        public Context CurrentContext { get; set; }
        public IServiceManager ServiceManager { get; set; }

        public PropertyType PropertyType { get; set; }

        public VectorPropertyTypeUserControl(Context context, IServiceManager service, Property vectorValueType)
        {
            CurrentContext = context;
            ServiceManager = service;
            PropertyType = (PropertyType)(vectorValueType.Type);
            this.DataContext = this;
            InitializeComponent();
            string val = ServiceManager.Get(PropertyType.ID);
            Value = val;
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        public void Notify(string propname)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propname));
        }

        #region IPropertyEditor Members

        public void SaveChanges()
        {
            ServiceManager.Set(PropertyType.ID, Value);
        }

        #endregion
    }
}
