using Balta.Domain.Application;
using Balta.Domain.Contracts.Infrascructure;
using Balta.Infra.Data;
using System.Linq;

namespace Balta.Infra.Repositories;

public class ModuloRepository : IRepositoryModulo
{
    private readonly DataContext _dataContext;
    private readonly IRepositoryAula _repositoryAula;

    public ModuloRepository(DataContext dataContext, IRepositoryAula repositoryAula)
    {
        _repositoryAula = repositoryAula;
        _dataContext = dataContext;
    }

    public async Task CriarNovoModuloAsync(Modulo modulo)
    {
        await _dataContext.AddAsync(modulo);
        await _dataContext.SaveChangesAsync();
    }

    public List<Modulo>? ListarModulos()
    {
        var listaModulos = new List<Modulo>();
        bool possuiModulos = false;
        foreach (var modulo in _dataContext.Modulos) 
        {
            listaModulos.Add(modulo);
            possuiModulos = true;
            continue;
        }
        return possuiModulos ? listaModulos.OrderBy(x => x.Ordem).ToList() : null;
    }

    public List<Modulo>? ListarModulos(int identificadorCurso)
    {
        var listaModulos = new List<Modulo>();
        bool possuiModulos = false;
        foreach (var modulo in _dataContext.Modulos)
        {
            if (modulo.IdentificadorCurso == identificadorCurso)
            {
                listaModulos.Add(modulo);
                possuiModulos = true;
                modulo.Aulas = _repositoryAula.ListarAulas(modulo.Identificador);
            }
        }

        return possuiModulos ? listaModulos.OrderBy(x => x.Ordem).ToList() : null;
    }
}
