using CRUD_Entity_Framework.Models.Entidades;
using System.ComponentModel.DataAnnotations;

namespace CRUD_Entity_Framework.Models;

public class FilmeResponse
{
    [Key]
    public int Id { get; set; }
    public string Nome { get; set; }
    public int Ano { get; set; }
    public string Produtora { get; set; }
    public Filme MapFilmeResponseToFilme()
    {
        return new(this.Nome, this.Ano);
    }
}
