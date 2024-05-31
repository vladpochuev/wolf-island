namespace WolfIsland
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.toolStripNext = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.plainBtn = new System.Windows.Forms.ToolStripButton();
            this.oceanBtn = new System.Windows.Forms.ToolStripButton();
            this.randomBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.rabbitBtn = new System.Windows.Forms.ToolStripButton();
            this.wolfMBtn = new System.Windows.Forms.ToolStripButton();
            this.wolfFBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMain
            // 
            this.toolStripMain.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStripMain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.toolStripNext, this.toolStripSeparator1, this.plainBtn, this.oceanBtn, this.randomBtn, this.toolStripSeparator2, this.rabbitBtn, this.wolfMBtn, this.wolfFBtn });
            this.toolStripMain.Location = new System.Drawing.Point(0, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(1264, 39);
            this.toolStripMain.TabIndex = 0;
            // 
            // toolStripNext
            // 
            this.toolStripNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripNext.Image = ((System.Drawing.Image)(resources.GetObject("toolStripNext.Image")));
            this.toolStripNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripNext.Name = "toolStripNext";
            this.toolStripNext.Size = new System.Drawing.Size(36, 36);
            this.toolStripNext.Text = "toolStripButton2";
            this.toolStripNext.ToolTipText = "Next move";
            this.toolStripNext.Click += new System.EventHandler(this.toolStripNext_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // plainBtn
            // 
            this.plainBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.plainBtn.Image = ((System.Drawing.Image)(resources.GetObject("plainBtn.Image")));
            this.plainBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.plainBtn.Name = "plainBtn";
            this.plainBtn.Size = new System.Drawing.Size(36, 36);
            this.plainBtn.Text = "toolStripButton2";
            this.plainBtn.ToolTipText = "Add plain";
            this.plainBtn.Click += new System.EventHandler(this.plainBtn_Click);
            // 
            // oceanBtn
            // 
            this.oceanBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.oceanBtn.Image = ((System.Drawing.Image)(resources.GetObject("oceanBtn.Image")));
            this.oceanBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.oceanBtn.Name = "oceanBtn";
            this.oceanBtn.Size = new System.Drawing.Size(36, 36);
            this.oceanBtn.Text = "toolStripButton2";
            this.oceanBtn.ToolTipText = "Add ocean";
            this.oceanBtn.Click += new System.EventHandler(this.oceanBtn_Click);
            // 
            // randomBtn
            // 
            this.randomBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.randomBtn.Image = ((System.Drawing.Image)(resources.GetObject("randomBtn.Image")));
            this.randomBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.randomBtn.Name = "randomBtn";
            this.randomBtn.Size = new System.Drawing.Size(36, 36);
            this.randomBtn.Text = "toolStripButton2";
            this.randomBtn.ToolTipText = "Random island";
            this.randomBtn.Click += new System.EventHandler(this.randomBtn_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // rabbitBtn
            // 
            this.rabbitBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.rabbitBtn.Image = ((System.Drawing.Image)(resources.GetObject("rabbitBtn.Image")));
            this.rabbitBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rabbitBtn.Name = "rabbitBtn";
            this.rabbitBtn.Size = new System.Drawing.Size(36, 36);
            this.rabbitBtn.Text = "toolStripButton2";
            this.rabbitBtn.ToolTipText = "Add rabbit";
            this.rabbitBtn.Click += new System.EventHandler(this.rabbitBtn_Click);
            // 
            // wolfMBtn
            // 
            this.wolfMBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.wolfMBtn.Image = ((System.Drawing.Image)(resources.GetObject("wolfMBtn.Image")));
            this.wolfMBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.wolfMBtn.Name = "wolfMBtn";
            this.wolfMBtn.Size = new System.Drawing.Size(36, 36);
            this.wolfMBtn.Text = "toolStripButton3";
            this.wolfMBtn.ToolTipText = "Add wolf (male)";
            this.wolfMBtn.Click += new System.EventHandler(this.wolfMBtn_Click);
            // 
            // wolfFBtn
            // 
            this.wolfFBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.wolfFBtn.Image = ((System.Drawing.Image)(resources.GetObject("wolfFBtn.Image")));
            this.wolfFBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.wolfFBtn.Name = "wolfFBtn";
            this.wolfFBtn.Size = new System.Drawing.Size(36, 36);
            this.wolfFBtn.Text = "toolStripButton4";
            this.wolfFBtn.ToolTipText = "Add wolf (female)";
            this.wolfFBtn.Click += new System.EventHandler(this.wolfFBtn_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 821);
            this.Controls.Add(this.toolStripMain);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ToolStripButton randomBtn;

        private System.Windows.Forms.ToolStripButton wolfMBtn;
        private System.Windows.Forms.ToolStripButton wolfFBtn;

        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton rabbitBtn;

        private System.Windows.Forms.ToolStripButton oceanBtn;

        private System.Windows.Forms.ToolStripButton plainBtn;

        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;

        private System.Windows.Forms.ToolStripButton toolStripNext;

        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripButton toolStripButton1;

        #endregion
    }
}