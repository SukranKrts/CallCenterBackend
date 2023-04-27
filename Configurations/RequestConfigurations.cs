using CallCenterProject.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CallCenterProject.Configurations
{
    public class RequestConfigurations : IEntityTypeConfiguration<RequestEntity>
    {
        public void Configure(EntityTypeBuilder<RequestEntity> builder)
        {
            builder.ToTable(nameof(RequestEntity));
            builder.HasKey(p => p.RequestId);

            builder.HasOne(p => p.Customer)
                .WithMany(p => p.Requests)
                .HasForeignKey(p => p.RequestId)
                .HasConstraintName("Request_Customer")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Representative)
                .WithMany(p => p.Requests)
                .HasForeignKey(p => p.RepresentativeId)
                .HasConstraintName("Request_Representative")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
