using System;
using System.Text.RegularExpressions;
using GestaoDeEquipamentos.ConsoleApp.Dominio;
using GestaoDeEquipamentos.ConsoleApp.Interface;

namespace GestaoDeEquipamentos.ConsoleApp.Apresentacao;

public class TelaFabricante
{
    public RepositorioFabricante repositorioFabricante;

    public string? MostrarMenu()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Gestão de Fabricantes");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1 - Cadastrar fabricante");
        Console.WriteLine("2 - Editar fabricante");
        Console.WriteLine("3 - Excluir fabricante");
        Console.WriteLine("4 - Visualizar fabricantes");
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
        Console.WriteLine("Gestão de Fabricantes");
        Console.WriteLine("---------------------------------");
        System.Console.WriteLine("Cadastro de fabricante");
        System.Console.WriteLine("---------------------------");

        Fabricante novoFabricante = new Fabricante();

        do
        {
            System.Console.Write("Digite o nome do fabricante:");
            novoFabricante.nome = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(novoFabricante.nome) && novoFabricante.nome.Length > 3)
            {
                break;
            }
        } while (true);

        do
        {
            Console.Write("Digite o email: ");
            novoFabricante.email = Console.ReadLine()?.Trim().ToLower();

            Console.Write("Digite o telefone: ");
            novoFabricante.telefone = Console.ReadLine();

            if (VerificarDados(novoFabricante.email, novoFabricante.telefone))
            {
                novoFabricante.telefone = Regex.Replace(novoFabricante.telefone, @"[^\d]", "");
                break;
            }

        } while (true);



        repositorioFabricante.Cadastrar(novoFabricante);

        Console.WriteLine("---------------------------------");
        Console.WriteLine($"O registro de \"{novoFabricante.nome}\" foi cadastrado com sucesso!Digite ENTER para continuar");
        Console.WriteLine("---------------------------------");
        Console.ReadLine();
    }

    public void Editar()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Gestão de Fabricantes");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Edição de Fabricante");
        Console.WriteLine("---------------------------------");

        ObterTabela();


        string? idSelecionado;

        do
        {
            Console.Write("Digite o id do fabricante que deseja editar: ");
            idSelecionado = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(idSelecionado) && idSelecionado.Length == 7)
                break;
        } while (true);

        Fabricante novoFabricante = new Fabricante();

        do
        {
            Console.Write("Digite o nome do fabricante: ");
            novoFabricante.nome = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(novoFabricante.nome) &&
                novoFabricante.nome.Length >= 3)
            {
                break;
            }

        } while (true);

        do
        {
            Console.Write("Digite o email: ");
            novoFabricante.email = Console.ReadLine()?.Trim().ToLower();

            Console.Write("Digite o telefone: ");
            novoFabricante.telefone = Console.ReadLine();

            if (VerificarDados(novoFabricante.email, novoFabricante.telefone))
            {
                novoFabricante.telefone = Regex.Replace(novoFabricante.telefone, @"[^\d]", "");
                break;
            }

        } while (true);

        bool conseguiuEditar = repositorioFabricante.Editar(idSelecionado, novoFabricante);

        if (!conseguiuEditar)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"Não foi possível encontrar o fabricante informado.");
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
        System.Console.WriteLine("Exclusao de fabricante");
        System.Console.WriteLine("---------------------------");

        ObterTabela();

        System.Console.WriteLine();

        System.Console.WriteLine("Digite ENTER para continuar");
        Console.ReadLine();

        string? idSelecionado;

        do
        {
            System.Console.Write("Informe o ID do fabricante que deseja excluir:");
            idSelecionado = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(idSelecionado) && idSelecionado.Length == 7)
            {
                break;
            }
        } while (true);

        bool conseguiuExcluir = repositorioFabricante.Excluir(idSelecionado);

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
        System.Console.WriteLine("Visualização de Fabricante");
        Console.WriteLine("---------------------------------");

        ObterTabela();

        System.Console.WriteLine();

        System.Console.WriteLine("Pressione ENTER para continuar");
        Console.ReadLine();


    }

    private void ObterTabela()
    {
        Console.WriteLine(
           "{0, -7} | {1, -15} | {2, -15} | {3, -22}",
           "Id", "Nome", "Email", "Telefone"
       );

        Fabricante?[] fabricantes = repositorioFabricante.SelecionarTodos();

        for (int i = 0; i < fabricantes.Length; i++)
        {
            Fabricante? f = fabricantes[i];

            if (f == null)
                continue;

            Console.WriteLine(
                "{0, -7} | {1, -15} | {2, -15} | {3, -22}",
                f.id, f.nome, f.email, f.telefone
            );
        }

        Console.WriteLine("---------------------------------");
    }

    private bool VerificarDados(string email, string telefone)
    {
        string padraoTelefone = @"^(\(?\d{2}\)?\s?)?\d{4,5}-?\d{4}$";
        bool emailValido = email.Contains("@") && (email.EndsWith("gmail.com") || email.EndsWith("hotmail.com"));
        bool telefoneValido = Regex.IsMatch(telefone, padraoTelefone);

        if (emailValido && telefoneValido)
            return true;

        Console.WriteLine("Email ou telefone inválido!");
        return false;
    }
}
