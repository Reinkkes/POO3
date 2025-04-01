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
            Console.WriteLine("1 - Cadastrar veículo");
            Console.WriteLine("2 - Listar veículos");
            Console.WriteLine("3 - Alugar veículo");
            Console.WriteLine("4 - Devolver veículo");
            Console.WriteLine("5 - Sair");
        }

        public Veiculo CadastrarVeiculo()
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

            if (ano == 0 || valorAluguel == 0 || marca.Equals(null) || modelo.Equals(null))
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

        public void ListarVeiculos(List<Veiculo> veiculos)
        {
            foreach (var veiculo in veiculos)
            {
                Console.WriteLine(veiculo);
            }
        }

        public void AlugarVeiculo(List<Veiculo> veiculos)
        {
            if (veiculos == null || veiculos.Count == 0)
            {
                Console.WriteLine("Não há veículos disponíveis para alugar.");
                return;
            }

            ListarVeiculos(veiculos);
            Console.WriteLine("Informe o modelo do veículo a ser alugado:");
            string modelo = Console.ReadLine();
            Veiculo veiculo = veiculos.Find(v => v.Modelo == modelo);
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

        public void DevolverVeiculo(List<Veiculo> veiculos)
        {
            ListarVeiculos(veiculos);
            Console.WriteLine("Informe o modelo do veículo a ser devolvido:");
            string modelo = Console.ReadLine();
            var veiculo = veiculos.Find(v => v.Modelo == modelo);
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
    }
}
