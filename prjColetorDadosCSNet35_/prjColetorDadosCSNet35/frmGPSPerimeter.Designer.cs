namespace prjColetorDadosCSNet35
{
    partial class frmGpsPerimeter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGpsPerimeter));
            this.lblAlarmMessage = new System.Windows.Forms.Label();
            this.lblTravelDirection = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblDistance = new System.Windows.Forms.Label();
            this.lblCurrentLocation = new System.Windows.Forms.Label();
            this.cboDistance = new System.Windows.Forms.ComboBox();
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.miQuit = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.compassControl = new prjColetorDadosCSNet35.Compas();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblAlarmMessage
            // 
            this.lblAlarmMessage.Location = new System.Drawing.Point(3, 118);
            this.lblAlarmMessage.Name = "lblAlarmMessage";
            this.lblAlarmMessage.Size = new System.Drawing.Size(233, 20);
            // 
            // lblTravelDirection
            // 
            this.lblTravelDirection.Location = new System.Drawing.Point(108, 98);
            this.lblTravelDirection.Name = "lblTravelDirection";
            this.lblTravelDirection.Size = new System.Drawing.Size(128, 20);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 20);
            this.label3.Text = "Travel Direction";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 20);
            this.label2.Text = "Distance";
            // 
            // lblLocation
            // 
            this.lblLocation.Location = new System.Drawing.Point(3, 58);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(99, 20);
            this.lblLocation.Text = "Location:";
            // 
            // lblDistance
            // 
            this.lblDistance.Location = new System.Drawing.Point(108, 78);
            this.lblDistance.Name = "lblDistance";
            this.lblDistance.Size = new System.Drawing.Size(128, 20);
            // 
            // lblCurrentLocation
            // 
            this.lblCurrentLocation.Location = new System.Drawing.Point(108, 58);
            this.lblCurrentLocation.Name = "lblCurrentLocation";
            this.lblCurrentLocation.Size = new System.Drawing.Size(128, 20);
            // 
            // cboDistance
            // 
            this.cboDistance.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDistance.Items.Add("50 meters");
            this.cboDistance.Items.Add("100 meters");
            this.cboDistance.Items.Add("250 meters");
            this.cboDistance.Items.Add("1 kilometer");
            this.cboDistance.Items.Add("2 kilometers");
            this.cboDistance.Items.Add("5 kilometers");
            this.cboDistance.Items.Add("");
            this.cboDistance.Location = new System.Drawing.Point(3, 33);
            this.cboDistance.Name = "cboDistance";
            this.cboDistance.Size = new System.Drawing.Size(234, 22);
            this.cboDistance.TabIndex = 0;
            this.cboDistance.SelectedIndexChanged += new System.EventHandler(this.cboDistance_SelectedIndexChanged);
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.miQuit);
            this.mainMenu1.MenuItems.Add(this.menuItem1);
            // 
            // miQuit
            // 
            this.miQuit.Text = "&Quit";
            this.miQuit.Click += new System.EventHandler(this.miQuit_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Text = "&Start";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // compassControl
            // 
            this.compassControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.compassControl.BackgroundColor = System.Drawing.Color.White;
            this.compassControl.Location = new System.Drawing.Point(58, 141);
            this.compassControl.Name = "compassControl";
            this.compassControl.PointerColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.compassControl.RingColor = System.Drawing.Color.Red;
            this.compassControl.Size = new System.Drawing.Size(124, 124);
            this.compassControl.TabIndex = 2;
            this.compassControl.TailColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.compassControl.Text = "compass Control";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 20);
            this.label1.Text = "Notification Distance";
            // 
            // frmGpsPerimeter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.lblAlarmMessage);
            this.Controls.Add(this.lblTravelDirection);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.lblDistance);
            this.Controls.Add(this.lblCurrentLocation);
            this.Controls.Add(this.compassControl);
            this.Controls.Add(this.cboDistance);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu1;
            this.Name = "frmGpsPerimeter";
            this.Text = "GPS Perimeter";
            this.Load += new System.EventHandler(this.frmGpsPerimeter_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblAlarmMessage;
        private System.Windows.Forms.Label lblTravelDirection;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblDistance;
        private System.Windows.Forms.Label lblCurrentLocation;
        private System.Windows.Forms.ComboBox cboDistance;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem miQuit;
        private System.Windows.Forms.MenuItem menuItem1;
        private Compas compassControl;
        private System.Windows.Forms.Label label1;
    }
}