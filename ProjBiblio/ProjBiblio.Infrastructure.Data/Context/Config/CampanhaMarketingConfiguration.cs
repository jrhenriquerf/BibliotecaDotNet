using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjBiblio.Domain.Entities;

namespace ProjBiblio.Infrastructure.Data.Context.Config
{
    public class CampanhaMarketingConfiguration : IEntityTypeConfiguration<CampanhaMarketing>
    {
        public void Configure(EntityTypeBuilder<CampanhaMarketing> builder)
        {
            #region CampanhaMarketing

            builder.HasKey(c => c.MarketingID);

            builder.Property(t => t.Descricao)
                .IsRequired()
                .HasMaxLength(500);

            #endregion
        }
    }
}