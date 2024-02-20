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
    public Filme(int id, string nome, int ano)
    {
        Id = id;
        Nome = nome;
        Ano = ano;
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

    public FilmeResponse MapFilmeResponseToFilme() => new()
    {
        Id = this.Id,
        Nome = this.Nome,
        Ano = this.Ano,
        Produtora = this.Produtora.Nome
    };
    public void Atualizar(FilmeRequest request)
    {
        if (request.Ano > 0) this.Ano = request.Ano;
        if (!string.IsNullOrEmpty(request.Nome)) this.Nome = request.Nome;
    }
}
