using System.Security.Cryptography;
using System.Xml.Schema;
using GestaoDeEquipamentos.ConsoleApp.Apresentacao;
using GestaoDeEquipamentos.ConsoleApp.Dominio;
using GestaoDeEquipamentos.ConsoleApp.Interface;

TelaEquipamento telaEquipamento = new TelaEquipamento();
TelaChamado telaChamado = new TelaChamado();
TelaFabricante telaFabricante = new TelaFabricante();

RepositorioEquipamento repositorioEquipamento = new RepositorioEquipamento();
RepositorioChamado repositorioChamado = new RepositorioChamado();
RepositorioFabricante repositorioFabricante = new RepositorioFabricante();

telaEquipamento.repositorioEquipamento = repositorioEquipamento;
telaEquipamento.repositorioFabricante = repositorioFabricante;

telaChamado.repositorioChamado = repositorioChamado;
telaChamado.repositorioEquipamento = repositorioEquipamento;

telaFabricante.repositorioFabricante = repositorioFabricante;

while (true)
{
    Console.Clear();
    Console.WriteLine("---------------------------------");
    Console.WriteLine("Gestão de Equipamentos");
    Console.WriteLine("---------------------------------");
    Console.WriteLine("1 - Gerenciar fabricantes ");
    Console.WriteLine("2 - Gerenciar equipamentos");
    Console.WriteLine("3 - Gerenciar chamados");
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

    else if (opcaoMenuPrincipal == "2")
    {
        while (true)
        {
            string? opcaoMenu = telaEquipamento.MostrarMenu();

            if (opcaoMenu == "S")
            {
                Console.Clear();
                break;
            }

            if (opcaoMenu == "1")
            {
                telaEquipamento.Cadastrar();
            }

            else if (opcaoMenu == "2")
            {
                telaEquipamento.Editar();
            }

            else if (opcaoMenu == "3")
            {
                telaEquipamento.Excluir();
            }

            else if (opcaoMenu == "4")
            {
                telaEquipamento.Visualizar();
            }
        }
    }
    else if (opcaoMenuPrincipal == "3")
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
}

