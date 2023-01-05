using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace LibraryProj.Existance;

public class Book
{

    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Genre { get; set; }
    public string Author { get; set; }
    public bool Status { get; set; }

    public DateTime? BorrowDate { get; set; } = new DateTime();

    public Book(Guid Id, string Name, string Genre, string Author)
    {
        this.Id = Id;
        this.Name = Name;
        this.Genre = Genre;
        this.Author = Author;
        Status = true;
    }
    public Book()
    {

    }

    public override string ToString()
    {
        return Name + "--" + Genre + "--" + Author;

    }


    public static Book? getBookObj(string name)
    {

        for (int i = 0; i < DataStorage.Books.Count; i++)
        {
            if (DataStorage.Books[i].Name == name)
                return DataStorage.Books[i];

        }

        return null;

    }


}