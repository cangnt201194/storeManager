using Microsoft.AspNet.Identity.EntityFramework;
using StoreManager.Model.Models;
using System.Data.Entity;

namespace StoreManager.Data
{
    public class StoreManagerDbContext : IdentityDbContext<ApplicationUser>
    {
        /// <summary>
        /// Nhận connectionstring trong app.config ở đây là StoreManagerConnection.
        /// Tham khảo về load dữ liệu http://www.ini.vn/2016/05/eager-lazy-explicit-loading.html
        /// </summary>
        public StoreManagerDbContext() : base("StoreManagerConnection")
        {      
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Footer> Footers { set; get; }
        public DbSet<Menu> Menus { set; get; }
        public DbSet<MenuGroup> MenuGroups { set; get; }
        public DbSet<Order> Orders { set; get; }
        public DbSet<OrderDetail> OrderDetails { set; get; }
        public DbSet<Page> Pages { set; get; }
        public DbSet<Post> Posts { set; get; }
        public DbSet<PostCategory> PostCategories { set; get; }
        public DbSet<PostTag> PostTags { set; get; }
        public DbSet<Product> Products { set; get; }
        public DbSet<ProductCategory> ProductCategories { set; get; }
        public DbSet<ProductTag> ProductTags { set; get; }
        public DbSet<Slide> Slides { set; get; }
        public DbSet<SupportOnline> SupportOnlines { set; get; }
        public DbSet<SystemConfig> SystemConfigs { set; get; }

        public DbSet<Tag> Tags { set; get; }
        public DbSet<VisitorStatistic> VisitorStatistics { set; get; }
        public DbSet<Error> Errors { set; get; }

        public DbSet<ApplicationGroup> ApplicationGroups { set; get; }
        public DbSet<ApplicationRole> ApplicationRoles { set; get; }
        public DbSet<ApplicationRoleGroup> ApplicationRoleGroups { set; get; }
        public DbSet<ApplicationUserGroup> ApplicationUserGroups { set; get; }


        public static StoreManagerDbContext Create()
        {
            return new StoreManagerDbContext();
        }
        /// <summary>
        /// Chạy khi khởi tạo entity framework
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityUserRole>().HasKey(i => new { i.UserId, i.RoleId }).ToTable("ApplicationUserRoles");
            modelBuilder.Entity<IdentityUserLogin>().HasKey(i => i.UserId).ToTable("ApplicationUserLogins");
            modelBuilder.Entity<IdentityRole>().ToTable("ApplicationRoles");
            modelBuilder.Entity<IdentityUserClaim>().HasKey(i => i.UserId).ToTable("ApplicationUserClaims");
         
        }
    }
}