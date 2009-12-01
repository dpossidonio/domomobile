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
        private House Myhouse;
        private int SelectedHouse;
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!IpLabel.Text.Equals(""))
            {
                if (Client == null)
                    Connect(IpTextBox.Text);
                try
                {
                    var houses = Client.GetHouses();
                    foreach (var item in houses)
                    {
                        listBox1.Items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                goToStep2();
            }

        }
        public void Connect(String ip)
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

        private void goToStep1()
        {
            state = 1;
            listBox1.Items.Clear();
            IpLabel.Visible = true;
            IpTextBox.Visible = true;

            label1.Visible = false;
            listBox1.Visible = false;
            button1.Visible = false;
            UpButton.Visible = false;
            DownButton.Visible = false;

            StartButton.Visible = true;
            menuItem5.Enabled = false;
        }

        private void goToStep2()
        {
            state = 2;
            StartButton.Visible = false;
            IpLabel.Visible = false;
            IpTextBox.Visible = false;
            wrongLabel.Visible = false;
            user.Visible = false;
            pass.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            LoginButton.Visible = false;

            menuItem5.Enabled = true;
            label1.Visible = true;
            listBox1.Visible = true;
            button1.Visible = true;
            UpButton.Visible = true;
            DownButton.Visible = true;
        }

        private void goToStep3()
        {
            state = 3;
            listBox1.Items.Clear();
            label1.Visible = false;
            listBox1.Visible = false;
            button1.Visible = false;
            UpButton.Visible = false;
            DownButton.Visible = false;

            user.Visible = true;
            pass.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            LoginButton.Visible = true;
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
            //BackButton.Visible = true;
            NextButton.Visible = true;

            linkLabel2.Visible = false;
            button1.Visible = false;
            BackButton.Visible = false;
            label3.Visible = false;
            user.Visible = false;
            pass.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
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

            labelState.Text = "Devices";

            if (state == 5)
                MyDivision = (Division)listBox1.SelectedItem;
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

                SetPropButton.Visible = false;
                PropTextBox.Visible = false;
                PropComboBox.Visible = false;
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

            try
            {
                MyProperty.Value = Client.Get(MyDevice.ID, MyProperty.Type.ID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            var typeOfValue = MyProperty.Type.TypeOfValue.ToString();
            if (typeOfValue.Equals("VECTOR"))
            {
                PropTextBox.Visible = true;
                PropTextBox.Text = MyProperty.Value;
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
                }
                else
                {
                    var enumerated = ((EnumeratedValueType)(MyProperty.Type.ValueType)).TypeOfValue;
                    foreach (var item in enumerated)
                    {
                        PropComboBox.Items.Add(item);
                    }
                    PropComboBox.SelectedText = MyProperty.Value;
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string house = "";
            if (listBox1.SelectedIndex != -1)
            {
                if (listBox1.SelectedIndex != SelectedHouse)
                {
                    try
                    {
                        SelectedHouse = listBox1.SelectedIndex;
                        house = Client.GetHouseDescription(SelectedHouse);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    Parser c = new Parser();
                    XDocument doc = XDocument.Parse(house);
                    Myhouse = c.getHouse(doc);
                }
                goToStep3();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            goUp();
        }

        private void goUp()
        {
            if (listBox1.SelectedIndex > 0)
                listBox1.SelectedIndex -= 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            goDown();
        }

        private void goDown()
        {
            if (listBox1.SelectedIndex < listBox1.Items.Count - 1)
                listBox1.SelectedIndex += 1;
        }

        private void menuItem5_Click(object sender, EventArgs e)
        {
            if (state == 3)
                goToStep2();
            else if (state == 2)
                goToStep1();
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            int logged = 0;
            foreach (var item in Myhouse.Users)
            {
                if (item.Username.ToString().Equals(user.Text) && item.Password.ToString().Equals(pass.Text))
                {
                    goToStep4();
                    logged = 1;
                    break;
                }
            }
            if (logged == 0)
                wrongLabel.Visible = true;
        }

        private void Enter_Click(object sender, EventArgs e)
        {
            switch (state)
            {
                case 1: button1_Click(sender, e); break;
                case 2: button1_Click_1(sender, e); break;
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

        private void menuItem4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("DomoMobile :P");
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
                callGet(newValue);
            }
            else if (PropComboBox.SelectedIndex != -1)
            {
                if (MyProperty.Type.TypeOfValue.ToString().Equals("ENUM"))
                    newValue = ((Enumerated)PropComboBox.SelectedItem).Value;
                else
                    newValue = PropComboBox.SelectedItem.ToString();
                callGet(newValue);
            }
        }

        /////////////////
        public void callGet(string newValue)
        {
            try
            {
                var suc = Client.Set(MyDevice.ID, MyProperty.Type.ID, newValue);
                if (suc == 1)
                    MyProperty.Value = newValue;
                else
                    MessageBox.Show("Is Not Possible To Change This Value!");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

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
    }
}
