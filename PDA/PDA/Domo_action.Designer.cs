namespace PDA
{
    partial class Domo_action
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
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.BackButton = new System.Windows.Forms.Button();
            this.labelState = new System.Windows.Forms.Label();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.SetPropButton = new System.Windows.Forms.Button();
            this.PropComboBox = new System.Windows.Forms.ComboBox();
            this.PropTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuItem1);
            this.mainMenu1.MenuItems.Add(this.menuItem2);
            // 
            // menuItem1
            // 
            this.menuItem1.MenuItems.Add(this.menuItem5);
            this.menuItem1.Text = "Menu";
            // 
            // menuItem5
            // 
            this.menuItem5.Text = "Exit";
            // 
            // menuItem2
            // 
            this.menuItem2.MenuItems.Add(this.menuItem3);
            this.menuItem2.MenuItems.Add(this.menuItem4);
            this.menuItem2.Text = "Favorites";
            // 
            // menuItem3
            // 
            this.menuItem3.Text = "List";
            // 
            // menuItem4
            // 
            this.menuItem4.Text = "Add";
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(21, 213);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(88, 38);
            this.BackButton.TabIndex = 18;
            this.BackButton.Text = "Back";
            this.BackButton.Visible = false;
            // 
            // labelState
            // 
            this.labelState.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.labelState.Location = new System.Drawing.Point(0, 6);
            this.labelState.Name = "labelState";
            this.labelState.Size = new System.Drawing.Size(240, 18);
            this.labelState.Text = "On/Off";
            this.labelState.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // linkLabel3
            // 
            this.linkLabel3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Underline);
            this.linkLabel3.Location = new System.Drawing.Point(4, 33);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(77, 25);
            this.linkLabel3.TabIndex = 23;
            this.linkLabel3.Text = "Devices/";
            // 
            // SetPropButton
            // 
            this.SetPropButton.Location = new System.Drawing.Point(135, 213);
            this.SetPropButton.Name = "SetPropButton";
            this.SetPropButton.Size = new System.Drawing.Size(55, 37);
            this.SetPropButton.TabIndex = 26;
            this.SetPropButton.Text = "SET";
            this.SetPropButton.Visible = false;
            // 
            // PropComboBox
            // 
            this.PropComboBox.Location = new System.Drawing.Point(60, 88);
            this.PropComboBox.Name = "PropComboBox";
            this.PropComboBox.Size = new System.Drawing.Size(115, 22);
            this.PropComboBox.TabIndex = 28;
            this.PropComboBox.Visible = false;
            // 
            // PropTextBox
            // 
            this.PropTextBox.Location = new System.Drawing.Point(34, 127);
            this.PropTextBox.Name = "PropTextBox";
            this.PropTextBox.Size = new System.Drawing.Size(167, 21);
            this.PropTextBox.TabIndex = 29;
            this.PropTextBox.Visible = false;
            // 
            // Domo_action
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.PropTextBox);
            this.Controls.Add(this.PropComboBox);
            this.Controls.Add(this.SetPropButton);
            this.Controls.Add(this.linkLabel3);
            this.Controls.Add(this.labelState);
            this.Controls.Add(this.BackButton);
            this.Menu = this.mainMenu1;
            this.Name = "Domo_action";
            this.Text = "DomoMobile";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Label labelState;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.Button SetPropButton;
        private System.Windows.Forms.ComboBox PropComboBox;
        private System.Windows.Forms.TextBox PropTextBox;
    }
}