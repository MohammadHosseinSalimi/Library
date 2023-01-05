using LibraryProj.Existance;
using LibraryProj.Services;
using Microsoft.VisualBasic.FileIO;
namespace LibraryProj
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            //FileDataRW fileDataRW1=new FileDataRW();
            //fileDataRW1.ReadData();

            FileSerialize fileSerialize1 = new FileSerialize();
            fileSerialize1.ReadData();
            while (true)
            {
                Console.WriteLine("Please enter the menu\n 1.login\n 2.register\n 3.exit");
                int answer;
                answer = Convert.ToInt32(Console.ReadLine());
                if (answer == 1)
                {

                    Console.WriteLine("enter your email and pass: ");
                    string email = Console.ReadLine();
                    string pass = Console.ReadLine();
                    var member = new Member();
                    var enterance = new Enterance();

                    int role = enterance.Login(email, pass, out member);
                    if (role == 0)
                    {
                        Console.WriteLine("login successfully!");
                        Console.Clear();
                        GoToLibrerianMenu();
                    }

                    else if (role == 1)
                    {
                        Console.WriteLine("login successfully!");
                        Console.Clear();
                        GoToMemberMenu(member);
                    }
                    else
                    {
                        Console.WriteLine("wrong information!");
                    }
                    Console.ReadKey();
                    Console.Clear();

                }
                else if (answer == 2)
                {
                    string Name, Email, Pass;
                    byte Role;
                    Console.WriteLine("Enter your Name,Email,Pass,Role (0 for librarian and 1 for members): ");
                    Name = Console.ReadLine();
                    Email = Console.ReadLine();
                    Pass = Console.ReadLine();
                    Role = Convert.ToByte(Console.ReadLine());
                    var enterance = new Enterance();
                    bool register = enterance.Register(Name, Email, Pass, Role);
                    Console.ReadKey();
                    Console.Clear();

                }
                else if (answer == 3)
                {
                    Console.ReadKey();

                  //  FileDataRW fileDataRW = new FileDataRW();
                   // fileDataRW.WriteData();

                    FileSerialize fileSerialize = new FileSerialize();
                    fileSerialize.WriteData();
                    Console.Clear();
                    break;
                }


            }



            void GoToLibrerianMenu()
            {
                bool whileStatus = true;
                while (whileStatus)
                {
                    Console.WriteLine("enter\n1.add\n2.remove\n3.all library books\n4.all loaned books\n5.log out");
                    int answer = Convert.ToInt32(Console.ReadLine());
                    var librerianPanel = new LibrarianPanel();

                    switch (answer)
                    {
                        case 1:

                            librerianPanel.AddBook();

                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 2:


                            librerianPanel.RemoveBook();


                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 3:
                            var book = new Book();
                            librerianPanel.PrintBook(book);
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 4:
                            foreach (var item in DataStorage.Books)
                            {
                                if (item.Status == false)
                                {
                                    Console.WriteLine(item.ToString());
                                }

                            }
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 5:
                            whileStatus = false;
                            Console.Clear();
                            break;

                        default:
                            break;
                    }
                }

            }



            void GoToMemberMenu(Member member)
            {
                bool whileStatus = true;
                MemberPanel memberPanel = new MemberPanel();
                while (whileStatus)
                {
                    Console.WriteLine("enter\n1.borrow\n2.return\n3.all library books\n4.my books\n5.log out");
                    int answer = Convert.ToInt32(Console.ReadLine());

                    switch (answer)
                    {
                        case 1:
                            memberPanel.GetListOfBorrowBooks();
                            memberPanel.ShowRelatedBooks();
                            string bookName = Console.ReadLine();
                            var returnBook = Book.getBookObj(bookName);
                            if (returnBook != null)
                            {
                                memberPanel.BorrowBook(returnBook, member);
                            }
                            else
                            {
                                Console.WriteLine("enter correct name!");
                            }

                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 2:
                            bookName = Console.ReadLine();
                            returnBook = Book.getBookObj(bookName);
                            if (returnBook != null)
                            {
                                memberPanel.ReturnBook(returnBook, member);
                            }
                            else
                            {
                                Console.WriteLine("enter correct name!");
                            }

                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 3:
                            memberPanel.GetListOfLibraryBooks();
                            break;
                        case 4:
                            memberPanel.GetListOfUserBooks(member);
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 5:
                            whileStatus = false;
                            Console.Clear();
                            break;

                        default:
                            break;
                    }
                }

            }









        }
    }
}