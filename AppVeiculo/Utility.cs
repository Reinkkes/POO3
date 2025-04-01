using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVeiculo
{
    public class Utility
    {
        public void Menu()
        {
            Console.WriteLine("=====================================");
            Console.WriteLine("          LOCADORA DE VEÍCULOS       ");
            Console.WriteLine("=====================================");
            Console.WriteLine("  [1] Cadastrar Veículo");
            Console.WriteLine("  [2] Listar Veículos");
            Console.WriteLine("  [3] Alugar Veículo");
            Console.WriteLine("  [4] Devolver Veículo");
            Console.WriteLine("  [5] Sair");
            Console.WriteLine("=====================================");
            Console.Write(" Escolha uma opção: ");
        }

        public Veiculo CadastrarVeiculo()
        {
            try
            {
                Console.WriteLine("Informe o tipo de veículo (Carro/Moto/Caminhao):");
                string tipo = Console.ReadLine();
                Console.WriteLine("Informe o modelo do veículo:");
                string modelo = Console.ReadLine();
                Console.WriteLine("Informe a marca do veículo:");
                string marca = Console.ReadLine();
                Console.WriteLine("Informe o ano do veículo:");
                int ano = int.TryParse(Console.ReadLine(), out int anoTemp) ? anoTemp : 0;
                Console.WriteLine("Informe o valor da diária do veículo:");
                double valorAluguel = double.TryParse(Console.ReadLine(), out double valorAluguelTemp) ? valorAluguelTemp : 0;
                bool disponibilidade = true;

                if (ano.ToString().Length != 4 || valorAluguel == 0 || string.IsNullOrEmpty(marca) || string.IsNullOrEmpty(modelo))
                {
                    Console.WriteLine("Dados inválidos.");
                    return null;
                }
                else
                {
                    switch (tipo.ToLower())
                    {
                        case "carro":
                            return new Carro(modelo, marca, ano, valorAluguel, disponibilidade);
                        case "moto":
                            return new Moto(modelo, marca, ano, valorAluguel, disponibilidade);
                        case "caminhao":
                            return new Caminhao(modelo, marca, ano, valorAluguel, disponibilidade);
                        default:
                            Console.WriteLine("Tipo de veículo inválido.");
                            return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao cadastrar veículo: {ex.Message}");
                return null;
            }
        }

        public void ListarVeiculos(List<Veiculo> veiculos)
        {
            foreach (var veiculo in veiculos)
            {
                Console.WriteLine(veiculo);
            }
        }

        public void AlugarVeiculo(List<Veiculo> veiculos)
        {
            try
            {
                if (veiculos == null || veiculos.Count == 0)
                {
                    Console.WriteLine("Não há veículos disponíveis para alugar.");
                    return;
                }

                ListarVeiculos(veiculos);
                Console.WriteLine("Informe o modelo do veículo a ser alugado:");
                string modelo = Console.ReadLine();
                Veiculo veiculo = veiculos.Find(veiculoBusca => veiculoBusca.Modelo == modelo);
                if (veiculo == null)
                {
                    Console.WriteLine("Veículo não encontrado.");
                    return;
                }

                Console.WriteLine("Indique por quantos dias será alugado:");
                int.TryParse(Console.ReadLine(), out int dias);
                if (veiculo.Disponibilidade)
                {
                    Console.WriteLine($"Custo do aluguel: {veiculo.CalcularAluguel(dias)}");
                    veiculo.Disponibilidade = false;
                }
                else
                {
                    Console.WriteLine("Veículo não disponível.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao alugar veículo: {ex.Message}");
            }
        }

        public void DevolverVeiculo(List<Veiculo> veiculos)
        {
            try
            {
                ListarVeiculos(veiculos);
                Console.WriteLine("Informe o modelo do veículo a ser devolvido:");
                string modelo = Console.ReadLine();
                Veiculo veiculo = veiculos.Find(veiculoBusca => veiculoBusca.Modelo == modelo);
                if (veiculo != null && !veiculo.Disponibilidade)
                {
                    Console.WriteLine("Veículo devolvido com sucesso.");
                    veiculo.Disponibilidade = true;
                }
                else
                {
                    Console.WriteLine("Veículo não encontrado.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao devolver veículo: {ex.Message}");
            }
        }
    }
}
