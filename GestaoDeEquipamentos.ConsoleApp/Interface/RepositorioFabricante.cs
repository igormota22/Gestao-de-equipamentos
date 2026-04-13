using System;
using GestaoDeEquipamentos.ConsoleApp.Dominio;

namespace GestaoDeEquipamentos.ConsoleApp.Interface;

public class RepositorioFabricante
{
    public Fabricante[]? fabricantes = new Fabricante[10];

    public void Cadastrar(Fabricante novoFabricante)
    {

    }

    public Fabricante?[] SelecionarTodos()
    {
        return fabricantes;
    }

    public Fabricante? SelecionarPorID(string idSelecionado)
    {
        Fabricante? fabricanteSelecionado = null;


        return fabricanteSelecionado;
    }

    public bool Editar(string idSelecionado, Fabricante novoFabricante)
    {


        return true;
    }

    public bool Excluir(string idSelecionado)
    {
        return false;
    }
}
