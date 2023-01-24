namespace PAM.Infra.Data;

public class ApplicationDbContext : IdentityDbContext<IdentityUser> //Herança da classe de contexto e autenticação do Banco de Dados
{
    public DbSet<Album> Albums { get; set; } // Criação da tabela da classe Album no banco de dados
    public DbSet<Book> Books { get; set; } // Criação da tabela da classe Book no banco de dados
    public DbSet<Game> Games { get; set; } // Criação da tabela da classe Book no banco de dados


    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) // Herança das opções de configuração da base de dados
    {
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configuration) // Método de configurações globais das propriedades das classes no BD
    {
        // Exemplo: configuration.Properties<string>().HaveMaxLength(100); Número máximo de carateres de todas as strings da solução é de 100 caracteres. 
        configuration.Properties<string>().HaveMaxLength(200);
        configuration.Properties<int>().HaveMaxLength(1000);            
    }

    protected override void OnModelCreating(ModelBuilder builder) // Método de configurações específicas das propriedades das classes dos dados no BD
    {
        base.OnModelCreating(builder);
        
        // Albums            

        builder.Entity<Album>().Property(p => p.Id).HasColumnOrder(0);
        builder.Entity<Album>().Property(p => p.Author).HasColumnName("Banda").IsRequired().HasColumnOrder(2);
        builder.Entity<Album>().Property(p => p.Name).HasColumnName("Álbum").IsRequired().HasColumnOrder(1);
        builder.Entity<Album>().Property(p => p.ReleaseDate).HasColumnName("Ano de Lançamento").HasColumnOrder(7);
        builder.Entity<Album>().Property(p => p.Tracks).HasColumnName("Nº de Faixas").HasColumnOrder(3);
        builder.Entity<Album>().Property(p => p.Lenght).HasColumnName("Duração").HasColumnOrder(6);
        builder.Entity<Album>().Property(p => p.Genre).HasColumnName("Gênero").HasColumnOrder(4);
        builder.Entity<Album>().Property(p => p.Country).HasColumnName("País").HasColumnOrder(5);

        // Books            

        builder.Entity<Book>().Property(p => p.Id).HasColumnOrder(0);
        builder.Entity<Book>().Property(p => p.Author).HasColumnName("Autor").IsRequired().HasColumnOrder(2);
        builder.Entity<Book>().Property(p => p.Name).HasColumnName("Título").IsRequired().HasColumnOrder(1);
        builder.Entity<Book>().Property(p => p.ReleaseDate).HasColumnName("Ano de Lançamento").HasColumnOrder(7);
        builder.Entity<Book>().Property(p => p.Pages).HasMaxLength(1000).HasColumnName("Nº de Páginas").HasColumnOrder(4);
        builder.Entity<Book>().Property(p => p.Publisher).HasColumnName("Editora").HasColumnOrder(3);
        builder.Entity<Book>().Property(p => p.Genre).HasColumnName("Gênero").HasColumnOrder(5);
        builder.Entity<Book>().Property(p => p.Country).HasColumnName("País").HasColumnOrder(6);

        // Books            

        builder.Entity<Game>().Property(p => p.Id).HasColumnOrder(0);
        builder.Entity<Game>().Property(p => p.Author).HasColumnName("Desenvolvedora").IsRequired().HasColumnOrder(2);
        builder.Entity<Game>().Property(p => p.Name).HasColumnName("Título").IsRequired().HasColumnOrder(1);
        builder.Entity<Game>().Property(p => p.ReleaseDate).HasColumnName("Ano de Lançamento").HasColumnOrder(7);
        builder.Entity<Game>().Property(p => p.Multiplayer).HasColumnName("Multiplayer").HasColumnOrder(8);
        builder.Entity<Game>().Property(p => p.Platform).HasColumnName("Plataformas").IsRequired().HasColumnOrder(4);
        builder.Entity<Game>().Property(p => p.Publisher).HasColumnName("Editora").IsRequired().HasColumnOrder(3);
        builder.Entity<Game>().Property(p => p.Genre).HasColumnName("Gênero").HasColumnOrder(5);
        builder.Entity<Game>().Property(p => p.Country).HasColumnName("País").HasColumnOrder(6);
    }

}
