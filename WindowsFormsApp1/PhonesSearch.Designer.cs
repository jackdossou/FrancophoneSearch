namespace FrancophoneSearch
{
    partial class PhonesSearch
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
            this.FirtName = new System.Windows.Forms.TextBox();
            this.LastName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ZipCode = new System.Windows.Forms.Label();
            this.SearchZipCode = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.labelTelephone = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // FirtName
            // 
            this.FirtName.Location = new System.Drawing.Point(379, 129);
            this.FirtName.Name = "FirtName";
            this.FirtName.Size = new System.Drawing.Size(269, 31);
            this.FirtName.TabIndex = 0;
            // 
            // LastName
            // 
            this.LastName.Location = new System.Drawing.Point(379, 196);
            this.LastName.Name = "LastName";
            this.LastName.Size = new System.Drawing.Size(269, 31);
            this.LastName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(253, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "FirstName";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(253, 196);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "LastName";
            // 
            // ZipCode
            // 
            this.ZipCode.AutoSize = true;
            this.ZipCode.Location = new System.Drawing.Point(253, 269);
            this.ZipCode.Name = "ZipCode";
            this.ZipCode.Size = new System.Drawing.Size(89, 25);
            this.ZipCode.TabIndex = 5;
            this.ZipCode.Text = "Zipcode";
            // 
            // SearchZipCode
            // 
            this.SearchZipCode.Location = new System.Drawing.Point(379, 269);
            this.SearchZipCode.Name = "SearchZipCode";
            this.SearchZipCode.Size = new System.Drawing.Size(269, 31);
            this.SearchZipCode.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(379, 360);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(259, 40);
            this.button1.TabIndex = 6;
            this.button1.Text = "Search phone number";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelTelephone
            // 
            this.labelTelephone.AutoSize = true;
            this.labelTelephone.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTelephone.Location = new System.Drawing.Point(187, 520);
            this.labelTelephone.Name = "labelTelephone";
            this.labelTelephone.Size = new System.Drawing.Size(0, 42);
            this.labelTelephone.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(149, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(691, 37);
            this.label3.TabIndex = 8;
            this.label3.Text = "Recherche de numero de telephone par nom";
            // 
            // PhonesSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(951, 752);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelTelephone);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ZipCode);
            this.Controls.Add(this.SearchZipCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LastName);
            this.Controls.Add(this.FirtName);
            this.Name = "PhonesSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PhonesSearch";
            this.Load += new System.EventHandler(this.PhonesSearch_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FirtName;
        private System.Windows.Forms.TextBox LastName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label ZipCode;
        private System.Windows.Forms.TextBox SearchZipCode;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelTelephone;
        private System.Windows.Forms.Label label3;
    }
}