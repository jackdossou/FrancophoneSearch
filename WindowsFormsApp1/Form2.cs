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
    public partial class PhoneSearchByAddress : Form
    {
        public PhoneSearchByAddress()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string phoneNumber = "";
            WindowsFormsApp1.Form1 form1 = new WindowsFormsApp1.Form1();

            phoneNumber = form1.callTruePeopleSearchByAddress(address2.Text, city2.Text, state2.Text);

            labelTelephone.Text = phoneNumber == "" || phoneNumber == null ? "No phone number found" : "Phone number 1 is " + phoneNumber;
        }
    }
}
