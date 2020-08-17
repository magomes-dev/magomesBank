using MagomesBank.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagomesBank.Infra.Data.Context.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnName("Nome");

            builder.Property(c => c.Sobrenome)
                .IsRequired()
                .HasColumnName("Sobrenome");

            builder.Property(c => c.UserName)
                .IsRequired()
                .HasColumnName("Username");

            builder.Property(c => c.PasswordHash)
                .IsRequired()
                .HasColumnName("PasswordHash");

            builder.Property(c => c.PasswordSalt)
                .IsRequired()
                .HasColumnName("PasswordSalt");
        }
    }
}
