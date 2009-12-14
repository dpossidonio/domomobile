using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using SMC = System.ServiceModel.Channels;
using System.ServiceModel;

namespace PDA
{
    partial class Main
    {
        private void Connect(String ip)
        {

            Cursor.Current = Cursors.WaitCursor;
            try
            {
                SMC.Binding binding = DomoServiceClient.CreateDefaultBinding();
                string remoteAddress = DomoServiceClient.EndpointAddress.Uri.ToString();
                remoteAddress = remoteAddress.Replace("localhost", ip);
                EndpointAddress endpoint = new EndpointAddress(remoteAddress);
                Client = new DomoServiceClient(binding, endpoint);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Cursor.Current = Cursors.Default;
        }

        private void callSet(string newValue)
        {
            try
            {
                var res = Client.Set(MyUsername, MyHouse.ID, MyDevice.ID, MyProperty.Type.ID, newValue);
                switch (res)
                {
                    case 0: MessageBox.Show("Is not possible connect to device."); break;
                    case 1: MyProperty.Value = newValue; break;
                    case 2: MessageBox.Show("Permision denied."); break;
                    case 3: MessageBox.Show("Read only Property."); break;
                    default: break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void callGet()
        {
            try
            {
                var res = Client.Get(MyUsername, MyHouse.ID, MyDevice.ID, MyProperty.Type.ID);
                if (res.Length == 2 && res.Substring(0, 1).Equals("#"))
                {
                    var errorId = int.Parse(res.Substring(1));
                    switch (errorId)
                    {
                        case 0: MessageBox.Show("Is not possible connect to device."); break;
                        case 1: MessageBox.Show("Permision denied."); break;
                        case 2: MessageBox.Show("Write only Property."); break;
                        default: break;
                    }
                }
                else
                    MyProperty.Value = res;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool callEcho()
        {
            bool res = false;
            try
            {
                Client.Echo();
                res = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return res;
        }

        private string callGetHomeDescription(int SelectedHouse)
        {
            var house = "";
            try
            {
                house = Client.GetHouseDescription(MyUsername, SelectedHouse);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return house;
        }

        private List<string> callGetHouses()
        {
            HouseList = new Dictionary<int, string>();
            List<string> res = new List<string>();
            try
            {
                var housesList = Client.GetHouses(MyUsername);
                for (int i = 0; i < housesList.Length; i++)
                {
                    var aux = housesList[i].Split(':');
                    HouseList.Add(int.Parse(aux[0]), aux[1]);
                    res.Add(aux[1]);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return res;
        }

        private bool callLogin()
        {
            bool logged = false;
            try
            {
                if (Client.Login(user.Text, pass.Text))
                {
                    MyUsername = user.Text;
                    logged = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return logged;
        }
    }
}
