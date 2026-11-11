namespace MinhaBiblioteca.Models;
public class Livro : MaterialBiblioteca, IEmprestestimo
{
    public string ?Autor {get; set;}
    public int Paginas {get; set;}

    public override int CalcularPrazo()
    {
        return 14;
    }

    public override string Descricao()
    {
        return $"O Livro possui {CalcularPrazo()} dias de prazo para a entrega";
    }
    

    public string Emprestar()
    {
        return $"O livro pode ser emprestado por {CalcularPrazo()} dias";
    }
}