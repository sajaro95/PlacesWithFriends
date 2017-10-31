namespace PWF.Data.Repository
{
    using PWF.Model;
    using PWF.Data.Interface;
    using System.Collections.Generic;
    using PWF.Data.Context;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    public class BuddyRepository : GenericRepository<Buddy>, IBuddyRepository
    {
        private readonly IPWFContext _context;

        public BuddyRepository(IPWFContext context)
            : base(context)
        {
            _context = context;
        }

        public IEnumerable<Buddy> Get()
        {
            return _context.Buddies
                .Include(b => b.BuddyUser)
                .Include(b => b.MainUser);
        }

        public IEnumerable<Buddy> GetByMainUserId(int mainUserId)
        {
            return _context.Buddies
                .Include(b => b.BuddyUser)
                .Include(b => b.MainUser)
                .Where(b => b.MainUserId == mainUserId);
        }

        public void Delete(int mainUserId, int buddyUserId)
        {
            _context.Buddies.RemoveRange(_context.Buddies.Where(b => b.MainUserId == mainUserId && b.BuddyUserId == buddyUserId));
        }
    }
}
