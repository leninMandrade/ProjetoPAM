using Microsoft.EntityFrameworkCore;
using PAM.Domain.Albums;
using PAM.Domain.Books;

namespace PAM.Infra.Data
{
    public class ApplicationDbContext : DbContext //Herança da classe de contexto do Banco de Dados
    {
        public DbSet<Album> Albums { get; set; } // Criação da tabela da classe Album no banco de dados
        public DbSet<Book> Books { get; set; } // Criação da tabela da classe Book no banco de dados       

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) // Herança das opções de configuração da base de dados
        {
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configuration) // Método de configurações globais das propriedades das classes no BD
        {
            // Exemplo: configuration.Properties<string>().HaveMaxLength(100); Número máximo de carateres de todas as strings da solução é de 100 caracteres. 
        }

        protected override void OnModelCreating(ModelBuilder builder) // Método de configurações específicas das propriedades das classes dos dados no BD
        {
           // Exemplo: builder.Entity<Album>().Property(p => p.Tracks).HasMaxLength(50); Número máximo da propriedade faixas da classe album é de 50.
           // Exemplo: builder.Entity<Book>().Property(p => p.Author).IsRequired();  Torna o preenchimento do campo autor como obrigatório.
           
        }

    }
}
