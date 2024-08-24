using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using Repositories;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Services
{
    public class Service
    {
        Repository _repo = new Repository();
        public string _selectedId;
        public string _filePath = @"E:\data.json";
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
    }
}
