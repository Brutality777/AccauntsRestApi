using Account.Service.Domain;
using Account.Service.Domain.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Account.Service.Infrastructure.Data
{
    internal class AccountDbContext : DbContext, IAccountDbContext
    {
        public DbSet<AccountDataModel> Accounts { get; set; }
        DbSet<CompanyAccountRelationDataModel> CompaniesRelation { get; set; }
        public DbSet<CompanyDataModel> Companies { get; set; }

        public AccountDbContext(DbContextOptions<AccountDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("AccountModule");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AccountDbContext).Assembly);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            var entries = ChangeTracker.Entries();
            foreach (var entry in entries)
            {
                switch (entry.Entity)
                {
                    case BaseDataModel<int> trackable:
                        switch (entry.State)
                        {
                            case EntityState.Added:
                                trackable.Updated = DateTime.UtcNow;
                                break;
                            case EntityState.Modified:
                                trackable.Updated = DateTime.UtcNow;
                                break;
                        }

                        break;
                    case CompanyAccountRelationDataModel trackable:
                        switch(entry.State) {
                            case EntityState.Added:
                                trackable.JoinDate = DateTime.UtcNow;
                                break;
                        }
                        break;
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
