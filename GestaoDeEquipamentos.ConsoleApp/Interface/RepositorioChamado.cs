using System;
using System.Security.Cryptography;
using GestaoDeEquipamentos.ConsoleApp.Dominio;

namespace GestaoDeEquipamentos.ConsoleApp.Interface;

public class RepositorioChamado
{
    public Chamado[]? chamados = new Chamado[10];
    public void Cadastrar(Chamado novoChamado)
    {
        novoChamado.id = Convert.ToHexString(RandomNumberGenerator.GetBytes(20)).ToLower().Substring(0, 7);

        for (int i = 0; i < chamados.Length; i++)
        {
            Chamado? c = chamados[i];

            if (c == null)
            {
                chamados[i] = novoChamado;
                break;
            }
        }
    }

    public Chamado?[] SelecionarTodos()
    {
        return chamados;
    }

    public Chamado? SelecionarPorId(string idSelecionado)
    {
        Chamado? chamadoSelecionado = null;

        for (int i = 0; i < chamados.Length; i++)
        {
            Chamado? c = chamados[i];

            if (c == null)
                continue;

            if (c.id == idSelecionado)
            {
                chamadoSelecionado = c;
                break;
            }
        }

        return chamadoSelecionado;
    }

    public bool Editar(string idSelecionado, Chamado novoChamado)
    {
        Chamado? chamadoSelecionado = SelecionarPorId(idSelecionado);

        if (chamadoSelecionado == null)
        {
            return false;
        }

        chamadoSelecionado?.titulo = novoChamado.titulo;
        chamadoSelecionado?.descricao = novoChamado.descricao;

        return true;
    }

    public bool Excluir(string idSelecionado)
    {
        for (int i = 0; i < chamados.Length; i++)
        {
            Chamado? c = chamados[i];

            if (c == null)
            {
                continue;
            }

            if (c.id == idSelecionado)
            {
                chamados[i] = null;
                return true;
            }

        }
        return false;
    }
}
