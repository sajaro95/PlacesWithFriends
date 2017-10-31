namespace PWF.Data.Repository
{
    using PWF.Model;
    using PWF.Data.Interface;
    using System.Collections.Generic;
    using PWF.Data.Context;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly IPWFContext _context;

        public UserRepository(IPWFContext context)
            :base(context)
        {
            _context = context;
        }

        public User Get(int userId)
        {
            return _context.Users
                .Include(u => u.MainUserBuddies)
                .SingleOrDefault(u => u.Id == userId);
        }
    }
}
