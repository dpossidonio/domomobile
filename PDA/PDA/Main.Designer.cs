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
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.Enter = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.StartButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.UpButton = new System.Windows.Forms.Button();
            this.DownButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
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
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuItem1);
            this.mainMenu1.MenuItems.Add(this.menuItem3);
            // 
            // menuItem1
            // 
            this.menuItem1.MenuItems.Add(this.menuItem2);
            this.menuItem1.MenuItems.Add(this.menuItem5);
            this.menuItem1.MenuItems.Add(this.Enter);
            this.menuItem1.Text = "Menu";
            // 
            // menuItem2
            // 
            this.menuItem2.Text = "Exit";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Text = "Back";
            this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
            // 
            // Enter
            // 
            this.Enter.Text = "Enter";
            this.Enter.Click += new System.EventHandler(this.Enter_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.MenuItems.Add(this.menuItem4);
            this.menuItem3.Text = "Help";
            // 
            // menuItem4
            // 
            this.menuItem4.Text = "About";
            this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
            // 
            // StartButton
            // 
            this.StartButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.StartButton.Location = new System.Drawing.Point(44, 119);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(150, 68);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Search for Homes";
            this.StartButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(3, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(237, 36);
            this.label3.Text = "DOMO-MOBILE";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // listBox1
            // 
            this.listBox1.Location = new System.Drawing.Point(18, 92);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(147, 114);
            this.listBox1.TabIndex = 8;
            this.listBox1.Visible = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(29, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 16);
            this.label1.Text = "Choose one Home:";
            this.label1.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(44, 212);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(152, 38);
            this.button1.TabIndex = 10;
            this.button1.Text = "Get Access!";
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
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
            this.UpButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // DownButton
            // 
            this.DownButton.Location = new System.Drawing.Point(172, 163);
            this.DownButton.Name = "DownButton";
            this.DownButton.Size = new System.Drawing.Size(48, 43);
            this.DownButton.TabIndex = 13;
            this.DownButton.Text = "DOWN";
            this.DownButton.Visible = false;
            this.DownButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(35, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 23);
            this.label4.Text = "UserName:";
            this.label4.Visible = false;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(35, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 20);
            this.label5.Text = "Password:";
            this.label5.Visible = false;
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
            this.LoginButton.Location = new System.Drawing.Point(60, 177);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(105, 29);
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
            this.IpTextBox.Location = new System.Drawing.Point(86, 59);
            this.IpTextBox.Name = "IpTextBox";
            this.IpTextBox.Size = new System.Drawing.Size(109, 21);
            this.IpTextBox.TabIndex = 31;
            // 
            // IpLabel
            // 
            this.IpLabel.Location = new System.Drawing.Point(53, 59);
            this.IpLabel.Name = "IpLabel";
            this.IpLabel.Size = new System.Drawing.Size(25, 19);
            this.IpLabel.Text = "IP";
            // 
            // linkLabel3
            // 
            this.linkLabel3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Underline);
            this.linkLabel3.Location = new System.Drawing.Point(135, 39);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(77, 25);
            this.linkLabel3.TabIndex = 43;
            this.linkLabel3.Text = "Devices/";
            this.linkLabel3.Visible = false;
            this.linkLabel3.Click += new System.EventHandler(this.linkLabel3_Click);
            // 
            // linkLabel2
            // 
            this.linkLabel2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Underline);
            this.linkLabel2.Location = new System.Drawing.Point(58, 39);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(86, 25);
            this.linkLabel2.TabIndex = 42;
            this.linkLabel2.Text = "Divisions /";
            this.linkLabel2.Visible = false;
            this.linkLabel2.Click += new System.EventHandler(this.linkLabel2_Click);
            // 
            // labelState
            // 
            this.labelState.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.labelState.Location = new System.Drawing.Point(0, 12);
            this.labelState.Name = "labelState";
            this.labelState.Size = new System.Drawing.Size(240, 18);
            this.labelState.Text = "FLOORS";
            this.labelState.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.labelState.Visible = false;
            this.labelState.ParentChanged += new System.EventHandler(this.labelState_ParentChanged);
            // 
            // linkLabel1
            // 
            this.linkLabel1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Underline);
            this.linkLabel1.Location = new System.Drawing.Point(3, 39);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(58, 25);
            this.linkLabel1.TabIndex = 41;
            this.linkLabel1.Text = "Floors/";
            this.linkLabel1.Visible = false;
            this.linkLabel1.Click += new System.EventHandler(this.linkLabel1_Click);
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
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
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
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DownButton);
            this.Controls.Add(this.UpButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.StartButton);
            this.KeyPreview = true;
            this.Menu = this.mainMenu1;
            this.Name = "Main";
            this.Text = "DomoMobile";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button UpButton;
        private System.Windows.Forms.Button DownButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox user;
        private System.Windows.Forms.TextBox pass;
        internal System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.Label wrongLabel;
        private System.Windows.Forms.MenuItem Enter;
        private System.Windows.Forms.TextBox IpTextBox;
        private System.Windows.Forms.Label IpLabel;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.Label labelState;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button NextButton;

    }
}

