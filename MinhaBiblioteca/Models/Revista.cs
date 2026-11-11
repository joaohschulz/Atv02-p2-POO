namespace MinhaBiblioteca.Models;

public class Revista : MaterialBiblioteca
{
    public int Edicao { get; set; }
    public string? MesPublicacao { get; set; }


    public override int CalcularPrazo()
    {
        return 7;
    }
    public override string Descricao()
    {
        return $"A revista possui {CalcularPrazo()} dias de prazo para a entrega";
    }

}