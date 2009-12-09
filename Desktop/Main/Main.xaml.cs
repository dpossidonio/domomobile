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
using System.Xml.Linq;
using DomoMobile.Common;
using System.Collections.ObjectModel;
using System.IO;
using PDA;

namespace Main
{
    public class Context
    {
        public string CurrentUser { get; set; }
        public House CurrentHouse { get; set; }
        public Device CurrentDevice { get; set; }
    }

    public interface IServiceProvider
    {
        string[] GetHouses();

        string GetHouseDescription(int HouseId);

        int Set(int RefProperty, string Value);

        string Get(int RefProperty);
    }

    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window, INotifyPropertyChanged, IServiceProvider
    {
        public Context CurrentContext { get; set; }

        public static IServiceProvider ServiceProvider
        {
            get;
            private set;
        }

        public string[] GetHouses()
        {
            var service = new DomoServiceClient();

            return service.GetHouses(GetToken());
        }

        public string GetHouseDescription(int HouseId)
        {
            var service = new DomoServiceClient();

            return service.GetHouseDescription(GetToken(), HouseId);
        }

        public int Set(int RefProperty, string Value)
        {
            var service = new DomoServiceClient();

            return service.Set(
                GetToken(), 
                CurrentContext.CurrentHouse.ID, 
                CurrentContext.CurrentDevice.ID, 
                RefProperty, 
                Value);
        }

        public string Get(int RefProperty)
        {
            var service = new DomoServiceClient();
            
            return service.Get(
                GetToken(),
                CurrentContext.CurrentHouse.ID,
                CurrentContext.CurrentDevice.ID,
                RefProperty);
        }

        private object _windowContent;
        public object WindowContent
        {
            get { return _windowContent; }
            set { _windowContent = value; Notify("WindowContent"); }
        }

        public Window1()
        {
            CurrentContext = new Context();
            ServiceProvider = this;
            InitializeComponent();

            this.DataContext = this;
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            var house = ReadHouseConfiguration("Casa1.xml");
            var selectScreen = new SelectScreenViewModel(CurrentContext);
            selectScreen.Items = new ObservableCollection<SelectionItem>();
            selectScreen.SetContent(
                new List<SelectionItem>() { 
                    new HouseSelectionItem(CurrentContext, null) { 
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

        private string GetToken()
        {
            return String.Empty;
        }
    }
}
