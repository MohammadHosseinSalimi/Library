using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using LibraryProj.Existance;
using LibraryProj.Repository;

namespace LibraryProj.Services
{
    public class FileDataRW : IReadAndWriteData
    {
        public string Path { get; set; } = @"d:\salimi.txt";
        public void ReadData()
        {
            if (File.Exists(Path))
            {

                string[] fileread = File.ReadAllLines(Path);
                int i = 0;
                while (i < fileread.Length)
                {

                    if (fileread[i + 4] == "0")
                    {
                        Librarian librarian = new Librarian();
                        Guid.TryParse(fileread[i], out Guid guidNum);
                        librarian.Id = guidNum;
                        librarian.Name = fileread[i + 1];
                        librarian.Email = fileread[i + 2];
                        librarian.Password = fileread[i + 3];
                        librarian.Role = Convert.ToByte(fileread[i + 4]);
                        DataStorage.Persons.Add(librarian);

                    }
                    else if (fileread[i + 4] == "1")
                    {
                        Member member = new Member();
                        Guid.TryParse(fileread[i], out Guid guidNum);
                        member.Id = guidNum;
                        member.Name = fileread[i + 1];
                        member.Email = fileread[i + 2];
                        member.Password = fileread[i + 3];
                        member.Role = Convert.ToByte(fileread[i + 4]);
                        DataStorage.Persons.Add(member);

                    }


                    i += 5;
                }




            }
        }

        public void WriteData()
        {
            string[] writeData = new string[DataStorage.Persons.Count * 5];
            int j = 0;
            for (int i = 0; i < DataStorage.Persons.Count; i++)
            {


                writeData[j] = DataStorage.Persons[i].Id.ToString();
                writeData[j + 1] = DataStorage.Persons[i].Name;
                writeData[j + 2] = DataStorage.Persons[i].Email;
                writeData[j + 3] = DataStorage.Persons[i].Password;
                writeData[j + 4] = DataStorage.Persons[i].Role.ToString();


                j += 5;

            }
            File.WriteAllLines(Path, writeData);

        }
    }
}
