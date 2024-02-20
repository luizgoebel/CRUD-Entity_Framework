using System.ComponentModel.DataAnnotations;

namespace CRUD_Entity_Framework.Models.Entidades;

public class Produtora
{
    [Key]
    public int Id { get; set; }
    public string Nome { get; set; }
    public virtual List<Filme> Filmes { get; set; }
}
