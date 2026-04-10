using System;
using System.Security.Cryptography;
using GestaoDeEquipamentos.ConsoleApp.Dominio;

namespace GestaoDeEquipamentos.ConsoleApp.Interface;

public class RepositorioEquipamento
{
    public Equipamento[]? equipamentos = new Equipamento[10];
    public void Cadastrar(Equipamento novoEquipamento)
    {
        novoEquipamento.id = Convert.ToHexString(RandomNumberGenerator.GetBytes(20)).ToLower().Substring(0, 7);

        for (int i = 0; i < equipamentos?.Length; i++)
        {
            Equipamento? e = equipamentos[i];

            if (e == null)
            {
                equipamentos[i] = novoEquipamento;
                break;
            }
        }
    }

    public Equipamento SelecionarID(string idSelecionado)
    {
        if (string.IsNullOrWhiteSpace(idSelecionado) && idSelecionado.Length == 7)
        {
            return null;
        }

        Equipamento? equipamentoSelecionado = null;

        for (int i = 0; i < equipamentos?.Length; i++)
        {
            Equipamento e = equipamentos[i];

            if (e == null)
            {
                continue;
            }
            if (e.id == idSelecionado)
            {
                return e;
            }
        }
        return null;
    }

    public bool Editar(string idSelecionado, Equipamento novoEquipamento)
    {
        Equipamento? equipamentoSelecionado = SelecionarID(idSelecionado);

        if (equipamentoSelecionado == null)
        {
            return false;
        }

        equipamentoSelecionado?.nome = novoEquipamento.nome;
        equipamentoSelecionado?.fabricante = novoEquipamento.fabricante;
        equipamentoSelecionado?.precoDeAquisicao = novoEquipamento.precoDeAquisicao;
        equipamentoSelecionado?.dataDeFabricacao = novoEquipamento.dataDeFabricacao;

        return true;
    }

    public bool Excluir(string idSelecionado)
    {

        for (int i = 0; i < equipamentos?.Length; i++)
        {
            Equipamento? e = equipamentos[i];

            if (e == null)
            {
                continue;
            }

            if (e.id == idSelecionado)
            {
                equipamentos[i] = null;
                return true;
            }

        }
        return false;
    }
}