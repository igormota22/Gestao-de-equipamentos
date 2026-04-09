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
                    System.Console.Write("Digite o nome do equipamento");
                    novoEquipamento.nome = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(novoEquipamento.nome) && novoEquipamento.nome.Length > 3)
                    {
                        break;
                    }
                } while (true);

                do
                {
                    System.Console.Write("Digite o fabricante");
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
                Console.WriteLine($"O registro \"{novoEquipamento.nome}\" foi cadastrado com sucesso");
                Console.WriteLine("---------------------------------");

            }

            else if (opcaoMenu == "2")
            {

            }

            else if (opcaoMenu == "3")
            {

            }

            else if (opcaoMenu == "4")
            {

            }
        }
    }
}
