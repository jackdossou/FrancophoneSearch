namespace FrancophoneSearch
{
    partial class PhoneSearchByAddress
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
            this.label3 = new System.Windows.Forms.Label();
            this.labelTelephone = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.ZipCode = new System.Windows.Forms.Label();
            this.state2 = new System.Windows.Forms.TextBox();
            this.City = new System.Windows.Forms.Label();
            this.Address = new System.Windows.Forms.Label();
            this.city2 = new System.Windows.Forms.TextBox();
            this.address2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(233, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(764, 37);
            this.label3.TabIndex = 17;
            this.label3.Text = "Recherche de numero de telephone par addresse";
            // 
            // labelTelephone
            // 
            this.labelTelephone.AutoSize = true;
            this.labelTelephone.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTelephone.Location = new System.Drawing.Point(309, 530);
            this.labelTelephone.Name = "labelTelephone";
            this.labelTelephone.Size = new System.Drawing.Size(0, 42);
            this.labelTelephone.TabIndex = 18;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(501, 370);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(259, 40);
            this.button1.TabIndex = 16;
            this.button1.Text = "Search phone number";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ZipCode
            // 
            this.ZipCode.AutoSize = true;
            this.ZipCode.Location = new System.Drawing.Point(391, 279);
            this.ZipCode.Name = "ZipCode";
            this.ZipCode.Size = new System.Drawing.Size(62, 25);
            this.ZipCode.TabIndex = 15;
            this.ZipCode.Text = "State";
            // 
            // state2
            // 
            this.state2.Location = new System.Drawing.Point(501, 279);
            this.state2.Name = "state2";
            this.state2.Size = new System.Drawing.Size(269, 31);
            this.state2.TabIndex = 14;
            // 
            // City
            // 
            this.City.AutoSize = true;
            this.City.Location = new System.Drawing.Point(404, 209);
            this.City.Name = "City";
            this.City.Size = new System.Drawing.Size(49, 25);
            this.City.TabIndex = 13;
            this.City.Text = "City";
            // 
            // Address
            // 
            this.Address.AutoSize = true;
            this.Address.Location = new System.Drawing.Point(375, 142);
            this.Address.Name = "Address";
            this.Address.Size = new System.Drawing.Size(91, 25);
            this.Address.TabIndex = 12;
            this.Address.Text = "Address";
            // 
            // city2
            // 
            this.city2.Location = new System.Drawing.Point(501, 206);
            this.city2.Name = "city2";
            this.city2.Size = new System.Drawing.Size(269, 31);
            this.city2.TabIndex = 11;
            // 
            // address2
            // 
            this.address2.Location = new System.Drawing.Point(501, 139);
            this.address2.Name = "address2";
            this.address2.Size = new System.Drawing.Size(269, 31);
            this.address2.TabIndex = 10;
            // 
            // PhoneSearchByAddress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1261, 907);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelTelephone);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ZipCode);
            this.Controls.Add(this.state2);
            this.Controls.Add(this.City);
            this.Controls.Add(this.Address);
            this.Controls.Add(this.city2);
            this.Controls.Add(this.address2);
            this.Name = "PhoneSearchByAddress";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recherche de numero de telephone";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelTelephone;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label ZipCode;
        private System.Windows.Forms.TextBox state2;
        private System.Windows.Forms.Label City;
        private System.Windows.Forms.Label Address;
        private System.Windows.Forms.TextBox city2;
        private System.Windows.Forms.TextBox address2;
    }
}