using System;

namespace SimpleOnlineShop.SimpleOnlineShop.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        void Rollback();
    }
}