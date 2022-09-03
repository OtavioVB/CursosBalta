namespace Balta.Domain.Application;

public class Aula
{
    public int Identificador { get; set; }
    public int IdentificadorModulo { get; set; }
    public Modulo Modulo { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public string Url { get; set; }
}
