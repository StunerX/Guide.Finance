using Guide.Finance.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Guide.Finance.EntityFramework.Configurations;

public class TradingConfiguration : IEntityTypeConfiguration<Trading>
{
    public void Configure(EntityTypeBuilder<Trading> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Symbol);
        builder.Property(x => x.Price);
        builder.Property(x => x.CreatedAt);
    }
}