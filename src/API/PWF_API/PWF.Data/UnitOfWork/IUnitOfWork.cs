namespace PWF.Data.UnitOfWork
{
    using System;
    using Model;
    using PWF.Data.Interface;

    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<User> UserRepository { get; }
        void Save();
    }
}
