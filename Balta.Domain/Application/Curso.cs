namespace Balta.Domain.Application;

public class Curso
{
    public int Identificador { get; set; }
    public string Titulo { get; set; }
    public int Tag { get; set; }
    public TimeSpan Duracao { get; set; }
    public List<Modulo> Modulos { get; set; }
}