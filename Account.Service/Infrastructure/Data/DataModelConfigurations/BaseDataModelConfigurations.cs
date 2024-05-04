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
    public class BaseDataModelConfiguration<T> : IEntityTypeConfiguration<BaseDataModel<T>> where T : struct
    {
        void IEntityTypeConfiguration<BaseDataModel<T>>.Configure(EntityTypeBuilder<BaseDataModel<T>> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Created).HasDefaultValueSql("getdate()");
        }
    }
}
