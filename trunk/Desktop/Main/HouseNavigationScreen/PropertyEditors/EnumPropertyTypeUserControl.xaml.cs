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
using System.Collections.ObjectModel;

namespace Main.UserControls
{
    /// <summary>
    /// Interaction logic for ScalarPropertyTypeUserControl.xaml
    /// </summary>
    public partial class EnumPropertyTypeUserControl : UserControl, INotifyPropertyChanged, IPropertyEditor
    {
        public Context CurrentContext { get; set; }
        public IServiceManager ServiceManager { get; set; }

        public EnumPropertyTypeUserControl()
        {
            InitializeComponent();
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);       
            string val = ServiceManager.Get(PropertyType.ID);
            SetSelectedItem(val);
        }

        private ObservableCollection<Enumerated> _items;
        public ObservableCollection<Enumerated> Items
        {
            get { return _items; }
            set { _items = value; Notify("Items"); }

        }

        public EnumPropertyTypeUserControl(Context context, IServiceManager service, Property enumPropertyType)
        {
            CurrentContext = context;
            ServiceManager = service;
            DataContext = this;
            PropertyType = (PropertyType)(enumPropertyType.Type);
            Items = new ObservableCollection<Enumerated>(((EnumeratedValueType)(PropertyType.ValueType)).TypeOfValue);

            InitializeComponent();
        }

       
        public PropertyType PropertyType { get; set; }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        public void Notify(string propname)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propname));
        }

        private Enumerated _selectedItem;
        public Enumerated SelectedItem
        {
            get { return _selectedItem; }
            set { _selectedItem = value; Notify("SelectedItem");}
        }

        private void SetSelectedItem(string value)
        {
            foreach (var item in Items)
            {
                if ((item as Enumerated).Value.Equals(value))
                {
                    SelectedItem = item;
                    break;
                }

            }
        }

        public void SaveChanges()
        {
           ServiceManager.Set(PropertyType.ID, SelectedItem.Value);
        }
    }
}
