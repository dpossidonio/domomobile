using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Xml.Linq;
using DomoMobile.Common;
using Main.ServiceProxy;
using Main.ViewModels;
using PDA;

namespace Main
{
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

        private IDomoService _service;
        public IDomoService Service
        {
            get { return _service ?? (_service = new DomoServiceClient()); }
            set { _service = value; }
        }

        public string[] GetHouses()
        {
            return Service.GetHouses(GetToken());
        }

        public string GetHouseDescription(int houseId)
        {
            return Service.GetHouseDescription(GetToken(), houseId);
        }

        public int Set(int refProperty, string value)
        {
            return Service.Set(
                GetToken(), 
                CurrentContext.CurrentHouse.ID, 
                CurrentContext.CurrentDevice.ID, 
                refProperty, 
                value);
        }

        public string Get(int refProperty)
        {
            return Service.Get(CurrentContext.CurrentUser, CurrentContext.CurrentHouse.ID, CurrentContext.CurrentDevice.ID, refProperty);
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

            DataContext = this;
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            var house = ReadHouseConfiguration("Casa1.xml");
            var selectScreen = new SelectScreenViewModel(CurrentContext)
                                   {
                                       Items = new ObservableCollection<SelectionItem>()
                                   };

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
            return CurrentContext.CurrentUser;
        }
    }
}
