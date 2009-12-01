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

        private DomoServiceClient Client;

        public Main()
        {
            state = 1;
            SelectedHouse = -1;
            InitializeComponent();
            ////Apagar
            IpTextBox.Text = "192.168.0.15";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Client == null && IpLabel.Text.Length > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    SMC.Binding binding = DomoServiceClient.CreateDefaultBinding();
                    string remoteAddress = DomoServiceClient.EndpointAddress.Uri.ToString();
                    remoteAddress = remoteAddress.Replace("localhost", IpTextBox.Text);
                    EndpointAddress endpoint = new EndpointAddress(remoteAddress);
                    Client = new DomoServiceClient(binding, endpoint);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                Cursor.Current = Cursors.Default;
            }

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

            user.Text = "David";
            pass.Text = "123";
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
            button1.Visible = false;
            UpButton.Visible = true;
            DownButton.Visible = true;
            labelState.Text = "FLOORS";
            labelState.Visible = true;
            linkLabel1.Visible = true;
            //BackButton.Visible = true;
            NextButton.Visible = true;

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
           
            labelState.Text = "Divisions";

            if (state == 4)
                MyFloor = (Floor)listBox1.SelectedItem;

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
            state = 7;
            listBox1.Items.Clear();
            labelState.Text = "Nome do Device";
            MyDevice = (Device)listBox1.SelectedItem;
            foreach (var propt in MyDevice.Properties)
            {
                listBox1.Items.Add(propt.ToString());
            }
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string house = "";
            if (listBox1.SelectedIndex != -1 && listBox1.SelectedIndex != SelectedHouse)
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
            if(logged == 0)
                wrongLabel.Visible = true;
            
        }

        private void Enter_Click(object sender, EventArgs e)
        {
            switch (state)
            {
                case 1: button1_Click(sender, e); break;
                case 2: button1_Click_1(sender, e); break;
                case 3: LoginButton_Click(sender, e); break;
                default:
                    break;
            }

        }

        private void menuItem4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("DomoMobile :P");
        }

        private void NextButton_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel2_Click(object sender, EventArgs e)
        {

        }

        private void labelState_ParentChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel3_Click(object sender, EventArgs e)
        {

        }

        private void NextButton_Click_1(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex != -1)
            switch (state)
            {
                case 4: goToStep5(); break;
                case 5: goToStep6(); break;
                case 6: goToStep7(); break;
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
                default:
                    break;
            }

        }
    }
}
