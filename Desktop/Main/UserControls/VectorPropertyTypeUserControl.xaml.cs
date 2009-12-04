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
using DomoMobile.Common;

namespace Main.UserControls
{
    /// <summary>
    /// Interaction logic for VectorPropertyTypeUserControl.xaml
    /// </summary>
    public partial class VectorPropertyTypeUserControl : UserControl
    {
        public VectorValueType VectorValueType { get; set; }

        public VectorPropertyTypeUserControl(Property vectorValueType)
        {
            VectorValueType = (VectorValueType)(vectorValueType.Type.ValueType);
            this.DataContext = this;
            InitializeComponent();
        }
    }
}
