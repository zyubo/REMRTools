namespace REMRTools
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
            this.dgv = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.processToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.demoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agilityPackDemoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openXMLDemoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadCitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 24);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(752, 425);
            this.dgv.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.processToolStripMenuItem,
            this.demoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(752, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // processToolStripMenuItem
            // 
            this.processToolStripMenuItem.Name = "processToolStripMenuItem";
            this.processToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.processToolStripMenuItem.Text = "Process";
            this.processToolStripMenuItem.Click += new System.EventHandler(this.processToolStripMenuItem_Click);
            // 
            // demoToolStripMenuItem
            // 
            this.demoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agilityPackDemoToolStripMenuItem,
            this.openXMLDemoToolStripMenuItem,
            this.loadCitiesToolStripMenuItem});
            this.demoToolStripMenuItem.Name = "demoToolStripMenuItem";
            this.demoToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.demoToolStripMenuItem.Text = "Demo";
            // 
            // agilityPackDemoToolStripMenuItem
            // 
            this.agilityPackDemoToolStripMenuItem.Name = "agilityPackDemoToolStripMenuItem";
            this.agilityPackDemoToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.agilityPackDemoToolStripMenuItem.Text = "AgilityPack Demo";
            this.agilityPackDemoToolStripMenuItem.Click += new System.EventHandler(this.agilityPackDemoToolStripMenuItem_Click);
            // 
            // openXMLDemoToolStripMenuItem
            // 
            this.openXMLDemoToolStripMenuItem.Name = "openXMLDemoToolStripMenuItem";
            this.openXMLDemoToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.openXMLDemoToolStripMenuItem.Text = "OpenXML Demo";
            this.openXMLDemoToolStripMenuItem.Click += new System.EventHandler(this.openXMLDemoToolStripMenuItem_Click);
            // 
            // loadCitiesToolStripMenuItem
            // 
            this.loadCitiesToolStripMenuItem.Name = "loadCitiesToolStripMenuItem";
            this.loadCitiesToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.loadCitiesToolStripMenuItem.Text = "Load Cities";
            this.loadCitiesToolStripMenuItem.Click += new System.EventHandler(this.loadCitiesToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 449);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem processToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem demoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agilityPackDemoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openXMLDemoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadCitiesToolStripMenuItem;
    }
}

