namespace StoreManager.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory dbFactory;
        private StoreManagerDbContext dbContext;

        public void Commit()
        {
            dbContext.SaveChanges();
        }

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public StoreManagerDbContext DbContext
        {
            get { return DbContext ?? (dbContext = dbFactory.Init()); }
        }
    }
}