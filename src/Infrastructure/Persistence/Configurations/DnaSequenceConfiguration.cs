using mercadolibre_challenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace mercadolibre_challenge.Infrastructure.Persistence.Configurations
{
    public class DnaSequenceConfiguration : IEntityTypeConfiguration<DnaSequence>
    {
        public void Configure(EntityTypeBuilder<DnaSequence> builder)
        {
            builder.Ignore(d => d.DomainEvents);

            builder.HasKey(d => d.Sequence);

            builder.Property(d => d.IsMutant)
                .IsRequired();
        }
    }
}
