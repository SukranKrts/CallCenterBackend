using CallCenterProject.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CallCenterProject.Configurations
{
    public class InterviewConfigurations : IEntityTypeConfiguration<Interview>
    {
        public void Configure(EntityTypeBuilder<Interview> builder)
        {
            builder.ToTable("Interview");
            builder.HasKey("InterviewId");

            builder.HasOne(p => p.Representative)
                .WithMany(p => p.Interviews)
                .HasForeignKey(p => p.RepresentativeId)
                .HasConstraintName("Representative_Interview")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Customer)
                .WithMany(p => p.Interviews)
                .HasForeignKey(p => p.CustomerId)
                .HasConstraintName("Customer_Interview")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
