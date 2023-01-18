using System.ComponentModel.DataAnnotations;

namespace PAM.Domain;

public abstract class Entity // Se alterar essa classe, precisa criar uma nova migration pra atualizar o BD
{
    public Guid Id { get; set; } // Todos    
    public string Author { get; set; } // Todos
    public string Name { get; set; } // Todos
    public DateTime ReleaseDate { get; set; } // Todos
    public string Genre { get; set; } // Todos - Integrar a classe de gênero
    public string Country { get; set; } // Todos - Integrar a classe de países e continentes   

    public Entity()
    {
        Id = Guid.NewGuid();
    }
}
