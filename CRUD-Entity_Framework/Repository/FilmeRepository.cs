using CRUD_Entity_Framework.Data;
using CRUD_Entity_Framework.Models;
using CRUD_Entity_Framework.Models.Entidades;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Entity_Framework.Repository;

public class FilmeRepository : IFilmeRepository
{
    private readonly FilmeContext _dbContext;

    public FilmeRepository(FilmeContext filmeContext)
    {
        _dbContext = filmeContext;
    }

    public async Task<string> AdicionarAsync(FilmeRequest request)
    {
        try
        {
            if (!request.EhValido())
                throw new Exception("Informações inválidas");

            await _dbContext.Filmes.AddAsync(request.MapRequestToFilme());
            int registrosAfetados = await _dbContext.SaveChangesAsync();

            return registrosAfetados > 0 ? "Adicionado com sucesso." : throw new Exception("Não foi possível adicionar o filme.");

        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<string> AtualizarAsync(FilmeRequest request, int id)
    {
        try
        {
            FilmeResponse filme = await BuscaFilmeAsync(id);
            request.Atualizar(filme);

            _dbContext.Filmes.Update(request.MapRequestToFilme());
            int registrosAfetados = await _dbContext.SaveChangesAsync();

            return registrosAfetados > 0 ? "Atualizado com sucesso." : throw new Exception("Não foi possível atualizar o filme.");
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<FilmeResponse> BuscaFilmeAsync(int id)
    {
        try
        {
            EhIdValido(id);

            Filme filme = await _dbContext.Filmes.Include(x => x.Produtora).FirstOrDefaultAsync(x => x.Id.Equals(id)) ?? throw new Exception("Filme não encontrado.");
            return filme.MapFilmeResponseToFilme();
        }
        catch (Exception)
        {
            throw;
        }
    }

    private static void EhIdValido(int id)
    {
        if (id <= 0) throw new Exception("Filme inválido.");
    }

    public async Task<IEnumerable<FilmeResponse>> BuscaFilmesAsync()
    {
        try
        {
            IEnumerable<FilmeResponse> filmes = _dbContext.Filmes.Include(x => x.Produtora).Select(x => x.MapFilmeResponseToFilme()).ToList();
            return filmes.Any() ? filmes : throw new Exception("Não há nenhum filme na lista.");
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<string> DeletarFilmeAsync(int id)
    {
        try
        {
            EhIdValido(id);
            FilmeResponse filmeResponse = await BuscaFilmeAsync(id);

            _dbContext.Filmes.Remove(filmeResponse.MapFilmeResponseToFilme());
            int registrosAfetados = await _dbContext.SaveChangesAsync();

            return registrosAfetados > 0 ? "Deletado com sucesso." : throw new Exception("Não foi possível deletar o filme.");
        }
        catch (Exception)
        {
            throw;
        }
    }
}
