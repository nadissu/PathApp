#nullable disable
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public partial class PathAppContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-T6IPPDN\SQLEXPRESS;Database=PathAppDb;Trusted_Connection=true");
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<CargoCompany> CargoCompanies { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderProduct> OrderProducts { get; set; }
        public virtual DbSet<Shipment> Shipments { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<OperationClaim> OperationClaims { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserOperationClaim> UserOperationClaims { get; set; }

    }
}
