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
    }

    public async Task CriarNovaAula(Aula aula)
    {
        await _dataContext.Aulas.AddAsync(aula);
        await _dataContext.SaveChangesAsync();
    }
    
    public List<Aula> ListarAulas(Modulo modulo)
    {
        var listaAulas = new List<Aula>();
        foreach(var aula in _dataContext.Aulas) listaAulas.Add(aula);
        return listaAulas;
    }
}
