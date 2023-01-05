using LibraryProj.Existance;

namespace LibraryProj.Repository;

public interface IAuthentication
{
    public int Login(string Email, string Pass, out Member member);
    public bool Register(string Name, string Email, string Pass, byte Role);
}