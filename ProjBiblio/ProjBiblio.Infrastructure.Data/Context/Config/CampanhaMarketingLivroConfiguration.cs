using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjBiblio.Domain.Entities;

namespace ProjBiblio.Infrastructure.Data.Context.Config
{
    public class CampanhaMarketingLivroConfiguration : IEntityTypeConfiguration<CampanhaMarketingLivro>
    {
        public void Configure(EntityTypeBuilder<CampanhaMarketingLivro> builder)
        {
            #region CampanhaMarketingLivro

            builder.HasKey(bc => new { bc.LivroID, bc.MarketingID });

            builder.HasOne(bc => bc.Livro)
                .WithMany(b => b.LivMarketing)
                .HasForeignKey(bc => bc.LivroID);

            builder.HasOne(bc => bc.CampanhaMarketing)
                .WithMany(c => c.LivMarketing)
                .HasForeignKey(bc => bc.MarketingID);

            #endregion
        }
    }
}