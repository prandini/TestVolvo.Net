using App.Volvo.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Volvo.Data.Mappings
{
    public class CaminhaoMapping : IEntityTypeConfiguration<Caminhao>
    {
        public void Configure(EntityTypeBuilder<Caminhao> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Chassi)
                .IsRequired()
                .HasColumnType("varchar(17)");

            builder.Property(p => p.AnoFabricacao)
                .IsRequired()
                .HasColumnType("smallint");

            builder.Property(p => p.AnoModelo)
                .IsRequired()
                .HasColumnType("smallint");

            //1 : N
            builder.HasOne(p => p.Modelo)
                .WithMany(p => p.Caminhoes)
                .HasForeignKey(p => p.ModeloId);

            builder.ToTable("Caminhoes");
        }
    }
}
