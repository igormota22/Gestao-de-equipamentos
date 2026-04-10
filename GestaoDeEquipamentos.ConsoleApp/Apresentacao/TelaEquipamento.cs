using System;
using System.Security.Cryptography;
using GestaoDeEquipamentos.ConsoleApp.Dominio;
using GestaoDeEquipamentos.ConsoleApp.Interface;

namespace GestaoDeEquipamentos.ConsoleApp.Apresentacao;

public class TelaEquipamento
{



    RepositorioEquipamento repositorioEquipamento = new RepositorioEquipamento();

    public string? MostrarMenuPrincipal()
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

        do
        {
            System.Console.Write("Digite o nome do equipamento:");
            novoEquipamento.nome = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(novoEquipamento.nome) && novoEquipamento.nome.Length > 3)
            {
                break;
            }
        } while (true);

        do
        {
            System.Console.Write("Digite o fabricante:");
            novoEquipamento.fabricante = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(novoEquipamento.fabricante) && novoEquipamento.fabricante.Length > 3)
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
        Equipamento novoEquipamento = new Equipamento();

        Console.WriteLine("---------------------------------");
        Console.WriteLine("Ediçao de Equipamento");
        Console.WriteLine("---------------------------------");

        Console.WriteLine(
   "{0, -7} | {1, -15} | {2, -15} | {3, -22} | {4, -10}",
   "Id", "Nome", "Fabricante", "Preço de Aquisição", "Data de Fabricação"
    );

        for (int i = 0; i < repositorioEquipamento.equipamentos.Length; i++)
        {
            Equipamento? e = repositorioEquipamento.equipamentos[i];

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



        do
        {
            System.Console.Write("Informe o ID do equipamento que deseja atualizar:");
            idSelecionado = Console.ReadLine();

            do
            {
                System.Console.Write("Digite o nome do equipamento:");
                novoEquipamento.nome = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(novoEquipamento.nome) && novoEquipamento.nome.Length > 3)
                {
                    break;
                }
            } while (true);

            do
            {
                System.Console.Write("Digite o fabricante:");
                novoEquipamento.fabricante = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(novoEquipamento.fabricante) && novoEquipamento.fabricante.Length > 3)
                {
                    break;
                }
            } while (true);

            System.Console.Write("Digite o preço de aquisição do equipamento:");
            novoEquipamento.precoDeAquisicao = Convert.ToDecimal(Console.ReadLine());

            System.Console.Write("Digite a data de fabricação do equipamento:");
            novoEquipamento.dataDeFabricacao = Convert.ToDateTime(Console.ReadLine());

            bool conseguiuSelecionarID = repositorioEquipamento.Editar(idSelecionado, novoEquipamento);
            if (!conseguiuSelecionarID == null)
            {
                System.Console.WriteLine("----------------------------------------------------------");
                System.Console.WriteLine("Nao foi possivel encontrar o equipamento selecionado!Pressione ENTER para continuar");
                System.Console.WriteLine("----------------------------------------------------------");
                Console.ReadLine();
            }


            Console.WriteLine("---------------------------------");
            Console.WriteLine($"O registro \"{idSelecionado}\" foi atualizado com sucesso!Digite ENTER para continuar");
            Console.WriteLine("---------------------------------");
            Console.ReadLine();
            break;
        } while (true);
    }

    public void Excluir()
    {
        Console.WriteLine("---------------------------------");
        System.Console.WriteLine("Exclusao de equipamento");
        System.Console.WriteLine("---------------------------");

        Console.WriteLine(
"{0, -7} | {1, -15} | {2, -15} | {3, -22} | {4, -10}",
"Id", "Nome", "Fabricante", "Preço de Aquisição", "Data de Fabricação"
);

        for (int i = 0; i < repositorioEquipamento.equipamentos.Length; i++)
        {
            Equipamento? e = repositorioEquipamento.equipamentos[i];

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

        Console.WriteLine(
   "{0, -7} | {1, -15} | {2, -15} | {3, -22} | {4, -10}",
   "Id", "Nome", "Fabricante", "Preço de Aquisição", "Data de Fabricação"
);

        for (int i = 0; i < repositorioEquipamento.equipamentos.Length; i++)
        {
            Equipamento? e = repositorioEquipamento.equipamentos[i];

            if (e == null)
            {
                break;
            }
            Console.WriteLine(
      "{0, -7} | {1, -15} | {2, -15} | {3, -22} | {4, -10}",
      e.id, e.nome, e.fabricante, e.precoDeAquisicao.ToString("C2"), e.dataDeFabricacao.ToShortDateString()
        );
            System.Console.WriteLine();

            System.Console.WriteLine("Digite ENTER para continuar");
            Console.ReadLine();
        }
    }
}

