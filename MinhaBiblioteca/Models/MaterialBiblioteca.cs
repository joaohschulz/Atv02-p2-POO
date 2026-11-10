namespace MinhaBiblioteca.Models;
public abstract class MaterialBiblioteca
{
    public int Id {get; init;}
    public DateOnly PrazoEmprestimo {get;set;}
}