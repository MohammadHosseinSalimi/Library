using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryProj.Existance;
using LibraryProj.Repository;

namespace LibraryProj.Services
{
    public class MemberPanel: ILibraryRepository
    {
        public bool BorrowBook(Book book, Member member)
        {

            if (member.Role == 1)
            {
                if (book.Status == true)
                {
                    member.MyBooks.Add(book);
                    book.Status = false;
                    book.BorrowDate = DateTime.Now;
                    Console.WriteLine("you borrow this book successfully!");
                    return true;
                }
                else
                {
                    Console.WriteLine("this book has already borrowed!");
                    return false;
                }
            }

            return false;
        }

        public bool ReturnBook(Book book, Member member)
        {
            if (member.Role == 1)
            {

                member.MyBooks.Remove(book);
                book.Status = true;
                book.BorrowDate = null;
                Console.WriteLine("you return this book successfully!");
                return true;

            }

            return false;
        }


        public void GetListOfBorrowBooks()
        {
            List<string> listGenre = new List<string>();

            for (int i = 0; i < DataStorage.Books.Count; i++)
            {


                if (DataStorage.Books[i].Status == true)
                {
                    listGenre.Add(DataStorage.Books[i].Genre);

                    //Console.WriteLine((i + 1) + "-" + DataStorage.Books[i].ToString());
                }
            }

            listGenre = listGenre.Distinct().ToList();
            foreach (var item in listGenre)
            {
                Console.WriteLine(item);
            }

        }

        public void ShowRelatedBooks()
        {

            Console.WriteLine("which genre do you want to borrow? (press g1 to g4)");
            string genre = Console.ReadLine();

            for (int i = 0; i < DataStorage.Books.Count; i++)
            {
                if (DataStorage.Books[i].Status == true && genre == DataStorage.Books[i].Genre)
                {
                    Console.WriteLine(DataStorage.Books[i]);


                }


            }
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

        public void GetListOfUserBooks(Member member)
        {

            for (int i = 0; i < member.MyBooks.Count; i++)
            {
                Console.WriteLine((i + 1) + "-" + member.MyBooks[i].ToString());
            }
        }

    }
}
