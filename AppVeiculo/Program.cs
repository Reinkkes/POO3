using System;
using System.Collections.Generic;

namespace AppVeiculo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Utility utility = new Utility();
            List<Veiculo> veiculos = new List<Veiculo>();
            int escolha = 0;
            do
            {
                try
                {
                    utility.Menu();
                    int.TryParse(Console.ReadLine(), out escolha);
                    switch (escolha)
                    {
                        case 1:
                            Console.WriteLine("\n--- CADASTRO VEICULAR ---\n");
                            Veiculo cadastro = utility.CadastrarVeiculo();
                            if (cadastro != null)
                                veiculos.Add(cadastro);
                            break;
                        case 2:
                            Console.WriteLine("\n--- LISTAGEM DE VEICULAR ---\n");
                            utility.ListarVeiculos(veiculos);
                            break;
                        case 3:
                            Console.WriteLine("\n--- LOCAÇÃO DE VEICULAR ---\n");
                            utility.AlugarVeiculo(veiculos);
                            break;
                        case 4:
                            Console.WriteLine("\n--- DEVOLUÇÃO VEICULAR ---\n");
                            utility.DevolverVeiculo(veiculos);
                            break;
                        case 5:
                            Console.WriteLine("--- SAINDO ---");
                            break;
                        default:
                            Console.WriteLine("Opção inválida");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ocorreu um erro: {ex.Message}");
                }
                Console.WriteLine("\nDigite qualquer tecla continuar...");
                Console.ReadKey();
                Console.Clear();
            } while (escolha != 5);
        }
    }
}
