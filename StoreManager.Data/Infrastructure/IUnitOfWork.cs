namespace StoreManager.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}