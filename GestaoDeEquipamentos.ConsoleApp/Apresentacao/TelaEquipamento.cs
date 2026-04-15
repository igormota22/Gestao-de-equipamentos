using System;
using System.Security.Cryptography;
using GestaoDeEquipamentos.ConsoleApp.Dominio;
using GestaoDeEquipamentos.ConsoleApp.Interface;

namespace GestaoDeEquipamentos.ConsoleApp.Apresentacao;

public class TelaEquipamento
{
    public RepositorioEquipamento repositorioEquipamento;

    public RepositorioFabricante repositorioFabricante;

    public string? MostrarMenu()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Gestão de Equipamentos");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1 - Cadastrar equipamento");
        Console.WriteLine("2 - Editar equipamento");
        Console.WriteLine("3 - Excluir equipamento");
        Console.WriteLine("4 - Visualizar equipamentos");
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
        Console.WriteLine("Gestão de Equipamentos");
        Console.WriteLine("---------------------------------");
        System.Console.WriteLine("Cadastro de equipamento");
        System.Console.WriteLine("---------------------------");

        Equipamento novoEquipamento = new Equipamento();

        Console.WriteLine(
"{0, -7} | {1, -15} | {2, -15} | {3, -22}",
"Id", "Nome", "Email", "Telefone"
);

        Fabricante[] fabricantes = repositorioFabricante.SelecionarTodos();

        for (int i = 0; i < fabricantes.Length; i++)
        {
            Fabricante? f = fabricantes[i];

            if (f == null)
            {
                continue;
            }
            Console.WriteLine(
      "{0, -7} | {1, -15} | {2, -15} | {3, -22}",
      f.id, f.nome, f.email, f.telefone
        );
            System.Console.WriteLine();

            System.Console.WriteLine("Digite ENTER para continuar");
            Console.ReadLine();
        }

        string? idSelecionado;

        System.Console.Write("Informe o ID do fabricante que deseja cadastrar o equipamento:");
        idSelecionado = Console.ReadLine();

        Fabricante fabricanteSelecionado = repositorioFabricante.SelecionarPorID(idSelecionado);
        if (fabricanteSelecionado == null)
        {
            Console.WriteLine("Fabricante não encontrado!");
            return;
        }
        novoEquipamento.fabricante = fabricanteSelecionado;

        do
        {
            System.Console.Write("Digite o nome do equipamento:");
            novoEquipamento.nome = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(novoEquipamento.nome) && novoEquipamento.nome.Length > 3)
            {
                break;
            }
        } while (true);


        System.Console.Write("Digite o preço de aquisição do equipamento:");
        novoEquipamento.precoDeAquisicao = Convert.ToDecimal(Console.ReadLine());

        System.Console.Write("Digite a data de fabricação do equipamento:");
        novoEquipamento.dataDeFabricacao = Convert.ToDateTime(Console.ReadLine());

        repositorioEquipamento.Cadastrar(novoEquipamento);

        Console.WriteLine("---------------------------------");
        Console.WriteLine($"O registro \"{novoEquipamento.nome}\" foi cadastrado com sucesso!Digite ENTER para continuar");
        Console.WriteLine("---------------------------------");
        Console.ReadLine();

    }

    public void Editar()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Gestão de Equipamentos");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Edição de Equipamento");
        Console.WriteLine("---------------------------------");

        ObterTabela();

        Console.WriteLine("---------------------------------");

        string? idSelecionado;

        Console.Write("Digite o id do equipamento que deseja editar: ");
        idSelecionado = Console.ReadLine();

        Equipamento novoEquipamento = new Equipamento();

        Equipamento EquipamentoSelecionado = repositorioEquipamento.SelecionarPorId(idSelecionado);
        if (EquipamentoSelecionado == null)
        {
            Console.WriteLine("Fabricante não encontrado!");
            return;
        }
        novoEquipamento = EquipamentoSelecionado;

        do
        {
            Console.Write("Digite o nome do equipamento: ");
            novoEquipamento.nome = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(novoEquipamento.nome) &&
                novoEquipamento.nome.Length >= 3)
            {
                break;
            }

        } while (true);

        do
        {

            if (!string.IsNullOrWhiteSpace(novoEquipamento.fabricante.nome) &&
                novoEquipamento.fabricante.nome.Length >= 2)
            {
                break;
            }

        } while (true);

        Console.Write("Digite o preço de aquisição do equipamento: ");
        novoEquipamento.precoDeAquisicao = Convert.ToDecimal(Console.ReadLine());

        Console.Write("Digite a data de fabricação do equipamento: ");
        novoEquipamento.dataDeFabricacao = Convert.ToDateTime(Console.ReadLine());

        bool conseguiuEditar = repositorioEquipamento.Editar(idSelecionado, novoEquipamento);

        if (!conseguiuEditar)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"Não foi possível encontrar o equipamento informado.");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Digite ENTER para continuar...");
            Console.ReadLine();
            return;
        }

        Console.WriteLine("---------------------------------");
        Console.WriteLine($"O registro \"{idSelecionado}\" foi editado com sucesso.");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Digite ENTER para continuar...");
        Console.ReadLine();
    }


    public void Excluir()
    {
        Console.WriteLine("---------------------------------");
        System.Console.WriteLine("Exclusao de equipamento");
        System.Console.WriteLine("---------------------------");

        ObterTabela();

        Console.WriteLine("---------------------------------");
        string? idSelecionado;

        do
        {
            System.Console.Write("Informe o ID do equipamento que deseja excluir:");
            idSelecionado = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(idSelecionado) && idSelecionado.Length == 7)
            {
                break;
            }
        } while (true);

        bool conseguiuExcluir = repositorioEquipamento.Excluir(idSelecionado);

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
        Console.WriteLine("Visualização de Equipamento");
        Console.WriteLine("---------------------------------");

        ObterTabela();

        System.Console.WriteLine("Digite ENTER para continuar");
        Console.ReadLine();
    }

    private void ObterTabela()
    {

        Console.WriteLine(
   "{0, -7} | {1, -15} | {2, -15} | {3, -22} | {4, -10}",
   "Id", "Nome", "Fabricante", "Preço de Aquisição", "Data de Fabricação"
);
        Console.ReadLine();

        for (int i = 0; i < repositorioEquipamento.equipamentos.Length; i++)
        {
            Equipamento? e = repositorioEquipamento.equipamentos[i];

            if (e == null)
            {
                continue;

            }
            Console.WriteLine(
      "{0, -7} | {1, -15} | {2, -15} | {3, -22} | {4, -10}",
      e.id, e.nome, e.fabricante.nome, e.precoDeAquisicao.ToString("C2"), e.dataDeFabricacao.ToShortDateString()
        );
            System.Console.WriteLine();
        }
    }
}

