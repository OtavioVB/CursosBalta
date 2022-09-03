using Balta.Domain.Application;
using Balta.Domain.Contracts.Infrascructure;
using Balta.Infra.Data;

namespace Balta.Infra.Repositories;

public class ModuloRepository : IRepositoryModulo
{
    private readonly DataContext _dataContext;

    public CursoRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task CreateAsync(Modulo modulo)
    {
        await _dataContext.AddAsync(modulo);
        await _dataContext.SaveChangesAsync();
    }
}
