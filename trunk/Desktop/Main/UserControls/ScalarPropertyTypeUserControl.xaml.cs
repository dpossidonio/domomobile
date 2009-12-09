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
    public partial class ScalarPropertyTypeUserControl : UserControl, INotifyPropertyChanged
    {
        public Context CurrentContext { get; set; }

        public ScalarPropertyTypeUserControl()
        {
            InitializeComponent();
        }

        public ScalarPropertyTypeUserControl(Context context, Property scalarPropertyType)
        {
            CurrentContext = context;
            this.DataContext = this;
            ScalarPropertyType = (ScalarValueType)(scalarPropertyType.Type.ValueType);

            InitializeComponent();
        }

        public ScalarValueType ScalarPropertyType { get; set; }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        public void Notify(string propname)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propname));
        }
    }
}
