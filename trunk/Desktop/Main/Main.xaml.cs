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
    public partial class Window1 : Window, INotifyPropertyChanged, IServiceManager, IWindowManager
    {
        public Context CurrentContext { get; set; }

        #region IServiceManager

        private IDomoService _service;
        public IDomoService Service
        {
            get
            {
                if (_service == null)
                    _service = GetServiceInstance();
                return _service;
            }
            protected set { 
                _service = value; 
            }
        }

        private IDomoService GetServiceInstance()
        {
            if(String.IsNullOrEmpty(CurrentContext.Endpoint))
            {
                return new DomoServiceClient();
            }
            else
            {
                return new DomoServiceClient("BasicHttpBinding_IDomoService", CurrentContext.Endpoint);
            }
        }

        private string GetToken()
        {
            return CurrentContext.CurrentUser;
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

        public bool Login(string username, string password)
        {
            return Service.Login(username, password);
        }

        #endregion

        #region IWindowManager

        public void ChangeScreen<T>() where T : Screen
        {
            var screen = Activator.CreateInstance(typeof (T), CurrentContext, this, this);

            WindowContent = screen;
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        public void Notify(string propname)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propname));
        }

        #endregion

        private object _windowContent;
        public object WindowContent
        {
            get { return _windowContent; }
            set { _windowContent = value; Notify("WindowContent"); }
        }

        public Window1()
        {
            CurrentContext = new Context();
            InitializeComponent();
            DataContext = this;
            Service = null;
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            var loginScreen = new LoginScreenViewModel(CurrentContext, this, this);

            //var selectScreen = new SelectScreenViewModel(CurrentContext)
            //                       {
            //                           Items = new ObservableCollection<SelectionItem>()
            //                       };

            //selectScreen.SetContent(
            //    new List<SelectionItem>() { 
            //        new HouseSelectionItem(CurrentContext, null) { 
            //            House = house 
            //        }  
            //    }, null);

            WindowContent = loginScreen;
        }
    }
}
