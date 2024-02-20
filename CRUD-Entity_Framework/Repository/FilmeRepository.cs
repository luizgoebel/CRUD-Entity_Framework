using CRUD_Entity_Framework.Data;
using CRUD_Entity_Framework.Models;
using CRUD_Entity_Framework.Models.Entidades;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Entity_Framework.Repository;

public class FilmeRepository : IFilmeRepository
{
    private readonly FilmeContext _context;

    public FilmeRepository(FilmeContext filmeContext)
    {
        _context = filmeContext;
    }

    public async void AdicionarAsync(FilmeRequest request)
    {
        try
        {
            if (!request.EhValido())
                throw new Exception("Informações inválidas");

            await _context.Filmes.AddAsync(request.MapRequestToFilme());

        }
        catch (Exception)
        {
            throw;
        }
    }

    public async void AtualizarAsync(FilmeRequest request, int id)
    {
        try
        {
            FilmeResponse filme = await BuscaFilmeAsync(id);
            request.Atualizar(filme);

            _context.Filmes.Update(request.MapRequestToFilme());
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

            Filme filme = await _context.Filmes.Include(x => x.Produtora).FirstOrDefaultAsync(x => x.Id.Equals(id)) ?? throw new Exception("Filme não encontrado.");
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
            return _context.Filmes.Include(x => x.Produtora).Select(x => x.MapFilmeResponseToFilme()).ToList();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async void DeletarFilmeAsync(int id)
    {
        try
        {
            EhIdValido(id);
            FilmeResponse filmeResponse = await BuscaFilmeAsync(id);

            _context.Filmes.Remove(filmeResponse.MapFilmeResponseToFilme());
        }
        catch (Exception)
        {
            throw;
        }
    }
}
