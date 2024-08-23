using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FormApp
{

    public partial class Form1 : Form
    {
        string _filePath = @"E:\data.json";
        string _selectedId;
        
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

            if (string.IsNullOrEmpty(_selectedId))
            {
                
                newContact.id = Guid.NewGuid();
                contacts.Add(newContact);
            }
            else
            {
                var contactToEdit = contacts.FirstOrDefault(contact => contact.id.ToString() == _selectedId);
                contacts.Remove(contactToEdit);
                newContact.id = Guid.Parse(_selectedId);
                contacts.Add(newContact);
                _selectedId = "";
            }

            var saveResult = contactIsSaved(contacts);
            if (saveResult)
            {
                fillGridView(contacts);
            }
            emptyFields();
        }

        public void emptyFields()
        {
            txt_firstName.Text = "";
            txt_lastName.Text = "";
            txt_phoneNumber.Text = "";
        }

        public bool contactIsSaved(List<Contact> model)
        {
            try
            {
                var stringModel = JsonConvert.SerializeObject(model);
                System.IO.File.WriteAllText(_filePath, stringModel);
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
                if (System.IO.File.Exists(_filePath) && System.IO.File.ReadAllText(_filePath) != "")
                {
                    var fileString = System.IO.File.ReadAllText(_filePath);
                    result = JsonConvert.DeserializeObject<List<Contact>>(fileString);
                }

                foreach (var contact in result)
                {
                    if (contact.id == null)
                    {
                        contact.id = Guid.NewGuid();
                    }
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
            if (!System.IO.File.Exists(_filePath))
            {
                System.IO.File.Create(_filePath);
            }
            var contacts = getContacts();
            fillGridView(contacts);
        }

        public void fillGridView(List<Contact> model)
        {
            grd_contacts.Rows.Clear();
            foreach (Contact contact in model)
            {
                grd_contacts.Rows.Add(contact.id, contact.firstName, contact.lastName, contact.phoneNumber);

            }
        }

        private void grd_contacts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var index = grd_contacts.CurrentRow.Index;
            var id = grd_contacts.Rows[index].Cells[0].Value.ToString();

            _selectedId = id;

            var contacts = getContacts();
            var selectedContactToEdit = contacts.FirstOrDefault(contact => contact.id.ToString() == id.ToString());

            txt_firstName.Text = selectedContactToEdit.firstName;
            txt_lastName.Text = selectedContactToEdit.lastName;
            txt_phoneNumber.Text = selectedContactToEdit.phoneNumber;
        }
    }
}
