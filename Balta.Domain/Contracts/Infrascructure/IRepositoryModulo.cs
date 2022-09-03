using Balta.Domain.Application;

namespace Balta.Domain.Contracts.Infrascructure;

public interface IRepositoryModulo
{
    public List<Modulo> ListarModulos();
    public Task CriarNovoModuloAsync(Modulo modulo);
}
