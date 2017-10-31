namespace PWF.Data.UnitOfWork
{
    using System;
    using PWF.Data.Context;
    using PWF.Data.Interface;
    using PWF.Data.Repository;
    using PWF.Model;

    public class UnitOfWork : IUnitOfWork
    {
        private IPWFContext _context;
        private IUserRepository userRepository;
        private IBuddyRepository buddyRepository;

        public UnitOfWork(IPWFContext context)
        {
            _context = context;
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (this.userRepository == null)
                {
                    this.userRepository = new UserRepository(_context);
                }
                return userRepository;
            }
        }

        public IBuddyRepository BuddyRepository
        {
            get
            {
                if (this.buddyRepository == null)
                {
                    this.buddyRepository = new BuddyRepository(_context);
                }
                return buddyRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
