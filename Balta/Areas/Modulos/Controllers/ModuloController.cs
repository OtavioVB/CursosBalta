using Balta.Domain.Application;
using Balta.Domain.Contracts.Infrascructure;
using Balta.Domain.Models.Post;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Balta.Areas.Modulos.Controllers;

[Authorize]
[Route("Modulos")]
public class ModuloController : Controller
{
    [AllowAnonymous]
    [Route("{page=Home}")]
    public IActionResult Index([FromServices] IRepositoryModulo moduloRepository)
    {
        ViewBag.listaModulos = moduloRepository.ListarModulos();
        return View("Pages/Modulo/Index.cshtml");
    }

    [Route("Adicionar")]
    public async Task<IActionResult> Adicionar([FromServices] IRepositoryModulo moduloRepository, PCriarNovoModulo criarNovoModulo)
    {
        await moduloRepository.CriarNovoModuloAsync(new Modulo()
        {
            Titulo = criarNovoModulo.Titulo,
            Descricao = criarNovoModulo.Descricao,
            IdentificadorCurso = criarNovoModulo.IdentificadorCurso,
            Ordem = criarNovoModulo.Ordem
        });

        return RedirectToAction("Criar");
    }

    [Route("Criar")]
    public IActionResult Criar([FromServices] IRepositoryCurso repositoryCurso)
    {
        ViewBag.Cursos = repositoryCurso.ListarTodosOsCursos();
        return View("Pages/Modulo/Criar.cshtml");
    }
}
