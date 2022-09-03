using Balta.Domain.Application;
using Balta.Domain.Contracts.Infrascructure;
using Balta.Infra.Data;

namespace Balta.Infra.Repositories;

public class CursoRepository : IRepositoryCurso
{
    private readonly DataContext _dataContext;

    public CursoRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public List<Curso> ListarTodosOsCursos()
    {
        var listaCursos = new List<Curso>();
        foreach (var curso in _dataContext.Cursos)
        {
            listaCursos.Add(curso);
        }

        return listaCursos;
    }

    public async Task CreateAsync(Curso curso)
    {
        await _dataContext.AddAsync(curso);
        await _dataContext.SaveChangesAsync();
    }
}
