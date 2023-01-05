using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using LibraryProj.Existance;
using LibraryProj.Repository;

namespace LibraryProj.Services
{
    public class Enterance : IAuthentication
    {

        public int Login(string Email, string Pass, out Member? member)
        {

            for (int i = 0; i < DataStorage.Persons.Count; i++)
            {
                if (Email == DataStorage.Persons[i].Email &&
                    Pass == DataStorage.Persons[i].Password)
                {
                    if (DataStorage.Persons[i].Role == 1) {
                        Member member1 = new Member();
                        member1.Name = DataStorage.Persons[i].Name;
                        member1.Email = DataStorage.Persons[i].Email;
                        member1.Password = DataStorage.Persons[i].Password;
                        member1.Id = DataStorage.Persons[i].Id;
                        member1.MyBooks = DataStorage.Persons[i].MyBooks;
                        member1.Role = DataStorage.Persons[i].Role;
                        member = member1;
                    }

                    else
                        member = null;
                    return DataStorage.Persons[i].Role;
                }
            }



            member = null;
            return -1;
        }


        public bool CheckMemberExistance(string Email)
        {
            for (int i = 0; i < DataStorage.Persons.Count; i++)
            {
                if (Email == DataStorage.Persons[i].Email)
                {
                    return true;
                }
            }

            return false;
        }


        public bool Register(string Name, string Email, string Pass, Byte Role)
        {
            if (CheckMemberExistance(Email))
            {
                Console.WriteLine("you have already registered!");
                return false;
            }
            else
            {
                if (Role == 0)
                {
                    Librarian librarian = new Librarian();

                    librarian.Id = Guid.NewGuid();
                    librarian.Name = Name;
                    librarian.Email = Email;
                    librarian.Password = Pass;
                    librarian.Role = Role;
                    DataStorage.Persons.Add(librarian);
                    Console.WriteLine("register successfully!");
                }

                else if (Role == 1)
                {
                    Member member = new Member();

                    member.Id = Guid.NewGuid();
                    member.Name = Name;
                    member.Email = Email;
                    member.Password = Pass;
                    member.Role = Role;
                    DataStorage.Persons.Add(member);
                    Console.WriteLine("register successfully!");

                }
                return true;

            }
        }



    }
}
