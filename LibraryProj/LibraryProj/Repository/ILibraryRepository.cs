using LibraryProj.Existance;

namespace LibraryProj.Repository;

public interface ILibraryRepository
{
    public bool BorrowBook(Book book, Member member);
    public bool ReturnBook(Book book, Member member);
    public void GetListOfLibraryBooks();
    public void GetListOfUserBooks(Member member);
}