namespace PWF.Data.UnitOfWork
{
    using System;
    using Model;
    using PWF.Data.Interface;

    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        IBuddyRepository BuddyRepository { get; }
        void Save();
    }
}
