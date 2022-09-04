using Balta.Domain.Application;
using Balta.Domain.Contracts.Infrascructure;
using Balta.Infra.Data;

namespace Balta.Infra.Repositories;

public class AulaRepository : IRepositoryAula
{
    private readonly DataContext _dataContext;

    public AulaRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
        _dataContext.Database.EnsureCreated();
    }

    public async Task CriarNovaAula(Aula aula)
    {
        await _dataContext.Aulas.AddAsync(aula);
        await _dataContext.SaveChangesAsync();
    }
    
    public List<Aula>? ListarAulas(int moduloIdentificador)
    {
        var listaAulas = new List<Aula>();
        bool possuiAlgumaAula = false;
        foreach (var aula in _dataContext.Aulas) 
        {
            if (aula.IdentificadorModulo == moduloIdentificador)
            {
                listaAulas.Add(aula);
                possuiAlgumaAula = true;
                continue;
            }
        }
        return possuiAlgumaAula ? listaAulas : null;
    }

    public Aula? BuscarAula(string url)
    {
        foreach (var aula in _dataContext.Aulas)
        {
            if (aula.Url == url)
            {
                return aula;
            }
        }

        return null;
    }
}
