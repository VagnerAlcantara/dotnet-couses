using SpaUserControl.Domain.Models;
using SpaUserControl.Infra.Data.Map;
using System.Data.Entity;

namespace SpaUserControl.Infra.Data
{
    public class AppDataContext : DbContext
    {
        public AppDataContext()
            :base("AppConnectionString")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMap());
        }

        public DbSet<User> Users { get; set; }
    }
}
