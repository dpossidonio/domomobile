using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Main.ViewModels
{
    public class LoginScreenViewModel:Screen
    {
        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; Notify("UserName"); }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; Notify("Password");}
        }

        private string _ip;
        public string Ip
        {
            get { return _ip; }
            set { _ip = value; Notify("Ip");}
        }

        private ICommand _okCommand;
        public ICommand OkCommand
        {
            get { return _okCommand; }
            set { _okCommand = value; Notify("OkCommand");}
        }
        
        public LoginScreenViewModel(Context context, IServiceManager service, IWindowManager window)
            : base(context, service, window)
        {
            var cmd = new Action(delegate()
                                     {
                                         if(!String.IsNullOrEmpty(Ip))
                                         {
                                             CurrentContext.Endpoint = String.Format(Endpoint, Ip);
                                         } 
                                         //Validar username e password
                                         bool res = ServiceManager.Login(UserName, Password);
                                         if(!res) return;

                                         CurrentContext.CurrentUser = UserName;
                                         //caso sejam válidos mudar de ecra
                                         WindowManager.ChangeScreen<HouseSelectionViewModel>();
                                     });
            OkCommand = new DelegateCommand(cmd);
        }

        private static readonly string Endpoint = "http://{0}:8000/DomoService/DomoService";
    }
}
