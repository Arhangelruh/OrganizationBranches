using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrganizationBranchesWeb.Domain.Constants;
using OrganizationBranchesWeb.Domain.Model;
using OrganizationBranchesWeb.Infrastructure.Data.Constants;

namespace OrganizationBranchesWeb.Infrastructure.Data.Configurations
{
	public class CashConfiguration : IEntityTypeConfiguration<Cash>
	{
		public void Configure(EntityTypeBuilder<Cash> builder)
		{
			_ = builder ?? throw new ArgumentNullException(nameof(builder));

			builder.ToTable(TableConstants.Cashes, SchemaConstant.Departments)
			   .HasKey(cash => cash.Id);

			builder.Property(cash => cash.Name)
				.IsRequired()
				.HasMaxLength(FieldLengthsConstants.MaxLengthShortMedium);

			builder.HasOne(department => department.Department)
			 .WithMany(cash => cash.Cashes)
			 .HasForeignKey(cash => cash.DepartmentId)
			 .OnDelete(DeleteBehavior.Cascade);
		}
	}
}
