public abstract class MaterialBiblioteca
{
    public string Titulo { get; set; }
    public int AnoPublicacao { get; set; }

    public void ExibirInformacoes()
    {
        Console.WriteLine($"Título: {Titulo}");
    }
}