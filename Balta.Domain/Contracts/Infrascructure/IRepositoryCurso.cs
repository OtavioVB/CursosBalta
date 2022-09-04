using Balta.Domain.Application;

namespace Balta.Domain.Contracts.Infrascructure;

public interface IRepositoryCurso
{
    public List<Curso> ListarTodosOsCursos();
    public Curso? ListarInformacoesDeCurso(int identificador);
    public Task CreateAsync(Curso curso);
}
