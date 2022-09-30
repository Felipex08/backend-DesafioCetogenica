using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioCetogenica.API.Database
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) {}

        public virtual DbSet<td_dados_formulario> td_dados_formulario { get; set; }
        public virtual DbSet<tb_dados_instagram> tb_dados_instagram { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = "server=br174.hostgator.com.br;port=3306;database=vaniag45_db-desafio-cetogenica;uid=vaniag45_felipe;password=Timao123*";
                optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<td_dados_formulario>().ToTable("td_dados_formulario");
            modelBuilder.Entity<td_dados_formulario>().HasKey(p => p.id);
            modelBuilder.Entity<td_dados_formulario>().Property(p => p.nome).HasColumnType("varchar(100)");
            modelBuilder.Entity<td_dados_formulario>().Property(p => p.telefone).HasColumnType("varchar(100)");
            modelBuilder.Entity<td_dados_formulario>().Property(p => p.email).HasColumnType("varchar(100)");

            modelBuilder.Entity<tb_dados_instagram>().ToTable("tb_dados_instagram");
            modelBuilder.Entity<tb_dados_instagram>().HasKey(p => p.id);
            modelBuilder.Entity<tb_dados_instagram>().Property(p => p.instagram).HasColumnType("varchar(100)");
        }
    }

    public class td_dados_formulario
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }

    }

    public class tb_dados_instagram
    {
        public int id { get; set; }
        public string instagram { get; set; }
    }
}