using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD_Entity_Framework.Models.Entidades;

public class Filme
{
    public Filme(string nome, int ano, int produtoraId)
    {
        Nome = nome;
        Ano = ano;
        ProdutoraId = produtoraId;
    }
    public Filme(string nome, int ano)
    {
        Nome = nome;
        Ano = ano;
    }

    [Key]
    public int Id { get; set; }
    public string Nome { get; set; }
    public int Ano { get; set; }
    public int ProdutoraId { get; set; }
    [NotMapped]
    public virtual Produtora? Produtora { get; set; }

    public FilmeResponse MapFilmeResponseToFilme()
    {
        return new FilmeResponse()
        {
            Nome = this.Nome,
            Ano = this.Ano,
            Produtora = this.Produtora.Nome
        };
    }
}
