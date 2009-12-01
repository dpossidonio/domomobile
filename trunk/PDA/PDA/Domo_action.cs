using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PDA
{
    public partial class Domo_action : Form
    {
        private int State;
        private string floors = "FLOORS";
        private string divisions = "DIVISIONS";
        private string devices = "DEVICES";
        private string properties = "PROPERTIES";

        public Domo_action()
        {
            State = 1;
            InitializeComponent();
        }

        private void NextButton_Click(object sender, EventArgs e)
        {

        }

        private void UpButton_Click(object sender, EventArgs e)
        {

        }

        private void DownButton_Click(object sender, EventArgs e)
        {

        }


    }
}