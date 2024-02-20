using CRUD_Entity_Framework.Models;

namespace CRUD_Entity_Framework.Repository;

public interface IFilmeRepository
{
    Task<IEnumerable<FilmeResponse>> BuscaFilmesAsync();
    Task<FilmeResponse> BuscaFilmeAsync(int id);
    void AdicionarAsync(FilmeRequest request);
    void AtualizarAsync(FilmeRequest request, int id);
    void DeletarFilmeAsync(int id);
}
