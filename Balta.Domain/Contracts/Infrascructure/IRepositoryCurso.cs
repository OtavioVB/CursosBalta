using Balta.Domain.Application;

namespace Balta.Domain.Contracts.Infrascructure;

public interface IRepositoryCurso
{
    public List<Curso> ListarTodosOsCursos();
    public Task CreateAsync(Curso curso);
}
