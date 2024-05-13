using Account.Service.Domain.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Service.Infrastructure.Data.DataModelConfigurations
{
    internal class CompanyDataModelConfiguration : IEntityTypeConfiguration<CompanyDataModel>
    {
        public void Configure(EntityTypeBuilder<CompanyDataModel> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(128);
            builder.HasIndex(x => x.Name).IsUnique();
            builder.Property(x => x.Description).IsRequired().HasMaxLength(400);
            
            builder.HasMany(x => x.Workers).WithMany(x => x.Company).UsingEntity<CompanyAccountRelationDataModel>(mg => mg.HasOne(prop => prop.Account).WithMany().HasForeignKey(x => x.AccountDataModelId).OnDelete(DeleteBehavior.Restrict),
                mg => mg.HasOne(x => x.Company).WithMany().HasForeignKey(prop => prop.CompanyDataModelId).OnDelete(DeleteBehavior.Restrict),
                mg =>
                {
                    mg.HasKey(prop => new { prop.AccountDataModelId, prop.CompanyDataModelId });
                }
                );
        }
    }
}
