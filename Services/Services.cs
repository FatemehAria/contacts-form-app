using Models;
using Newtonsoft.Json;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Services
{
    public class Service
    {
        public string _filePath = @"E:\data.json";
        public string _selectedId;
        Repository _repo = new Repository();
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
        public (bool saveResult, List<Contact> contacts) saveContacts(Contact newContact)
        {
            var contacts = _repo.getContacts();


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

            return (saveResult, contacts);
        }

        public Contact getContactById(string id)
        {

            var contacts = _repo.getContacts();
            var contact = contacts.FirstOrDefault(c => c.id.ToString() == id.ToString());
            return contact;
        }
    }
}
