using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryProj.Existance;
using LibraryProj.Repository;
using Newtonsoft.Json;

namespace LibraryProj.Services
{
    public class FileSerialize : IReadAndWriteData
    {
        public string PathPersons { get; set; } = @"d:\Persons.json";
        public string PathBooks { get; set; } = @"d:\Books.json";

        public void ReadData()
        {
            if (File.Exists(PathPersons))
            {
                DataStorage.Persons = JsonConvert.DeserializeObject<List<Person>>(File.ReadAllText(PathPersons));
                DataStorage.Books = JsonConvert.DeserializeObject<List<Book>>(File.ReadAllText(PathBooks));

            }
        }

        public void WriteData()
        {
            
            File.WriteAllText(PathPersons, JsonConvert.SerializeObject(DataStorage.Persons));
            File.WriteAllText(PathBooks, JsonConvert.SerializeObject(DataStorage.Books));


        }
    }
}
