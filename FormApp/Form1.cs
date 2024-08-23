using Newtonsoft.Json;
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
        string filePath = @"E:\data.json";
        public class Contact
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
            var contacts = getContacts();
            var newContact = new Contact();
            newContact.firstName = txt_firstName.Text;
            newContact.lastName = txt_lastName.Text;
            newContact.phoneNumber = txt_phoneNumber.Text;
            contacts.Add(newContact);
            var saveResult = contactIsSaved(contacts);
            emptyFields();
        }

        public void emptyFields()
        {
            var contact = new Contact();
            txt_firstName.Text = "";
            txt_lastName.Text = "";
            txt_phoneNumber.Text = "";
        }
        public bool contactIsSaved(List<Contact> model)
        {
            try
            {
                var stringModel = JsonConvert.SerializeObject(model);
                System.IO.File.WriteAllText(filePath, stringModel);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<Contact> getContacts()
        {
            var result = new List<Contact>();
            try
            {
                if (System.IO.File.Exists(filePath) && System.IO.File.ReadAllText(filePath) != "")
                {
                    var fileString = System.IO.File.ReadAllText(filePath);
                    result = JsonConvert.DeserializeObject<List<Contact>>(fileString);
                }

            }
            catch
            {
                throw;
            }
            return result;
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
