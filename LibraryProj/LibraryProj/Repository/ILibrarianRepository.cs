using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryProj.Existance;

namespace LibraryProj.Repository
{
    public interface ILibrarianRepository
    {

        public void AddBook();
        public void RemoveBook();

        public void GetListOfLibraryBooks();
        public void PrintBook(Book book);

    }
}
