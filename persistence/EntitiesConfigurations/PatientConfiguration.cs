﻿

using DomainLayer.Entities;
using DomainLayer.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace persistence.EntitiesConfigurations
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable("Patients");

            builder.Property(x => x.address).HasColumnType("varchar").HasMaxLength(256).IsRequired(false);
            builder.Property(x => x.dateOfBirth).HasColumnType("date").IsRequired(false);
            builder.Property(x => x.Name).HasColumnType("varchar").HasMaxLength(256).IsRequired();
            builder.Property(x => x.phone).HasColumnType("varchar").HasMaxLength(256).IsRequired();
            builder.Property(x => x.gender)
                                           .HasConversion(
                                               v => v.ToString(),
                                               v => (Gender)Enum.Parse(typeof(Gender), v)
                                           );
        }
    }

}
