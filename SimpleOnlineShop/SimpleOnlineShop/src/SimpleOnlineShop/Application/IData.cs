namespace SimpleOnlineShop.SimpleOnlineShop.Application
{
    interface IData<in TEntity>
    {
        IData<TEntity> Fill(TEntity entity);
    }
}