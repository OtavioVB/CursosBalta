using Balta.Domain.Application;
using Balta.Domain.Contracts.Infrascructure;
using Balta.Infra.Data;

namespace Balta.Infra.Repositories;

public class CursoRepository : IRepositoryCurso
{
    private readonly DataContext _dataContext;
    private readonly IRepositoryModulo _repositoryModulo;

    public CursoRepository(DataContext dataContext, IRepositoryModulo repositoryModulo)
    {
        _repositoryModulo = repositoryModulo;
        _dataContext = dataContext;
        _dataContext.Database.EnsureCreated();
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

    public Curso? ListarInformacoesDeCurso(int identificador)
    {
        var cursoIdentificado = new Curso();
        bool existeCurso = false;
        foreach (var curso in _dataContext.Cursos)
        {
            if (curso.Identificador == identificador) 
            {
                cursoIdentificado = curso;
                existeCurso = true;
                break;
            }
        }
        cursoIdentificado.Modulos = _repositoryModulo.ListarModulos(cursoIdentificado.Identificador);
        return existeCurso ? cursoIdentificado : null;
    }

    public async Task CreateAsync(Curso curso)
    {
        await _dataContext.AddAsync(curso);
        await _dataContext.SaveChangesAsync();
    }
}