using Balta.Domain.Application;
using Balta.Domain.Contracts.Infrascructure;
using Balta.Domain.Models.Post;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Balta.Areas.Cursos.Controllers;

[Route("Cursos")]
[Authorize]
public class CursoController : Controller
{
    [AllowAnonymous]
    public IActionResult Index([FromServices] IRepositoryCurso cursoRepository)
    {
        var cursos = cursoRepository.ListarTodosOsCursos();
        ViewBag.listaCursos = cursos;
        return View("Views/Curso/Index.cshtml");
    }

    [Route("Adicionar")]
    public async Task<IActionResult> Adicionar([FromServices] IRepositoryCurso cursoRepository, PCriarNovoCurso criarNovoCurso)
    {
        var curso = new Curso();
        curso.Titulo = criarNovoCurso.Titulo;
        curso.Duracao = criarNovoCurso.Duracao;
        curso.Tag = criarNovoCurso.Tag;
        await cursoRepository.CreateAsync(curso);
        return RedirectToAction("Criar");
    }

    [Route("Criar")]
    public IActionResult Criar()
    {
        return View("Views/Curso/Criar.cshtml");
    }

    [Route("Listar/{identificador}")]
    public IActionResult Listar([FromRoute] string identificador, [FromServices] IRepositoryCurso cursoRepository)
    {
        bool numeroValido = int.TryParse(identificador, out int valor);

        if (numeroValido is true)
        {
            ViewBag.Curso = cursoRepository.ListarInformacoesDeCurso(valor);
            return View();
        }
        return RedirectToAction("Index");
    }
}
