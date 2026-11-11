using MinhaBiblioteca.Models;
public interface IMaterialRepository
{
    IEnumerable<MaterialBiblioteca> ObterTodos();

    MaterialBiblioteca? ObterPorId(int id);

    MaterialBiblioteca Adicionar(MaterialBiblioteca material);

    bool Atualizar(int id, MaterialBiblioteca materialBiblioteca);

    bool Remover(int id);
}