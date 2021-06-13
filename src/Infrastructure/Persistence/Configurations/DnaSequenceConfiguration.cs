using mercadolibre_challenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace mercadolibre_challenge.Infrastructure.Persistence.Configurations
{
    public class DnaSequenceConfiguration : IEntityTypeConfiguration<DnaSequence>
    {
        public void Configure(EntityTypeBuilder<DnaSequence> builder)
        {
            builder.Ignore(e => e.DomainEvents);

            builder.HasKey(d => d.Sequence);

            builder.Property(t => t.IsMutant)
                .IsRequired();
        }
    }
}
