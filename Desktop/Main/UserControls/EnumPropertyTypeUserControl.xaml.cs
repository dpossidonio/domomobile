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
using System.Collections.ObjectModel;
using System.ComponentModel;
using DomoMobile.Common;

namespace Main.UserControls
{
    /// <summary>
    /// Interaction logic for EnumPropertyType.xaml
    /// </summary>
    public partial class EnumPropertyTypeUserControl : UserControl, INotifyPropertyChanged
    {
        //private Enumerated _selectedItem;
        //public Enumerated SelectedItem
        //{
        //    get { return _selectedItem; }
        //    set { _selectedItem = value; Notify("SelectedItem"); }
        //}

        private ObservableCollection<Enumerated> _items;
        public ObservableCollection<Enumerated> Items
        {
            get { return _items; }
            set { _items = value; Notify("Items"); }
        }

        public EnumPropertyTypeUserControl(Property enumPropertyType)
        {
            this.DataContext = this;
            EnumPropertyType = (EnumeratedValueType)(enumPropertyType.Type.ValueType);
            Items = new ObservableCollection<Enumerated>(EnumPropertyType.TypeOfValue);

            //InitializeComponent();
        }

        public EnumeratedValueType EnumPropertyType { get; set; }

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
