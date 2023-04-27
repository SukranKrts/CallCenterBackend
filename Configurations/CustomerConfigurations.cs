using CallCenterProject.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CallCenterProject.Configurations
{
    public class CustomerConfigurations : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable(nameof(Customer));
            builder.HasKey(x => x.CustomerId);
        }
    }
}
