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
    [Route("{page=Home}")]
    [AllowAnonymous]
    public IActionResult Index([FromServices] ICursoRepository cursoRepository)
    {
        var cursos = cursoRepository.ListarTodosOsCursos();
        ViewBag.listaCursos = cursos;
        return View("Pages/Curso/Index.cshtml");
    }

    [Route("Adicionar")]
    public async Task<IActionResult> Adicionar([FromServices] ICursoRepository cursoRepository, PCriarNovoCurso criarNovoCurso)
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
        return View("Pages/Curso/Criar.cshtml");
    }
}
