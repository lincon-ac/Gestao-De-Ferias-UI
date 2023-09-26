using Entities.Entidades;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Configuracao
{
    public class ContextBase : IdentityDbContext<ApplicationUser>
    {
        public ContextBase( DbContextOptions options) : base(options)
        {
        }

        public DbSet<FuncionarioFinanceiro> FuncionarioFinanceiro { set; get; }
        public DbSet<UsuarioFuncionarioFinanceiro> UsuarioFuncionarioFinanceiro { set; get; }
        public DbSet<Departamento> Departamento { set; get; }
        public DbSet<Ferias> Ferias { set; get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ObterStringConexao());
                base.OnConfiguring(optionsBuilder);
            }
        }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(t => t.Id);

            base.OnModelCreating(builder);
        }


        public string ObterStringConexao()
        {
            //return "Data Source=LAPTOP-J599BNQD\\MSSQLSERVER01;Initial Catalog=GESTAO_DE_FERIAS;Integrated Security=False;User ID=sa;Password=1234;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";

            return "Data Source=LAPTOP-J599BNQD\\SQLEXPRESS;Initial Catalog=GESTAO_DE_FERIAS3;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True";
        }


    }
}
