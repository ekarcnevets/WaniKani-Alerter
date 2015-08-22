namespace WaniKaniAlerter
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            this.ni = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.statusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.changeAPIKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.silentModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerUpdate = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.nudMinReviews = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.updateNowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinReviews)).BeginInit();
            this.SuspendLayout();
            // 
            // ni
            // 
            this.ni.ContextMenuStrip = this.contextMenuStrip1;
            this.ni.Text = "WaniKani Alerter";
            this.ni.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusToolStripMenuItem,
            this.updateNowToolStripMenuItem,
            this.toolStripSeparator1,
            this.changeAPIKeyToolStripMenuItem,
            this.silentModeToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(159, 170);
            // 
            // statusToolStripMenuItem
            // 
            this.statusToolStripMenuItem.Enabled = false;
            this.statusToolStripMenuItem.Name = "statusToolStripMenuItem";
            this.statusToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.statusToolStripMenuItem.Text = "Inactive";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(155, 6);
            // 
            // changeAPIKeyToolStripMenuItem
            // 
            this.changeAPIKeyToolStripMenuItem.Name = "changeAPIKeyToolStripMenuItem";
            this.changeAPIKeyToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.changeAPIKeyToolStripMenuItem.Text = "Change API &Key";
            this.changeAPIKeyToolStripMenuItem.Click += new System.EventHandler(this.changeAPIKeyToolStripMenuItem_Click);
            // 
            // silentModeToolStripMenuItem
            // 
            this.silentModeToolStripMenuItem.Name = "silentModeToolStripMenuItem";
            this.silentModeToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.silentModeToolStripMenuItem.Text = "&Silent Mode";
            this.silentModeToolStripMenuItem.Click += new System.EventHandler(this.silentModeToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.optionsToolStripMenuItem.Text = "&Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(155, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // timerUpdate
            // 
            this.timerUpdate.Interval = 300000;
            this.timerUpdate.Tick += new System.EventHandler(this.timerUpdate_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Notify me when at least";
            // 
            // nudMinReviews
            // 
            this.nudMinReviews.Location = new System.Drawing.Point(129, 7);
            this.nudMinReviews.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.nudMinReviews.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMinReviews.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMinReviews.Name = "nudMinReviews";
            this.nudMinReviews.Size = new System.Drawing.Size(48, 20);
            this.nudMinReviews.TabIndex = 2;
            this.nudMinReviews.ThousandsSeparator = true;
            this.nudMinReviews.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(180, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "review(s) are available";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(71, 33);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(152, 33);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // updateNowToolStripMenuItem
            // 
            this.updateNowToolStripMenuItem.Name = "updateNowToolStripMenuItem";
            this.updateNowToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.updateNowToolStripMenuItem.Text = "Update &Now";
            this.updateNowToolStripMenuItem.Click += new System.EventHandler(this.updateNowToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(298, 68);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudMinReviews);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(314, 106);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(314, 106);
            this.Name = "frmMain";
            this.Text = "WaniKani Alerter";
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudMinReviews)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon ni;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem statusToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem changeAPIKeyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem silentModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Timer timerUpdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudMinReviews;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateNowToolStripMenuItem;
    }
}

