﻿// <auto-generated />
using System;
using MagomesBank.Infra.Data.Context.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MagomesBank.Infra.Data.Context.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MagomesBank.Domain.Models.ContaCorrente", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnName("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdUsuario")
                        .HasColumnName("IdUsuario")
                        .HasColumnType("int");

                    b.Property<decimal>("Saldo")
                        .HasColumnName("Saldo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("ContaCorrente");
                });

            modelBuilder.Entity("MagomesBank.Domain.Models.HistoricoMovimento", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataMovimento")
                        .HasColumnName("DataMovimento")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdContaCorrente")
                        .HasColumnName("IdContaCorrente")
                        .HasColumnType("int");

                    b.Property<int>("TipoMovimento")
                        .HasColumnName("TipoMovimento")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorMovimento")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("IdContaCorrente");

                    b.ToTable("HistoricoMovimento");
                });

            modelBuilder.Entity("MagomesBank.Domain.Models.Usuario", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Sobrenome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("MagomesBank.Domain.Models.ContaCorrente", b =>
                {
                    b.HasOne("MagomesBank.Domain.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId");
                });

            modelBuilder.Entity("MagomesBank.Domain.Models.HistoricoMovimento", b =>
                {
                    b.HasOne("MagomesBank.Domain.Models.ContaCorrente", "ContaCorrente")
                        .WithMany("Movimentos")
                        .HasForeignKey("IdContaCorrente")
                        .HasConstraintName("FK_CC_HISTMOVIMENTOS")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
