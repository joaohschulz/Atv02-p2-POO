namespace MinhaBiblioteca.Models;
public class Revista : MaterialBiblioteca
{
    public int Edicao{get;set;}
    public DateOnly Publicacao {get;set;}
}