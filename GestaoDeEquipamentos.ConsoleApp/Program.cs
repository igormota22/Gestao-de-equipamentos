using System.Security.Cryptography;
using GestaoDeEquipamentos.ConsoleApp.Apresentacao;
using GestaoDeEquipamentos.ConsoleApp.Dominio;

class Program
{
    static void Main(string[] args)
    {
        Equipamento[]? equipamentos = new Equipamento[10];
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
                tela.Cadastrar(equipamentos);
            }

            else if (opcaoMenu == "2")
            {
                tela.Editar(equipamentos);
            }

            else if (opcaoMenu == "3")
            {
                tela.Excluir(equipamentos);
            }

            else if (opcaoMenu == "4")
            {
                tela.Visualizar(equipamentos);
            }
        }
    }
}
