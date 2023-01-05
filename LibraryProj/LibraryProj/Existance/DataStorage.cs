using System.Diagnostics;

namespace LibraryProj.Existance;

public static class DataStorage
{

    public static List<Book> Books { get; set; } = new List<Book>();

    public static List<Person> Persons { get; set; } = new List<Person>();


    static DataStorage()
    {
        Books.Add(new Book(Guid.NewGuid(), "hasani nago bala bego", "g1", "ali"));
        Books.Add(new Book(Guid.NewGuid(), "ali nago bala bego", "g2", "reza"));
        Books.Add(new Book(Guid.NewGuid(), "Harry potter", "g3", "mohsen"));
        Books.Add(new Book(Guid.NewGuid(), "Harry potter2", "g3", "mohsen"));

    }


}