using Account.Service.Domain.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Account.Service.Infrastructure.Data.DataModelConfigurations
{
    internal class AccountDataModelConfiguration : IEntityTypeConfiguration<AccountDataModel>
    {
        public void Configure(EntityTypeBuilder<AccountDataModel> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(128);
            builder.HasIndex(x => x.Name).IsUnique();
        }
    }
}
