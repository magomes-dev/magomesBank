using MagomesBank.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagomesBank.Infra.Data.Context.Mappings
{
    public class HistoricoMovimentoMap : IEntityTypeConfiguration<HistoricoMovimento>
    {        public void Configure(EntityTypeBuilder<HistoricoMovimento> builder)
        {
            builder.ToTable("HistoricoMovimento");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.IdContaCorrente)
                .IsRequired()
                .HasColumnName("IdContaCorrente");

            builder.Property(c => c.DataMovimento)
                .IsRequired()
                .HasColumnName("DataMovimento");

            builder.Property(c => c.TipoMovimento)
                .IsRequired()
                .HasColumnName("TipoMovimento");

            builder.HasOne(c => c.ContaCorrente)
                .WithMany(p => p.Movimentos)
                .HasForeignKey(d => d.IdContaCorrente)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_CC_HISTMOVIMENTOS");
        }
    }
}
