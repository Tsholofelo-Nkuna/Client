using Client.Model.DatabaseViews;
using Client.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.ComponentModel;

namespace Client.SQLServer.DAL
{
    public class WebDbContext: DbContext
    {
        private readonly ConnectionStringConfig _connectionString;

        public virtual DbSet<ClientEntity> Clients { get; set; }

        public virtual DbSet<AddressEntity> Addresses { get; set; }

        public virtual DbSet<ClientDetailsViewItem> ClientDetailsViewItems { get; set; }

        public WebDbContext(IOptions<ConnectionStringConfig> connectionStringConfig)
        {
            this._connectionString = connectionStringConfig.Value;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(this._connectionString.Default);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
          //  base.OnModelCreating(modelBuilder);
            modelBuilder
                .Entity<ClientDetailsViewItem>(e =>
                {
                    e.HasNoKey();
                    e.ToView("ClientDetailsView");

                });
                
        }

       

    }

    public class ConnectionStringConfig
    {
        public string Default { get;set; } = string.Empty;
    }
}
