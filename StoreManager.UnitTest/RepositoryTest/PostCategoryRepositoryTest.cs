using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreManager.Data.Infrastructure;
using StoreManager.Data.Repositories;
using StoreManager.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager.UnitTest.RepositoryTest
{
    [TestClass]
    public class PostCategoryRepositoryTest
    {
        IDbFactory dbFactory;
        IPostCategoryRepository objRepository;
        IUnitOfWork unitOfWork;
        [TestInitialize]
        public void Initialize()
        {
            dbFactory = new DbFactory();
            objRepository = new PostCategoryRepository(dbFactory);
            unitOfWork = new UnitOfWork(dbFactory);
        }
        [TestMethod]
        public void PostCategory_Repository_GetAll()
        {//test so sánh số bản ghi
            var list = objRepository.GetAll().ToList();
            Assert.AreEqual(3, list.Count());
        }
        [TestMethod]
        public void PostCategory_Repository_Create()
        {
            PostCategory category = new PostCategory();
            category.Name = "Test category";
            category.Alias = "Test-category";
            category.Status = true;
            var result = objRepository.Add(category);
            unitOfWork.Commit();
            //test kiểm tra dữ liệu
            Assert.IsNotNull(result);
            Assert.AreEqual(true, result.Status);
            
        }
    }
}
