namespace PWF.Data.Interface
{
    using PWF.Model;

    public interface IUserRepository : IGenericRepository<User>
    {
        User Get(int userId);
    }
}
