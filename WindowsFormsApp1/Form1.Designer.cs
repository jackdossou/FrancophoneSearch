namespace WindowsFormsApp1
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
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.defaultFolderToSearchLabel = new System.Windows.Forms.Label();
            this.radioFirstLast = new System.Windows.Forms.RadioButton();
            this.DuplicateAddress = new System.Windows.Forms.CheckBox();
            this.radioFirstname = new System.Windows.Forms.RadioButton();
            this.radioLastname = new System.Windows.Forms.RadioButton();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progressLabel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.frenchCountriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dropOffFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.instructionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.phoneSearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yNameZipCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.totalFiles = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.button3 = new System.Windows.Forms.Button();
            this.byAddressStateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(992, 63);
            this.button1.Margin = new System.Windows.Forms.Padding(6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(240, 44);
            this.button1.TabIndex = 0;
            this.button1.Text = "Search francophones";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.defaultFolderToSearchLabel);
            this.groupBox1.Controls.Add(this.radioFirstLast);
            this.groupBox1.Controls.Add(this.DuplicateAddress);
            this.groupBox1.Controls.Add(this.radioFirstname);
            this.groupBox1.Controls.Add(this.radioLastname);
            this.groupBox1.Location = new System.Drawing.Point(24, 23);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox1.Size = new System.Drawing.Size(966, 140);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Criteria";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(804, 87);
            this.button2.Margin = new System.Windows.Forms.Padding(6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 44);
            this.button2.TabIndex = 7;
            this.button2.Text = "set Folder";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // defaultFolderToSearchLabel
            // 
            this.defaultFolderToSearchLabel.AutoSize = true;
            this.defaultFolderToSearchLabel.Location = new System.Drawing.Point(12, 96);
            this.defaultFolderToSearchLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.defaultFolderToSearchLabel.Name = "defaultFolderToSearchLabel";
            this.defaultFolderToSearchLabel.Size = new System.Drawing.Size(174, 25);
            this.defaultFolderToSearchLabel.TabIndex = 4;
            this.defaultFolderToSearchLabel.Text = "Folder to search:";
            // 
            // radioFirstLast
            // 
            this.radioFirstLast.AutoSize = true;
            this.radioFirstLast.Location = new System.Drawing.Point(12, 35);
            this.radioFirstLast.Margin = new System.Windows.Forms.Padding(6);
            this.radioFirstLast.Name = "radioFirstLast";
            this.radioFirstLast.Size = new System.Drawing.Size(258, 29);
            this.radioFirstLast.TabIndex = 3;
            this.radioFirstLast.Text = "By First and Lastname";
            this.radioFirstLast.UseVisualStyleBackColor = true;
            // 
            // DuplicateAddress
            // 
            this.DuplicateAddress.AutoSize = true;
            this.DuplicateAddress.Checked = true;
            this.DuplicateAddress.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DuplicateAddress.Location = new System.Drawing.Point(658, 37);
            this.DuplicateAddress.Margin = new System.Windows.Forms.Padding(6);
            this.DuplicateAddress.Name = "DuplicateAddress";
            this.DuplicateAddress.Size = new System.Drawing.Size(304, 29);
            this.DuplicateAddress.TabIndex = 2;
            this.DuplicateAddress.Text = "Check duplicate addresses";
            this.DuplicateAddress.UseVisualStyleBackColor = true;
            // 
            // radioFirstname
            // 
            this.radioFirstname.AutoSize = true;
            this.radioFirstname.Location = new System.Drawing.Point(472, 35);
            this.radioFirstname.Margin = new System.Windows.Forms.Padding(6);
            this.radioFirstname.Name = "radioFirstname";
            this.radioFirstname.Size = new System.Drawing.Size(172, 29);
            this.radioFirstname.TabIndex = 1;
            this.radioFirstname.Text = "By FirstName";
            this.radioFirstname.UseVisualStyleBackColor = true;
            this.radioFirstname.CheckedChanged += new System.EventHandler(this.radioFirstname_CheckedChanged);
            // 
            // radioLastname
            // 
            this.radioLastname.AutoSize = true;
            this.radioLastname.Checked = true;
            this.radioLastname.Location = new System.Drawing.Point(284, 35);
            this.radioLastname.Margin = new System.Windows.Forms.Padding(6);
            this.radioLastname.Name = "radioLastname";
            this.radioLastname.Size = new System.Drawing.Size(171, 29);
            this.radioLastname.TabIndex = 0;
            this.radioLastname.TabStop = true;
            this.radioLastname.Text = "By LastName";
            this.radioLastname.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(24, 231);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(6);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1214, 941);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(24, 175);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(6);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1208, 44);
            this.progressBar1.TabIndex = 4;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // progressLabel
            // 
            this.progressLabel.AutoSize = true;
            this.progressLabel.BackColor = System.Drawing.SystemColors.Control;
            this.progressLabel.Location = new System.Drawing.Point(418, 185);
            this.progressLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(0, 25);
            this.progressLabel.TabIndex = 5;
            this.progressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(909, 8);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(333, 42);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.frenchCountriesToolStripMenuItem,
            this.dropOffFolderToolStripMenuItem,
            this.instructionToolStripMenuItem,
            this.phoneSearchToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(85, 38);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // frenchCountriesToolStripMenuItem
            // 
            this.frenchCountriesToolStripMenuItem.Name = "frenchCountriesToolStripMenuItem";
            this.frenchCountriesToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
            this.frenchCountriesToolStripMenuItem.Text = "French Countries";
            // 
            // dropOffFolderToolStripMenuItem
            // 
            this.dropOffFolderToolStripMenuItem.Name = "dropOffFolderToolStripMenuItem";
            this.dropOffFolderToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
            this.dropOffFolderToolStripMenuItem.Text = "Drop Off Folder";
            this.dropOffFolderToolStripMenuItem.Click += new System.EventHandler(this.dropOffFolderToolStripMenuItem_Click);
            // 
            // instructionToolStripMenuItem
            // 
            this.instructionToolStripMenuItem.Name = "instructionToolStripMenuItem";
            this.instructionToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
            this.instructionToolStripMenuItem.Text = "Read Me";
            this.instructionToolStripMenuItem.Click += new System.EventHandler(this.instructionToolStripMenuItem_Click);
            // 
            // phoneSearchToolStripMenuItem
            // 
            this.phoneSearchToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yNameZipCodeToolStripMenuItem,
            this.byAddressStateToolStripMenuItem});
            this.phoneSearchToolStripMenuItem.Name = "phoneSearchToolStripMenuItem";
            this.phoneSearchToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
            this.phoneSearchToolStripMenuItem.Text = "Phone search";
            this.phoneSearchToolStripMenuItem.Click += new System.EventHandler(this.phoneSearchToolStripMenuItem_Click);
            // 
            // yNameZipCodeToolStripMenuItem
            // 
            this.yNameZipCodeToolStripMenuItem.Name = "yNameZipCodeToolStripMenuItem";
            this.yNameZipCodeToolStripMenuItem.Size = new System.Drawing.Size(372, 44);
            this.yNameZipCodeToolStripMenuItem.Text = "By Name && Zip code";
            this.yNameZipCodeToolStripMenuItem.Click += new System.EventHandler(this.yNameZipCodeToolStripMenuItem_Click);
            // 
            // totalFiles
            // 
            this.totalFiles.AutoSize = true;
            this.totalFiles.Location = new System.Drawing.Point(1076, 119);
            this.totalFiles.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.totalFiles.Name = "totalFiles";
            this.totalFiles.Size = new System.Drawing.Size(26, 25);
            this.totalFiles.TabIndex = 7;
            this.totalFiles.Text = "\"\"";
            this.totalFiles.Visible = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(992, 136);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(214, 42);
            this.button3.TabIndex = 8;
            this.button3.Text = "Cancel search";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // byAddressStateToolStripMenuItem
            // 
            this.byAddressStateToolStripMenuItem.Name = "byAddressStateToolStripMenuItem";
            this.byAddressStateToolStripMenuItem.Size = new System.Drawing.Size(372, 44);
            this.byAddressStateToolStripMenuItem.Text = "By Address && State";
            this.byAddressStateToolStripMenuItem.Click += new System.EventHandler(this.byAddressStateToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1256, 1206);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.totalFiles);
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Francophone Search on forebears.io";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioFirstname;
        private System.Windows.Forms.RadioButton radioLastname;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.CheckBox DuplicateAddress;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label progressLabel;
        private System.Windows.Forms.RadioButton radioFirstLast;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem frenchCountriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dropOffFolderToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ToolStripMenuItem instructionToolStripMenuItem;
        private System.Windows.Forms.Label defaultFolderToSearchLabel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label totalFiles;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ToolStripMenuItem phoneSearchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yNameZipCodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byAddressStateToolStripMenuItem;
    }
}

