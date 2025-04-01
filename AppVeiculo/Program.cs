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
                utility.Menu();
                int.TryParse(Console.ReadLine(), out escolha);
                switch (escolha)
                {
                    case 1:
                        Console.WriteLine("Cadastrar veículo");
                        Veiculo cadastro = utility.CadastrarVeiculo();
                        if (cadastro != null) 
                            veiculos.Add(cadastro);
                        break;
                    case 2:
                        Console.WriteLine("Listar veículos");
                        utility.ListarVeiculos(veiculos);
                        break;
                    case 3:
                        Console.WriteLine("Alugar veículo");
                        utility.AlugarVeiculo(veiculos);
                        break;
                    case 4:
                        Console.WriteLine("Devolver veículo");
                        utility.DevolverVeiculo(veiculos);
                        break;
                    case 5:
                        Console.WriteLine("Saindo");
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
                Console.WriteLine("\nDigite qualquer tecla continuar...");
                Console.ReadKey();
                Console.Clear();
            } while (escolha != 5);
        }
    }
}
