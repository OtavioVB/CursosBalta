using Balta.Domain.Application;
using Balta.Domain.Contracts.Infrascructure;
using Balta.Infra.Data;
using System.Linq;

namespace Balta.Infra.Repositories;

public class ModuloRepository : IRepositoryModulo
{
    private readonly DataContext _dataContext;

    public ModuloRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task CriarNovoModuloAsync(Modulo modulo)
    {
        await _dataContext.AddAsync(modulo);
        await _dataContext.SaveChangesAsync();
    }

    public List<Modulo> ListarModulos()
    {
        var listaModulos = new List<Modulo>();
        foreach (var modulo in _dataContext.Modulos) listaModulos.Add(modulo);
        return listaModulos.OrderBy(x => x.Ordem).ToList();
    }
}
