using System;
using Models;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class Repository
    {
        public List<Contact> getContacts()
        {
            string _filePath = @"E:\data.json";
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
    }

}
