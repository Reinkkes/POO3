using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVeiculo
{
    public abstract class Veiculo : IVeiculo
    {
        public string Modelo { get; private set; }
        public string Marca { get; private set; }
        public int Ano { get; private set; }
        public double ValorDiaria { get; private set; }

        public bool Disponibilidade { get; set; } = true;

        public Veiculo(string modelo, string placa, int ano, double valorDiaria, bool disponibilidade)
        {
            Modelo = modelo;
            Marca = placa;
            Ano = ano;
            ValorDiaria = valorDiaria;
            Disponibilidade = disponibilidade;
        }

        public abstract double CalcularAluguel(int dias);

        public override string ToString()
        {
            string status = this.Disponibilidade ? "LIVRE" : "ALUGADO";
            return $"{GetType().Name}: {Modelo} | Marca: {Marca} | Ano {Ano} | Custo por 5 dias: {CalcularAluguel(5)} | Disponivel para locação: {status}";
        }
    }
}
