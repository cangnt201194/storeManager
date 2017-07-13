using System;

namespace StoreManager.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        StoreManagerDbContext Init();
    }
}