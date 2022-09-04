using Balta.Domain.Application;

namespace Balta.Domain.Contracts.Infrascructure;

public interface IRepositoryModulo
{
    public List<Modulo>? ListarModulos();
    public List<Modulo>? ListarModulos(int identificadorCurso);
    public Task CriarNovoModuloAsync(Modulo modulo);
}
