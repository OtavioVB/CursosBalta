using Balta.Domain.Application;
using Balta.Domain.Contracts.Infrascructure;
using Balta.Domain.Models.Post;
using Balta.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Balta.Areas.Aulas.Controllers;

[Route("Aulas")]
[Authorize]
public class AulaController : Controller
{
    [Route("Criar")]
    public IActionResult Criar([FromServices] IRepositoryModulo repositoryModulo)
    {
        ViewBag.Modulos = repositoryModulo.ListarModulos();
        return View("Pages/Aula/Criar.cshtml");
    }

    [Route("Adicionar")]
    public IActionResult Adicionar([FromServices] IRepositoryAula repositoryAula, PCriarNovaAula criarNovaAula)
    {
        var aula = new Aula();
        aula.Titulo = criarNovaAula.Titulo;
        aula.Descricao = criarNovaAula.Descricao;
        aula.IdentificadorModulo = criarNovaAula.IdentificadorModulo;
        aula.Url = UrlFunctions.ObterUrlAmigavel(criarNovaAula.Titulo);
        repositoryAula.CriarNovaAula(aula);
        return View("Pages/Aula/Criar.cshtml");
    }

    [Route("Visualizar/{url}")]
    public IActionResult Visualizar([FromRoute] string url, [FromServices] IRepositoryAula repositoryAula)
    {
        if (UrlFunctions.VerificarUrlAmigavel(url) is true)
        {
            var aula = repositoryAula.BuscarAula(url);
            if (aula != null)
            {
                ViewBag.Aula = aula;
                return View("Pages/Aula/Visualizar.cshtml");
            }
            else
            {
                return RedirectToAction("Index", "Curso");
            }
        }
        else
        {
            return RedirectToAction("Index", "Curso");
        }
    }
}
