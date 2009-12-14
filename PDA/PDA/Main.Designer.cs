namespace PDA
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.menuItem = new System.Windows.Forms.MenuItem();
            this.menuExit = new System.Windows.Forms.MenuItem();
            this.menuBack = new System.Windows.Forms.MenuItem();
            this.menuEnter = new System.Windows.Forms.MenuItem();
            this.menuFavorites = new System.Windows.Forms.MenuItem();
            this.menuAddFavorite = new System.Windows.Forms.MenuItem();
            this.StartButton = new System.Windows.Forms.Button();
            this.labelProgramName = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.labelChooseOption = new System.Windows.Forms.Label();
            this.buttonGetAccess = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.UpButton = new System.Windows.Forms.Button();
            this.DownButton = new System.Windows.Forms.Button();
            this.labelUsername = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.user = new System.Windows.Forms.TextBox();
            this.pass = new System.Windows.Forms.TextBox();
            this.LoginButton = new System.Windows.Forms.Button();
            this.wrongLabel = new System.Windows.Forms.Label();
            this.IpTextBox = new System.Windows.Forms.TextBox();
            this.IpLabel = new System.Windows.Forms.Label();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.labelState = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.BackButton = new System.Windows.Forms.Button();
            this.NextButton = new System.Windows.Forms.Button();
            this.PropTextBox = new System.Windows.Forms.TextBox();
            this.PropComboBox = new System.Windows.Forms.ComboBox();
            this.SetPropButton = new System.Windows.Forms.Button();
            this.PropUnitText = new System.Windows.Forms.Label();
            this.linkLabel4 = new System.Windows.Forms.LinkLabel();
            this.menuFavSep = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuDeviceSep = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // mainMenu1
            //       
            this.mainMenu1.MenuItems.Add(this.menuItem);
            this.mainMenu1.MenuItems.Add(this.menuFavorites);
            // 
            // menuItem
            // 
            this.menuItem.MenuItems.Add(this.menuExit);
            this.menuItem.MenuItems.Add(this.menuBack);
            this.menuItem.MenuItems.Add(this.menuEnter);
            this.menuItem.Text = "Menu";
            // 
            // menuExit
            // 
            this.menuExit.Text = "Exit";
            this.menuExit.Click += new System.EventHandler(this.closeMenu_Click);
            // 
            // menuBack
            // 
            this.menuBack.Text = "Back";
            this.menuBack.Click += new System.EventHandler(this.backMenu_Click);
            // 
            // menuEnter
            // 
            this.menuEnter.Text = "Enter";
            this.menuEnter.Click += new System.EventHandler(this.Enter_Click);
            // 
            // menuFavorites
            // 
            this.menuFavorites.MenuItems.Add(this.menuAddFavorite);
            this.menuFavorites.MenuItems.Add(this.menuFavSep);
            this.menuFavorites.MenuItems.Add(this.menuDeviceSep);
            this.menuFavorites.MenuItems.Add(this.menuItem1);
            this.menuFavorites.MenuItems.Add(this.menuItem4);
            this.menuFavorites.MenuItems.Add(this.menuItem2);
            this.menuFavorites.Text = "Favorites";
            // 
            // menuAddFavorite
            // 
            this.menuAddFavorite.Text = "+ Favorite";
            this.menuAddFavorite.Click += new System.EventHandler(this.addFavoriteMenu_Click);
            // 
            // StartButton
            // 
            this.StartButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.StartButton.Location = new System.Drawing.Point(44, 166);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(150, 68);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Search for Homes";
            this.StartButton.Click += new System.EventHandler(this.EchoRequest_Click);
            // 
            // labelProgramName
            // 
            this.labelProgramName.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.labelProgramName.Location = new System.Drawing.Point(3, 14);
            this.labelProgramName.Name = "labelProgramName";
            this.labelProgramName.Size = new System.Drawing.Size(237, 36);
            this.labelProgramName.Text = "DOMO-MOBILE";
            this.labelProgramName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // listBox1
            // 
            this.listBox1.Location = new System.Drawing.Point(18, 92);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(147, 114);
            this.listBox1.TabIndex = 8;
            this.listBox1.Visible = false;
            // 
            // labelChooseOption
            // 
            this.labelChooseOption.Location = new System.Drawing.Point(20, 73);
            this.labelChooseOption.Name = "labelChooseOption";
            this.labelChooseOption.Size = new System.Drawing.Size(124, 16);
            this.labelChooseOption.Text = "Choose one Option:";
            this.labelChooseOption.Visible = false;
            // 
            // buttonGetAccess
            // 
            this.buttonGetAccess.Location = new System.Drawing.Point(44, 212);
            this.buttonGetAccess.Name = "buttonGetAccess";
            this.buttonGetAccess.Size = new System.Drawing.Size(152, 38);
            this.buttonGetAccess.TabIndex = 10;
            this.buttonGetAccess.Text = "Get Access!";
            this.buttonGetAccess.Visible = false;
            this.buttonGetAccess.Click += new System.EventHandler(this.homeChoice_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(71, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 18);
            this.label2.Visible = false;
            // 
            // UpButton
            // 
            this.UpButton.Location = new System.Drawing.Point(172, 92);
            this.UpButton.Name = "UpButton";
            this.UpButton.Size = new System.Drawing.Size(48, 43);
            this.UpButton.TabIndex = 12;
            this.UpButton.Text = "UP";
            this.UpButton.Visible = false;
            this.UpButton.Click += new System.EventHandler(this.upButton_Click);
            // 
            // DownButton
            // 
            this.DownButton.Location = new System.Drawing.Point(172, 163);
            this.DownButton.Name = "DownButton";
            this.DownButton.Size = new System.Drawing.Size(48, 43);
            this.DownButton.TabIndex = 13;
            this.DownButton.Text = "DOWN";
            this.DownButton.Visible = false;
            this.DownButton.Click += new System.EventHandler(this.DownButton_Click);
            // 
            // labelUsername
            // 
            this.labelUsername.Location = new System.Drawing.Point(35, 94);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(67, 23);
            this.labelUsername.Text = "UserName:";
            this.labelUsername.Visible = false;
            // 
            // labelPassword
            // 
            this.labelPassword.Location = new System.Drawing.Point(35, 129);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(67, 20);
            this.labelPassword.Text = "Password:";
            this.labelPassword.Visible = false;
            // 
            // user
            // 
            this.user.Location = new System.Drawing.Point(110, 92);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(84, 21);
            this.user.TabIndex = 18;
            this.user.Visible = false;
            // 
            // pass
            // 
            this.pass.Location = new System.Drawing.Point(110, 128);
            this.pass.Name = "pass";
            this.pass.PasswordChar = '*';
            this.pass.Size = new System.Drawing.Size(84, 21);
            this.pass.TabIndex = 19;
            this.pass.Visible = false;
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(44, 166);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(146, 59);
            this.LoginButton.TabIndex = 25;
            this.LoginButton.Text = "Login";
            this.LoginButton.Visible = false;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // wrongLabel
            // 
            this.wrongLabel.ForeColor = System.Drawing.Color.Red;
            this.wrongLabel.Location = new System.Drawing.Point(53, 155);
            this.wrongLabel.Name = "wrongLabel";
            this.wrongLabel.Size = new System.Drawing.Size(131, 21);
            this.wrongLabel.Text = "wrong authentication";
            this.wrongLabel.Visible = false;
            // 
            // IpTextBox
            // 
            this.IpTextBox.Location = new System.Drawing.Point(67, 59);
            this.IpTextBox.Name = "IpTextBox";
            this.IpTextBox.Size = new System.Drawing.Size(109, 21);
            this.IpTextBox.TabIndex = 31;
            // 
            // IpLabel
            // 
            this.IpLabel.Location = new System.Drawing.Point(34, 59);
            this.IpLabel.Name = "IpLabel";
            this.IpLabel.Size = new System.Drawing.Size(25, 19);
            this.IpLabel.Text = "IP";
            // 
            // linkLabel3
            // 
            this.linkLabel3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Underline);
            this.linkLabel3.Location = new System.Drawing.Point(132, 39);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(77, 25);
            this.linkLabel3.TabIndex = 43;
            this.linkLabel3.Text = "Devices/";
            this.linkLabel3.Visible = false;
            // 
            // linkLabel2
            // 
            this.linkLabel2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Underline);
            this.linkLabel2.Location = new System.Drawing.Point(52, 39);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(86, 25);
            this.linkLabel2.TabIndex = 42;
            this.linkLabel2.Text = "Divisions /";
            this.linkLabel2.Visible = false;
            // 
            // labelState
            // 
            this.labelState.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.labelState.Location = new System.Drawing.Point(0, 12);
            this.labelState.Name = "labelState";
            this.labelState.Size = new System.Drawing.Size(240, 18);
            this.labelState.Text = "FLOORS";
            this.labelState.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.labelState.Visible = false;
            // 
            // linkLabel1
            // 
            this.linkLabel1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Underline);
            this.linkLabel1.Location = new System.Drawing.Point(0, 39);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(58, 25);
            this.linkLabel1.TabIndex = 41;
            this.linkLabel1.Text = "Floors/";
            this.linkLabel1.Visible = false;
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(21, 219);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(88, 38);
            this.BackButton.TabIndex = 40;
            this.BackButton.Text = "Back";
            this.BackButton.Visible = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // NextButton
            // 
            this.NextButton.Location = new System.Drawing.Point(126, 219);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(88, 38);
            this.NextButton.TabIndex = 39;
            this.NextButton.Text = "Next";
            this.NextButton.Visible = false;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click_1);
            // 
            // PropTextBox
            // 
            this.PropTextBox.Location = new System.Drawing.Point(34, 134);
            this.PropTextBox.Name = "PropTextBox";
            this.PropTextBox.Size = new System.Drawing.Size(167, 21);
            this.PropTextBox.TabIndex = 54;
            this.PropTextBox.Visible = false;
            // 
            // PropComboBox
            // 
            this.PropComboBox.Location = new System.Drawing.Point(60, 95);
            this.PropComboBox.Name = "PropComboBox";
            this.PropComboBox.Size = new System.Drawing.Size(92, 22);
            this.PropComboBox.TabIndex = 53;
            this.PropComboBox.Visible = false;
            // 
            // SetPropButton
            // 
            this.SetPropButton.Location = new System.Drawing.Point(135, 220);
            this.SetPropButton.Name = "SetPropButton";
            this.SetPropButton.Size = new System.Drawing.Size(55, 37);
            this.SetPropButton.TabIndex = 52;
            this.SetPropButton.Text = "SET";
            this.SetPropButton.Visible = false;
            this.SetPropButton.Click += new System.EventHandler(this.SetPropButton_Click);
            // 
            // PropUnitText
            // 
            this.PropUnitText.Location = new System.Drawing.Point(157, 95);
            this.PropUnitText.Name = "PropUnitText";
            this.PropUnitText.Size = new System.Drawing.Size(80, 22);
            this.PropUnitText.Visible = false;
            // 
            // linkLabel4
            // 
            this.linkLabel4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Underline);
            this.linkLabel4.Location = new System.Drawing.Point(197, 39);
            this.linkLabel4.Name = "linkLabel4";
            this.linkLabel4.Size = new System.Drawing.Size(43, 25);
            this.linkLabel4.TabIndex = 63;
            this.linkLabel4.Text = "Prop/";
            this.linkLabel4.Visible = false;
            // 
            // menuFavSep
            // 
            this.menuFavSep.Enabled = false;
            this.menuFavSep.Text = "________________";
            // 
            // menuItem1
            // 
            this.menuItem1.Enabled = false;
            this.menuItem1.Text = "________________";
            // 
            // menuItem2
            // 
            this.menuItem2.Enabled = false;
            this.menuItem2.Text = "________________";
            // 
            // menuDeviceSep
            // 
            this.menuDeviceSep.Text = "Devices";
            // 
            // menuItem4
            // 
            this.menuItem4.Text = "Divisions";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.linkLabel4);
            this.Controls.Add(this.PropUnitText);
            this.Controls.Add(this.PropTextBox);
            this.Controls.Add(this.PropComboBox);
            this.Controls.Add(this.SetPropButton);
            this.Controls.Add(this.linkLabel3);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.labelState);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.IpLabel);
            this.Controls.Add(this.IpTextBox);
            this.Controls.Add(this.wrongLabel);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.pass);
            this.Controls.Add(this.user);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelUsername);
            this.Controls.Add(this.DownButton);
            this.Controls.Add(this.UpButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonGetAccess);
            this.Controls.Add(this.labelChooseOption);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.labelProgramName);
            this.Controls.Add(this.StartButton);
            this.KeyPreview = true;
            this.Menu = this.mainMenu1;
            this.Name = "Main";
            this.Text = "DomoMobile";
            //this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Label labelProgramName;
        private System.Windows.Forms.MenuItem menuItem;
        private System.Windows.Forms.MenuItem menuExit;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label labelChooseOption;
        private System.Windows.Forms.Button buttonGetAccess;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button UpButton;
        private System.Windows.Forms.Button DownButton;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox user;
        private System.Windows.Forms.TextBox pass;
        internal System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.MenuItem menuBack;
        private System.Windows.Forms.Label wrongLabel;
        private System.Windows.Forms.MenuItem menuEnter;
        private System.Windows.Forms.TextBox IpTextBox;
        private System.Windows.Forms.Label IpLabel;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.Label labelState;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.TextBox PropTextBox;
        private System.Windows.Forms.ComboBox PropComboBox;
        private System.Windows.Forms.Button SetPropButton;
        private System.Windows.Forms.Label PropUnitText;
        private System.Windows.Forms.LinkLabel linkLabel4;
        public System.Windows.Forms.MenuItem menuAddFavorite;
        public System.Windows.Forms.MenuItem menuFavorites;
        private System.Windows.Forms.MenuItem menuFavSep;
        private System.Windows.Forms.MenuItem menuDeviceSep;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItem4;

    }
}

