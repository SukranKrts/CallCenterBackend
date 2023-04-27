using CallCenterProject.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CallCenterProject.Configurations
{
    public class RepresentativeConfigurations : IEntityTypeConfiguration<Representative>
    {
        public void Configure(EntityTypeBuilder<Representative> builder)
        {
            builder.ToTable(nameof(Representative));
            builder.HasKey(p => p.RepId);
        }
    }
}
