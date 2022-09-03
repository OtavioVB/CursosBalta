namespace Balta.Domain.Application;

public class Modulo
{
    public int Identificador { get; set; }
    public int IdentificadorCurso { get; set; }
    public Curso Curso { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public int Ordem { get; set; }
    public List<Aula> Aulas { get; set; }
}
