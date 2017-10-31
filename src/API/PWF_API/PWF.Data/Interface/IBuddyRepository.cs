namespace PWF.Data.Interface
{
    using PWF.Model;
    using System.Collections.Generic;

    public interface IBuddyRepository : IGenericRepository<Buddy>
    {
        IEnumerable<Buddy> Get();
        IEnumerable<Buddy> GetByMainUserId(int mainUserId);
        void Delete(int mainUserId, int buddyUserId);
    }
}
