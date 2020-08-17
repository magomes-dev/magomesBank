using MagomesBank.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagomesBank.Infra.Data.Context.Mappings
{
    public class ContaCorrenteMap : IEntityTypeConfiguration<ContaCorrente>
    {
        public void Configure(EntityTypeBuilder<ContaCorrente> builder)
        {
            builder.ToTable("ContaCorrente");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Saldo)
                .IsRequired()
                .HasColumnName("Saldo");

            builder.Property(c => c.UsuarioId)
                .IsRequired()
                .HasColumnName("UsuarioId");

            builder.Property(c => c.DataCriacao)
                .IsRequired()
                .HasColumnName("DataCriacao");

            builder.HasMany(c => c.Movimentos)
                .WithOne(e => e.ContaCorrente);
        }
    }
}
