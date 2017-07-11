﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager.Data.Infrastructure
{
    //tự động hủy các phương thức
    public class Disposable : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public bool isDisposed;

        ~Disposable()
        {
            Dispose(false);
        }

        private void Dispose(bool disposing)
        {
            if (!isDisposed && disposing)
            {
                DisposeCore();
            }
            isDisposed = true;
        }

        protected virtual  void DisposeCore()
        {
           
        }
    }
}
