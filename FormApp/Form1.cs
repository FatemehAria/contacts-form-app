using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormApp
{

    public partial class Form1 : Form
    {
        string filePath = @"D:\data.json";
        class Contact
        {
            public Guid id { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string phoneNumber { get; set; }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void saveContactClickHandler(object sender, EventArgs e)
        {
            var contact = new Contact();
            contact.firstName = txt_firstName.Text;
            contact.lastName = txt_lastName.Text;
            contact.phoneNumber = txt_phoneNumber.Text;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists(filePath))
            {
                System.IO.File.Create(filePath);
            }
        }
    }
}
