using Account.Service.Domain.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Account.Service.Infrastructure.Data.DataModelConfigurations
{
    internal class CompanyAccountRelationConfiguration : IEntityTypeConfiguration<CompanyAccountRelationDataModel>
    {
        public void Configure(EntityTypeBuilder<CompanyAccountRelationDataModel> builder)
        {

        }
    }
}
