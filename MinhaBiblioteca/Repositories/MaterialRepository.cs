using MinhaBiblioteca.Models;
using System.Linq;

public class MaterialRepository: IMaterialRepository
{
    private static int _proximoId = 3;
    private static int GerarNovoId()
    {
        return _proximoId++;
    }

    private static Dictionary<int, MaterialBiblioteca> _materiais = new ()
    {
        {1, new Livro {Id = 1, Titulo = "Percy Jackson", AnoPublicacao = 2015, Autor = "Rick", Paginas = 300}},
        {2, new Revista{Id = 2, Titulo = "Revista Importante 3",  MesPublicacao = 3, Edicao = 33}}
    };
    

    public IEnumerable<MaterialBiblioteca> ObterTodos()
    {
        return _materiais.Values;
    }

    public MaterialBiblioteca ObterPorId(int id)
    {
        if (!_materiais.ContainsKey(id))
        {
            return null;
        }
        else
        {
            return _materiais[id];
        }
    }

    public MaterialBiblioteca Adicionar(MaterialBiblioteca material)
    {
        int novoId = GerarNovoId();
        material.Id = novoId;
        _materiais.Add(novoId, material);
        return material;
    }

    public bool Atualizar(int id, MaterialBiblioteca materialBiblioteca)
    {
        if (!_materiais.ContainsKey(id))
        {
            return false;
        }
        else
        {
            materialBiblioteca.Id = id;
            _materiais[id] = materialBiblioteca;
            return true;
        }
    }

    public bool Remover(int id)
    {
        if (!_materiais.ContainsKey(id))
        {
            return false;
        }
        else
        {
            _materiais.Remove(id);
            return true;
        }
    }

    
}