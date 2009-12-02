using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using DomoMobile.Common;
using System.ServiceModel;

using SMC = System.ServiceModel.Channels;

namespace PDA
{
    public partial class Main : Form
    {
        private int state;
        private int SelectedHouse;
        private string MyUsername;
        private House Myhouse;
        private Floor MyFloor;
        private Device MyDevice;
        private Division MyDivision;
        private Property MyProperty;

        private DomoServiceClient Client;

        public Main()
        {
            state = 1;
            SelectedHouse = -1;
            InitializeComponent();
            ////Apagar
            IpTextBox.Text = "192.168.0.15";
            user.Text = "David";
            pass.Text = "123";
            ///
        }

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
                if (Client.Set(MyUsername, MyDevice.ID, MyProperty.Type.ID, newValue) == 1)
                    MyProperty.Value = newValue;
                else
                    MessageBox.Show("Is Not Possible To Change This Value!");
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
                MyProperty.Value = Client.Get(MyUsername, MyDevice.ID, MyProperty.Type.ID);
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

        private string[] callGetHouses()
        {
            string[] housesList = {};
            try
            {
                housesList = Client.GetHouses(MyUsername);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return housesList;
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

        /// <summary>
        /// Steps
        /// </summary>
        private void goToStep1()
        {
            state = 1;
            IpLabel.Visible = true;
            IpTextBox.Visible = true;
        }

        private void goToStep2()
        {
            state = 2;

            //coming from state 1
            IpLabel.Visible = false;
            IpTextBox.Visible = false;

            labelChooseOption.Visible = false;
            listBox1.Visible = false;
            buttonGetAccess.Visible = false;
            UpButton.Visible = false;
            DownButton.Visible = false;

            StartButton.Visible = true;
            menuBack.Enabled = false;

            user.Visible = true;
            pass.Visible = true;
            labelUsername.Visible = true;
            labelPassword.Visible = true;
            LoginButton.Visible = true;
            StartButton.Visible = false;
        }

        private void goToStep3()
        {
            if (state == 4)
            {
                var houses = callGetHouses();
                listBox1.Items.Clear();
                foreach (var item in houses)
                {
                    listBox1.Items.Add(item);
                }
            }
            else {
                menuBack.Enabled = true;
                labelChooseOption.Visible = true;
                listBox1.Visible = true;
                UpButton.Visible = true;
                DownButton.Visible = true;

                wrongLabel.Visible = false;
                user.Visible = false;
                pass.Visible = false;
                labelUsername.Visible = false;
                labelPassword.Visible = false;
                LoginButton.Visible = false;
            }

            buttonGetAccess.Visible = true;

            BackButton.Visible = false;
            NextButton.Visible = false;
            labelState.Visible = false;
            linkLabel1.Visible = false;

            labelProgramName.Visible = true;


            state = 3;
        }

        private void goToStep4()
        {
            state = 4;

            listBox1.Items.Clear();
            foreach (var floor in Myhouse.Floors)
            {
                listBox1.Items.Add(floor);
            }

            listBox1.Visible = true;
            UpButton.Visible = true;
            DownButton.Visible = true;
            labelState.Text = "FLOORS";
            labelState.Visible = true;
            linkLabel1.Visible = true;
            BackButton.Visible = true;
            NextButton.Visible = true;

            linkLabel2.Visible = false;
            buttonGetAccess.Visible = false;
            labelProgramName.Visible = false;
            user.Visible = false;
            pass.Visible = false;
            labelUsername.Visible = false;
            labelPassword.Visible = false;
            LoginButton.Visible = false;
        }

        private void goToStep5()
        {
            BackButton.Visible = true;
            linkLabel2.Visible = true;
            linkLabel3.Visible = false;

            if (state == 4)
                MyFloor = (Floor)listBox1.SelectedItem;

            labelState.Text = MyFloor.Name;

            listBox1.Items.Clear();
            foreach (var div in MyFloor.Divisions)
            {
                listBox1.Items.Add(div);
            }
            state = 5;
        }

        private void goToStep6()
        {
            linkLabel3.Visible = true;
            linkLabel4.Visible = false;

            if (state == 5)
                MyDivision = (Division)listBox1.SelectedItem;
            labelState.Text = MyDivision.Name;
            listBox1.Items.Clear();
            foreach (var dev in MyDivision.Devices)
            {
                listBox1.Items.Add(dev);
            }
            state = 6;
        }

        private void goToStep7()
        {
            if (state == 8)
            {
                listBox1.Visible = true;
                UpButton.Visible = true;
                DownButton.Visible = true;
                NextButton.Visible = true;
                labelChooseOption.Visible = true;

                SetPropButton.Visible = false;
                PropTextBox.Visible = false;
                PropComboBox.Visible = false;
                PropUnitText.Visible = false;
            }
            else
            {
                MyDevice = (Device)listBox1.SelectedItem;
                listBox1.Items.Clear();
                foreach (var propt in MyDevice.Properties)
                {
                    listBox1.Items.Add(propt);
                }
            }
            labelState.Text = MyDevice.Name;
            linkLabel4.Visible = true;
            state = 7;
        }

        private void goToStep8()
        {
            state = 8;
            MyProperty = (Property)listBox1.SelectedItem;
            labelState.Text = MyProperty.ToString();

            listBox1.Visible = false;
            UpButton.Visible = false;
            DownButton.Visible = false;
            NextButton.Visible = false;

            SetPropButton.Visible = true;

            PropComboBox.Items.Clear();

            callGet();

            var typeOfValue = MyProperty.Type.TypeOfValue.ToString();

            if (typeOfValue.Equals("VECTOR"))
            {
                PropTextBox.Visible = true;
                PropTextBox.Text = MyProperty.Value;
                labelChooseOption.Visible = false;
            }
            else
            {
                PropComboBox.Visible = true;
                if (typeOfValue.Equals("SCALAR"))
                {
                    var scalar = ((ScalarValueType)(MyProperty.Type.ValueType)).TypeOfValue;
                    for (int i = scalar.MinValue; i <= scalar.MaxValue; i += scalar.Step)
                        PropComboBox.Items.Add(i);
                    PropComboBox.SelectedItem = int.Parse(MyProperty.Value);
                    PropUnitText.Visible = true;
                    PropUnitText.Text = scalar.Units;
                }
                else
                {
                    var enumerated = ((EnumeratedValueType)(MyProperty.Type.ValueType)).TypeOfValue;
                    foreach (var item in enumerated)
                    {
                        PropComboBox.Items.Add(item);
                    }
                    PropComboBox.SelectedItem = enumerated.First(x => x.Value.Equals(MyProperty.Value));

                }
            }
        }
        /// end of steps
        /// 

        private void EchoRequest_Click(object sender, EventArgs e)
        {
            if (!IpLabel.Text.Equals(""))
            {
                if (Client == null)
                    Connect(IpTextBox.Text);
                if (callEcho())
                    goToStep2();
            }
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (!callLogin())
                wrongLabel.Visible = true;
            else
            {
                var houses = callGetHouses();
                listBox1.Items.Clear();
                foreach (var item in houses)
                {
                    listBox1.Items.Add(item);
                }
                goToStep3();
            }
        }

        private void homeChoice_Click(object sender, EventArgs e)
        {
            string house = "";
            if (listBox1.SelectedIndex != -1)
            {
                if (listBox1.SelectedIndex != SelectedHouse)
                {
                    SelectedHouse = listBox1.SelectedIndex;
                    house = callGetHomeDescription(SelectedHouse);

                    Parser c = new Parser();
                    XDocument doc = XDocument.Parse(house);
                    Myhouse = c.getHouse(doc);
                }
                goToStep4();
            }
        }

        private void upButton_Click(object sender, EventArgs e)
        {
            goUp();
        }

        private void goUp()
        {
            if (listBox1.SelectedIndex > 0)
                listBox1.SelectedIndex -= 1;
        }

        private void DownButton_Click(object sender, EventArgs e)
        {
            goDown();
        }

        private void goDown()
        {
            if (listBox1.SelectedIndex < listBox1.Items.Count - 1)
                listBox1.SelectedIndex += 1;
        }

        private void backMenu_Click(object sender, EventArgs e)
        {
            if (state == 3)
                goToStep2();
            else if (state == 2)
                goToStep1();
        }

        private void closeMenu_Click(object sender, EventArgs e)
        {
            Close();
        }



        private void Enter_Click(object sender, EventArgs e)
        {
            switch (state)
            {
                case 1: EchoRequest_Click(sender, e); break;
                case 2: homeChoice_Click(sender, e); break;
                case 3: LoginButton_Click(sender, e); break;
                case 4: NextButton_Click_1(sender, e); break;
                case 5: NextButton_Click_1(sender, e); break;
                case 6: NextButton_Click_1(sender, e); break;
                case 7: NextButton_Click_1(sender, e); break;
                case 8: SetPropButton_Click(sender, e); break;
                default:
                    break;
            }

        }



        private void NextButton_Click_1(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
                switch (state)
                {
                    case 4: goToStep5(); break;
                    case 5: goToStep6(); break;
                    case 6: goToStep7(); break;
                    case 7: goToStep8(); break;
                    default:
                        break;
                }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            switch (state)
            {
                case 4: goToStep3(); break;
                case 5: goToStep4(); break;
                case 6: goToStep5(); break;
                case 7: goToStep6(); break;
                case 8: goToStep7(); break;
                default:
                    break;
            }
        }

        private void SetPropButton_Click(object sender, EventArgs e)
        {
            // vector?
            string newValue;
            if (PropTextBox.Visible)
            {
                newValue = PropTextBox.Text;
                callSet(newValue);
            }
            else if (PropComboBox.SelectedIndex != -1)
            {
                if (MyProperty.Type.TypeOfValue.ToString().Equals("ENUM"))
                    newValue = ((Enumerated)PropComboBox.SelectedItem).Value;
                else
                    newValue = PropComboBox.SelectedItem.ToString();
                callSet(newValue);
            }
        }

        /////////////////


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == System.Windows.Forms.Keys.Up))
            {
                if (state == 2)
                    goUp();

            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Down))
            {
                // Down
                if (state == 2)
                    goDown();
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Left))
            {
                // Left
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Right))
            {
                // Right
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter))
            {
                // Enter
                if (state == 3)
                    goToStep2();
                else if (state == 2)
                    goToStep1();
            }

        }

        private void aboutMenu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("DomoMobile :P");
        }

        private void addFavoriteMenu_Click(object sender, EventArgs e)
        {
            MenuItem i = new MenuItem();
            i.Text = "AAA";
            //this.menuItem3.MenuItems.Add(this.addFavoriteMenu);
            menuFavorites.MenuItems.Add(i);
           
            //TODO
            
        }

    }
}
