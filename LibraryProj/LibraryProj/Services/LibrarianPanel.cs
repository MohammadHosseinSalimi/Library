using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryProj.Existance;
using LibraryProj.Repository;

namespace LibraryProj.Services
{
    public class LibrarianPanel : ILibrarianRepository
    {
        public void AddBook()
        {
            Book book = new Book();
            Console.WriteLine("please insert book name and author: ");
            book.Name = Console.ReadLine();
            book.Author = Console.ReadLine();
            while (true)
            {
                Console.WriteLine("Please insert the genre (1 to 4): ");
                string genre = Console.ReadLine();
                if (genre == "1" || genre == "2" || genre == "3" || genre == "4")
                {
                    book.Genre = "g" + genre;
                    break;
                }
                else
                {
                    Console.WriteLine("Please insert a correct genre");
                }
            }

            book.Status = true;
            DataStorage.Books.Add(book);
            Console.WriteLine("Your book added successfully");


        }

        public void RemoveBook()
        {
            GetListOfLibraryBooks();
            Console.WriteLine("please insert the number of the book:");
            int numberOfTheBook = Convert.ToInt32(Console.ReadLine());
            DataStorage.Books.Remove(DataStorage.Books[numberOfTheBook - 1]);
            Console.WriteLine("You have removed the book successfully!");
        }

        public void PrintBook(Book book)
        {
            for (int i = 0; i < DataStorage.Books.Count; i++)
            {
                Console.WriteLine($"{i + 1} --- {DataStorage.Books[i].Name}");
            }
            Console.WriteLine("please insert a number:");
            int readbook = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(DataStorage.Books[readbook - 1].ToString());
        }

        public void GetListOfLibraryBooks()
        {
            for (int i = 0; i < DataStorage.Books.Count; i++)
            {

                if (DataStorage.Books[i].Status == true)
                {
                    Console.WriteLine((i + 1) + "-" + DataStorage.Books[i].ToString());
                }
            }
        }
    }
}
