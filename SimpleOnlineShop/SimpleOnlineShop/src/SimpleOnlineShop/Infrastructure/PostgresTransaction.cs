using Microsoft.EntityFrameworkCore.Storage;
using SimpleOnlineShop.SimpleOnlineShop.Domain;

namespace SimpleOnlineShop.SimpleOnlineShop.Infrastructure
{
    public class PostgresTransaction : ITransaction
    {
        private  readonly IDbContextTransaction _transaction;

        public PostgresTransaction(UnitOfWork unitOfWork)
        {
            _transaction = unitOfWork.Database.BeginTransaction();
        }

        public void Dispose()
        {
            Rollback();
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }
    }
}