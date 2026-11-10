public class Livro : MaterialBiblioteca, IEmprestestimo
{
    public string ?Autor {get; set;}
    public int NumeroDePaginas {get; set;}
    public override int PrazoEmprestimo => 14;
    
}