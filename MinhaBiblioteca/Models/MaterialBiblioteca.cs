public abstract class MaterialBiblioteca
{
    public int Id {get; init;}
    public abstract int PrazoEmprestimo {get;set;}

    public abstract string Cadastrar();

}