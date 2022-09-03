using Balta.Domain.Application;

namespace Balta.Domain.Contracts.Infrascructure;

public interface ICursoRepository
{
    public List<Curso> ListarTodosOsCursos();
    public Task CreateAsync(Curso curso);
}
