using System.Security.Cryptography;
using GestaoDeEquipamentos.ConsoleApp.Apresentacao;
using GestaoDeEquipamentos.ConsoleApp.Dominio;
using GestaoDeEquipamentos.ConsoleApp.Interface;

class Program
{
    static void Main(string[] args)
    {
        TelaEquipamento tela = new TelaEquipamento();
        while (true)
        {

            string? opcaoMenu = tela.MostrarMenuPrincipal();
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
}
