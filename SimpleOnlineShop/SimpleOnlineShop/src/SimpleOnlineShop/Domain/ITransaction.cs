using System;

namespace SimpleOnlineShop.SimpleOnlineShop.Domain
{
    public interface ITransaction : IDisposable
    {
        void Commit();
        void Rollback();
    }
}