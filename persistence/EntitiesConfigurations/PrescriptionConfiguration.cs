

using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace persistence.EntitiesConfigurations
{
    public class PrescriptionConfiguration : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {
            builder.ToTable("Prescriptions");

            builder.Property(x => x.dosage).HasColumnType("varchar").HasMaxLength(256).IsRequired(false);
            builder.Property(x => x.frequency).IsRequired();
            builder.Property(x => x.duration).HasColumnType("varchar").HasMaxLength(256).IsRequired();
            builder.Property(x => x.medication).HasColumnType("varchar").HasMaxLength(256).IsRequired();

        }
    }

}
