using System.Security.Cryptography;

namespace GestaoDeEquipamentos.ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        Equipamento[]? equipamentos = new Equipamento[10];
        while (true)
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

            if (opcaoMenu == "S")
            {
                Console.Clear();
                break;
            }

            if (opcaoMenu == "1")
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

                novoEquipamento.id = Convert.ToHexString(RandomNumberGenerator.GetBytes(20)).ToLower().Substring(0, 7);

                for (int i = 0; i < equipamentos.Length; i++)
                {
                    Equipamento? e = equipamentos[i];

                    if (e == null)
                    {
                        equipamentos[i] = novoEquipamento;
                        break;
                    }
                }

                Console.WriteLine("---------------------------------");
                Console.WriteLine($"O registro \"{novoEquipamento.nome}\" foi cadastrado com sucesso!Digite ENTER para continuar");
                Console.WriteLine("---------------------------------");
                Console.ReadLine();

            }

            else if (opcaoMenu == "2")
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Ediçao de Equipamento");
                Console.WriteLine("---------------------------------");

                Console.WriteLine(
           "{0, -7} | {1, -15} | {2, -15} | {3, -22} | {4, -10}",
           "Id", "Nome", "Fabricante", "Preço de Aquisição", "Data de Fabricação"
       );

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

                System.Console.Write("Informe o ID do equipamento que deseja atualizar:");

            }

            else if (opcaoMenu == "3")
            {

            }

            else if (opcaoMenu == "4")
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Visualização de Equipamento");
                Console.WriteLine("---------------------------------");

                Console.WriteLine(
           "{0, -7} | {1, -15} | {2, -15} | {3, -22} | {4, -10}",
           "Id", "Nome", "Fabricante", "Preço de Aquisição", "Data de Fabricação"
       );

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
            }
        }
    }
}
