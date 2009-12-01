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
            this.NextButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.labelState = new System.Windows.Forms.Label();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
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
            // NextButton
            // 
            this.NextButton.Location = new System.Drawing.Point(126, 213);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(88, 38);
            this.NextButton.TabIndex = 14;
            this.NextButton.Text = "Next";
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
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
            // linkLabel1
            // 
            this.linkLabel1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Underline);
            this.linkLabel1.Location = new System.Drawing.Point(3, 33);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(58, 25);
            this.linkLabel1.TabIndex = 19;
            this.linkLabel1.Text = "Floors/";
            // 
            // labelState
            // 
            this.labelState.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.labelState.Location = new System.Drawing.Point(0, 6);
            this.labelState.Name = "labelState";
            this.labelState.Size = new System.Drawing.Size(240, 18);
            this.labelState.Text = "FLOORS";
            this.labelState.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // linkLabel2
            // 
            this.linkLabel2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Underline);
            this.linkLabel2.Location = new System.Drawing.Point(58, 33);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(86, 25);
            this.linkLabel2.TabIndex = 21;
            this.linkLabel2.Text = "Divisions /";
            // 
            // linkLabel3
            // 
            this.linkLabel3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Underline);
            this.linkLabel3.Location = new System.Drawing.Point(135, 33);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(77, 25);
            this.linkLabel3.TabIndex = 23;
            this.linkLabel3.Text = "Devices/";
            // 
            // Domo_action
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
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label labelState;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel3;
    }
}