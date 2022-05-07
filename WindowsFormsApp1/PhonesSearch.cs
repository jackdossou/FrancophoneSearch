using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FrancophoneSearch
{
    public partial class PhonesSearch : Form
    {
        public PhonesSearch()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void PhonesSearch_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string phoneNumber = "";
            WindowsFormsApp1.Form1 form1 = new WindowsFormsApp1.Form1();

            phoneNumber = form1.callTruePeopleSearch(FirtName.Text, LastName.Text, SearchZipCode.Text);

            labelTelephone.Text = phoneNumber == "" || phoneNumber == null ? "No phone number found" : "Phone number is " +  phoneNumber;
        }
    }
}
