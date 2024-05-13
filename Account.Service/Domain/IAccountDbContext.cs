using Account.Service.Domain.DataModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Account.Service.Domain
{
    internal interface IAccountDbContext
    {
        DbSet<AccountDataModel> Accounts { get; set; }
        DbSet<CompanyDataModel> Companies { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
