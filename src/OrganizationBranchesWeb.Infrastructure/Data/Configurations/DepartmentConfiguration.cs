using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrganizationBranchesWeb.Domain.Constants;
using OrganizationBranchesWeb.Domain.Model;
using OrganizationBranchesWeb.Infrastructure.Data.Constants;

namespace OrganizationBranchesWeb.Infrastructure.Data.Configurations
{
	public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
	{
		public void Configure(EntityTypeBuilder<Department> builder)
		{
			_ = builder ?? throw new ArgumentNullException(nameof(builder));

			builder.ToTable(TableConstants.Departments, SchemaConstant.Departments)
			   .HasKey(department => department.Id);

			builder.Property(department => department.Name)
				.IsRequired()
				.HasMaxLength(FieldLengthsConstants.MaxLengthShortMedium);

			builder.Property(department => department.Address)
				.IsRequired()
				.HasMaxLength(FieldLengthsConstants.MaxLengthLongMedium);

			builder.Property(department=>department.IsOpen)
				.IsRequired();
		}
	}
}
