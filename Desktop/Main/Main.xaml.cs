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
using Main.ViewModels;
using PDA;
using System.Xml.Linq;
using DomoMobile.Common;
using System.Collections.ObjectModel;
using System.IO;

namespace Main
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window, INotifyPropertyChanged
    {

        private object _windowContent;
        public object WindowContent
        {
            get { return _windowContent; }
            set { _windowContent = value; Notify("WindowContent"); }
        }

        public Window1()
        {
            InitializeComponent();

            this.DataContext = this;
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            var house = ReadHouseConfiguration("Casa1.xml");
            var selectScreen = new SelectScreenViewModel();
            selectScreen.Items = new ObservableCollection<SelectionItem>();
            selectScreen.SetContent(
                new List<SelectionItem>() { 
                    new HouseSelectionItem(null) { 
                        House = house 
                    }  
                }, null);

            WindowContent = selectScreen;
        }

        private House ReadHouseConfiguration(string filename)
        {
            Parser p = new Parser();
            //string path = p.GetXmlFilePath(filename);
            FileInfo f = new FileInfo(filename);
            var doc = XDocument.Load(f.FullName);
            return p.getHouse(doc);
        }
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
