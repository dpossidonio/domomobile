using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Xml.Linq;
using DomoMobile.Common;
using PDA;

namespace Main.ViewModels
{
    public class HouseSelectionViewModel:Screen
    {
        public HouseSelectionViewModel(Context context, IServiceManager service, IWindowManager window)
            :base(context, service, window)
        {
            Houses = new ObservableCollection<string>(service.GetHouses());
            SelectedHouse = Houses.First();

            var cmd = new Action(
                delegate()
                    {
                        int id = int.Parse(SelectedHouse.Split(':')[0]);

                        string definition = ServiceManager.GetHouseDescription(id);
                        var p = new Parser();
                        var doc = XDocument.Parse(definition);
                        House house = p.getHouse(doc);

                        CurrentContext.CurrentHouse = house;

                        WindowManager.ChangeScreen<SelectScreenViewModel>();
                    });
            SelectHouseCommand = new DelegateCommand(cmd);

            var logout = new Action(
                delegate()
                {
                    WindowManager.ChangeScreen<LoginScreenViewModel>();
                });
            LogOutCommand = new DelegateCommand(logout);
        }

        private ObservableCollection<string> _houses;
        public ObservableCollection<string> Houses
        {
            get { return _houses; }
            set { _houses = value; Notify("Houses");}
        }

        private string _selectedHouse;
        public string SelectedHouse
        {
            get { return _selectedHouse; }
            set { _selectedHouse = value; Notify("SelectedHouse");}
        }

        public ICommand SelectHouseCommand { get; set; }

        public ICommand LogOutCommand { get; set; }
    }
}
