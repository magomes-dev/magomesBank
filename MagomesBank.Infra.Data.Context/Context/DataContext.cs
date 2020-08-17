using MagomesBank.Domain.Models;
using MagomesBank.Infra.Data.Context.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace MagomesBank.Infra.Data.Context.Context
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        //public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));
            //optionsBuilder.UseSqlServer(@"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=teste;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<ContaCorrente> ContasCorrentes { get; set; }
        public DbSet<HistoricoMovimento> HistoricoMovimentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ContaCorrente>(new ContaCorrenteMap().Configure);
            modelBuilder.Entity<HistoricoMovimento>(new HistoricoMovimentoMap().Configure);
            modelBuilder.Entity<Usuario>(new UsuarioMap().Configure);
        }
    }
}
