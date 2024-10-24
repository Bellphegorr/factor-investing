using FactorInvesting.Modules.Assets.Domain.Securities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FactorInvesting.Modules.Assets.Infrastructure.Domain.Securities;

internal sealed class SecurityEntityTypeConfiguration : IEntityTypeConfiguration<Security>
{
    public void Configure(EntityTypeBuilder<Security> builder)
    {
        builder.ToTable("Securities", "assets");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("SecurityId");
        builder.Property(x => x.Name).HasColumnName("SecurityName");
        builder.Property(x => x.Type).HasColumnName("SecurityType");
    }
}
