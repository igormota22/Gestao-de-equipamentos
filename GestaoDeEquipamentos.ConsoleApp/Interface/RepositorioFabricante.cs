using System;
using System.Security.Cryptography;
using GestaoDeEquipamentos.ConsoleApp.Dominio;

namespace GestaoDeEquipamentos.ConsoleApp.Interface;

public class RepositorioFabricante
{
    public Fabricante[]? fabricantes = new Fabricante[10];

    public void Cadastrar(Fabricante novoFabricante)
    {
        novoFabricante.id = Convert.ToHexString(RandomNumberGenerator.GetBytes(20)).ToLower().Substring(0, 7);

        for (int i = 0; i < fabricantes.Length; i++)
        {
            Fabricante? f = fabricantes[i];

            if (f == null)
            {
                fabricantes[i] = novoFabricante;
                break;
            }
        }
    }

    public Fabricante?[] SelecionarTodos()
    {
        return fabricantes;
    }

    public Fabricante? SelecionarPorID(string idSelecionado)
    {
        Fabricante? fabricanteSelecionado = null;

        for (int i = 0; i < fabricantes.Length; i++)
        {
            Fabricante? f = fabricantes[i];

            if (f == null)
                continue;

            if (f.id == idSelecionado)
            {
                fabricanteSelecionado = f;
                break;
            }
        }

        return fabricanteSelecionado;
    }

    public bool Editar(string idSelecionado, Fabricante novoFabricante)
    {
        Fabricante? fabricanteSelecionado = SelecionarPorID(idSelecionado);

        if (fabricanteSelecionado == null)
        {
            return false;
        }

        fabricanteSelecionado?.nome = novoFabricante.nome;
        fabricanteSelecionado?.email = novoFabricante.email;
        fabricanteSelecionado?.telefone = novoFabricante.telefone;

        return true;
    }

    public bool Excluir(string idSelecionado)
    {
        for (int i = 0; i < fabricantes.Length; i++)
        {
            Fabricante? f = fabricantes[i];

            if (f == null)
            {
                continue;
            }

            if (f.id == idSelecionado)
            {
                fabricantes[i] = null;
                return true;
            }

        }
        return false;
    }
}

