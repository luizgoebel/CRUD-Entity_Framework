using CRUD_Entity_Framework.Models.Entidades;

namespace CRUD_Entity_Framework.Models;

public class FilmeRequest
{
    public string Nome { get; set; }
    public int Ano { get; set; }
    public int ProdutoraId { get; set; }

    public bool EhValido()
    => !string.IsNullOrEmpty(this.Nome) || this.Ano != 0 || this.ProdutoraId != 0;
    public void Atualizar(FilmeResponse filme)
    {
        if (string.IsNullOrEmpty(this.Nome)) this.Nome = filme.Nome;
        if (this.Ano <= 0) this.Ano = filme.Ano;
    }
    public Filme MapRequestToFilme()
    {
        return new(this.Nome, this.Ano, this.ProdutoraId);
    }
    
}
