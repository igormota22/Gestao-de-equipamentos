using System;
using GestaoDeEquipamentos.ConsoleApp.Dominio;
using GestaoDeEquipamentos.ConsoleApp.Interface;

namespace GestaoDeEquipamentos.ConsoleApp.Apresentacao;

public class TelaChamado
{
    public RepositorioChamado repositorioChamado;
    public RepositorioEquipamento repositorioEquipamento;



    public string? MostrarMenu()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Gestão de Chamadas");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1 - Cadastrar chamada");
        Console.WriteLine("2 - Editar chamada");
        Console.WriteLine("3 - Excluir chamada");
        Console.WriteLine("4 - Visualizar chamada");
        Console.WriteLine("S - Sair");
        Console.WriteLine("---------------------------------");
        Console.Write("> ");
        string? opcaoMenu = Console.ReadLine()?.ToUpper();

        return opcaoMenu;

    }

    public void Cadastrar()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Gestão de Chamados");
        Console.WriteLine("---------------------------------");
        System.Console.WriteLine("Cadastro de chamado");
        System.Console.WriteLine("---------------------------");

        Chamado novoChamado = new Chamado();

        Console.WriteLine(
"{0, -7} | {1, -15} | {2, -15} | {3, -22} | {4, -10}",
"Id", "Nome", "Fabricante", "Preço de Aquisição", "Data de Fabricação"
 );

        Equipamento[] equipamentos = repositorioEquipamento.SelecionarTodos();

        for (int i = 0; i < equipamentos.Length; i++)
        {
            Equipamento? e = equipamentos[i];

            if (e == null)
            {
                continue;
            }
            Console.WriteLine(
      "{0, -7} | {1, -15} | {2, -15} | {3, -22} | {4, -10}",
      e.id, e.nome, e.fabricante, e.precoDeAquisicao.ToString("C2"), e.dataDeFabricacao.ToShortDateString()
        );
            System.Console.WriteLine();

            System.Console.WriteLine("Digite ENTER para continuar");
            Console.ReadLine();
        }
        string? idSelecionado;

        System.Console.Write("Informe o ID do equipamento que deseja fazer o chamado:");
        idSelecionado = Console.ReadLine();

        do
        {
            System.Console.Write("Digite o titulo do chamado:");
            novoChamado.titulo = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(novoChamado.titulo) && novoChamado.titulo.Length > 3)
            {
                break;
            }
        } while (true);

        do
        {
            System.Console.Write("Digite a descrição:");
            novoChamado.descricao = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(novoChamado.descricao) && novoChamado.descricao.Length > 3)
            {
                break;
            }
        } while (true);

        novoChamado.dataDeAbertura = DateTime.Now;

        repositorioChamado.Cadastrar(novoChamado);

        Console.WriteLine("---------------------------------");
        Console.WriteLine($"O registro \"{novoChamado.titulo}\" foi cadastrado com sucesso!Digite ENTER para continuar");
        Console.WriteLine("---------------------------------");
        Console.ReadLine();

    }


    public void Editar()
    {

    }
    public void Excluir()
    {
        Console.WriteLine("---------------------------------");
        System.Console.WriteLine("Exclusao de chamado");
        System.Console.WriteLine("---------------------------");

        Console.WriteLine(
"{0, -7} | {1, -15} | {2, -15} | {3, -22} | {4, -10}",
"Id", "Titulo", "Descrição", "Data de Aquisição", "Disas em aberto"
);

        for (int i = 0; i < repositorioChamado.chamados.Length; i++)
        {
            Chamado? c = repositorioChamado.chamados[i];

            if (c == null)
            {
                continue;
            }
            Console.WriteLine(
      "{0, -7} | {1, -15} | {2, -15} | {3, -22} | {4, -10}",
      c.id, c.titulo, c.descricao, c.dataDeAbertura.ToShortDateString(), c.ObterDiasDecorridos()
        );
            System.Console.WriteLine();

            System.Console.WriteLine("Digite ENTER para continuar");
            Console.ReadLine();
        }
        string? idSelecionado;

        do
        {
            System.Console.Write("Informe o ID do chamado que deseja excluir:");
            idSelecionado = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(idSelecionado) && idSelecionado.Length == 7)
            {
                break;
            }
        } while (true);

        bool conseguiuExcluir = repositorioChamado.Excluir(idSelecionado);

        if (conseguiuExcluir)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"O registro \"{idSelecionado}\" foi excluido com sucesso!Digite ENTER para continuar");
            Console.WriteLine("---------------------------------");
            Console.ReadLine();

        }
    }
    public void Visualizar()
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Visualização de Chamados");
        Console.WriteLine("---------------------------------");

        Console.WriteLine(
   "{0, -7} | {1, -15} | {2, -15} | {3, -22} | {4, -10}",
   "Id", "tiulo", "Descriçao", "Data de abertura", "Dias em aberto"
);

        Console.ReadLine();

        for (int i = 0; i < repositorioChamado.chamados.Length; i++)
        {
            Chamado? c = repositorioChamado.chamados[i];

            if (c == null)
            {
                break;
            }
            Console.WriteLine(
      "{0, -7} | {1, -15} | {2, -15} | {3, -22} | {4, -10}",
      c.id, c.titulo, c.descricao, c.dataDeAbertura.ToShortDateString(), c.ObterDiasDecorridos()
        );
            System.Console.WriteLine();

            System.Console.WriteLine("Digite ENTER para continuar");
            Console.ReadLine();
        }
    }
}



