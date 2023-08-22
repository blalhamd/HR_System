

using DomainLayer.Entities;
using DomainLayer.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace persistence.EntitiesConfigurations
{
    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.ToTable("Appointments");

            builder.Property(x => x.dateTime).HasColumnType("date").IsRequired();
            builder.Property(x => x.status)
                                           .HasConversion(
                                               v => v.ToString(),
                                               v => (StatusAppointment)Enum.Parse(typeof(StatusAppointment), v)
                                           );

        }
    }

}
