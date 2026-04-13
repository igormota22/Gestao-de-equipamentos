using System.Security.Cryptography;
using System.Xml.Schema;
using GestaoDeEquipamentos.ConsoleApp.Apresentacao;
using GestaoDeEquipamentos.ConsoleApp.Dominio;
using GestaoDeEquipamentos.ConsoleApp.Interface;

TelaEquipamento tela = new TelaEquipamento();
TelaChamado telaChamado = new TelaChamado();
TelaFabricante telaFabricante = new TelaFabricante();

RepositorioEquipamento repositorioEquipamento = new RepositorioEquipamento();
RepositorioChamado repositorioChamado = new RepositorioChamado();
RepositorioFabricante repositorioFabricante = new RepositorioFabricante();

tela.repositorioEquipamento = repositorioEquipamento;
telaChamado.repositorioChamado = repositorioChamado;
telaChamado.repositorioEquipamento = repositorioEquipamento;
telaFabricante.repositorioFabricante = repositorioFabricante;

while (true)
{
    Console.Clear();
    Console.WriteLine("---------------------------------");
    Console.WriteLine("Gestão de Equipamentos");
    Console.WriteLine("---------------------------------");
    Console.WriteLine("1 - Gerenciar equipamentos ");
    Console.WriteLine("2 - Gerenciar chamados");
    Console.WriteLine("2 - Gerenciar fabricantes");
    Console.WriteLine("---------------------------------");
    Console.Write("> ");
    string? opcaoMenuPrincipal = Console.ReadLine()?.ToUpper();

    if (opcaoMenuPrincipal == "S")
    {
        Console.Clear();
        break;
    }

    if (opcaoMenuPrincipal == "1")
    {
        while (true)
        {

            string? opcaoMenu = tela.MostrarMenu();
            if (opcaoMenu == "S")
            {
                Console.Clear();
                break;
            }

            if (opcaoMenu == "1")
            {
                tela.Cadastrar();
            }

            else if (opcaoMenu == "2")
            {
                tela.Editar();
            }

            else if (opcaoMenu == "3")
            {
                tela.Excluir();
            }

            else if (opcaoMenu == "4")
            {
                tela.Visualizar();
            }
        }
    }

    else if (opcaoMenuPrincipal == "2")
    {
        while (true)
        {
            string? opcaoMenu = telaChamado.MostrarMenu();

            if (opcaoMenu == "S")
            {
                Console.Clear();
                break;
            }

            if (opcaoMenu == "1")
            {
                telaChamado.Cadastrar();
            }

            else if (opcaoMenu == "2")
            {
                telaChamado.Editar();
            }

            else if (opcaoMenu == "3")
            {
                telaChamado.Excluir();
            }

            else if (opcaoMenu == "4")
            {
                telaChamado.Visualizar();
            }
        }
    }
    else if (opcaoMenuPrincipal == "3")
    {
        while (true)
        {
            string? opcaoMenu = telaFabricante.MostrarMenu();

            if (opcaoMenu == "S")
            {
                Console.Clear();
                break;
            }

            if (opcaoMenu == "1")
            {
                telaFabricante.Cadastrar();
            }

            else if (opcaoMenu == "2")
            {
                telaFabricante.Editar();
            }

            else if (opcaoMenu == "3")
            {
                telaFabricante.Excluir();
            }

            else if (opcaoMenu == "4")
            {
                telaFabricante.Visualizar();
            }
        }
    }
}

