using Models;
using Newtonsoft.Json;
using System.Collections.Generic;


namespace Services
{
    public class Service
    {
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
    }
}
