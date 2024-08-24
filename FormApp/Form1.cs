using Models;
using Repositories;
using Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FormApp
{

    public partial class Form1 : Form
    {
        Repository _repo = new Repository();
        Service _service = new Service();

        public Form1()
        {
            InitializeComponent();
        }
        //ui
        private void saveContactClickHandler(object sender, EventArgs e)
        {
            var newContact = new Contact();
            newContact.firstName = txt_firstName.Text;
            newContact.lastName = txt_lastName.Text;
            newContact.phoneNumber = txt_phoneNumber.Text;

            var contactIsSaved = _service.saveContacts(newContact);

            if (contactIsSaved.saveResult)
            {
                fillGridView(contactIsSaved.contacts);
            }
            emptyFields();
        }
        //ui
        public void emptyFields()
        {
            txt_firstName.Text = "";
            txt_lastName.Text = "";
            txt_phoneNumber.Text = "";
        }
        //contains ui
        public void deleteContact(string id)
        {
            var contacts = _repo.getContacts();
            var selectedContactToDelete = contacts.FirstOrDefault(contact => contact.id.ToString() == id);
            contacts.Remove(selectedContactToDelete);
            string json = JsonConvert.SerializeObject(contacts, Formatting.Indented);
            System.IO.File.WriteAllText(_service._filePath, json);
            fillGridView(contacts);
            emptyFields();
        }
        //contains ui
        private void Form1_Load(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists(_service._filePath))
            {
                System.IO.File.Create(_service._filePath);
            }
            var contacts = _repo.getContacts();
            fillGridView(contacts);
        }
        //ui
        public void fillGridView(List<Contact> model)
        {
            grd_contacts.Rows.Clear();
            foreach (Contact contact in model)
            {
                grd_contacts.Rows.Add(contact.id, contact.firstName, contact.lastName, contact.phoneNumber);

            }
        }
        //ui
        private void grd_contacts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var index = grd_contacts.CurrentRow.Index;
            var id = grd_contacts.Rows[index].Cells[0].Value.ToString();

            _service._selectedId = id;

            var contacts = _repo.getContacts();
            var selectedContactToEdit = contacts.FirstOrDefault(contact => contact.id.ToString() == id.ToString());

            txt_firstName.Text = selectedContactToEdit.firstName;
            txt_lastName.Text = selectedContactToEdit.lastName;
            txt_phoneNumber.Text = selectedContactToEdit.phoneNumber;
        }
        //ui
        private void btn_deleteContact_Click(object sender, EventArgs e)
        {
            deleteContact(_service._selectedId);
        }
    }
}
