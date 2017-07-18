namespace StoreManager.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private StoreManagerDbContext dbContext;

        public StoreManagerDbContext Init()
        {
            //kiểm tra nếu null thì khởi tạo
            return dbContext ?? (dbContext = new StoreManagerDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
            {
                dbContext.Dispose();
            }
        }
    }
}