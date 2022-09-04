using Balta.Domain.Application;

namespace Balta.Domain.Contracts.Infrascructure;

public interface IRepositoryAula
{
    public Task CriarNovaAula(Aula aula);
    public List<Aula>? ListarAulas(int moduloIdentificador);
    public Aula? BuscarAula(string url);
}
