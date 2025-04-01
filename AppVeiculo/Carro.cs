using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVeiculo
{
    public class Carro : Veiculo, IVeiculo
    {
        public Carro(string modelo, string marca, int ano, double valorAluguel, bool disponibilidade) : base(modelo, marca, ano, valorAluguel, disponibilidade) { }

        public override double CalcularAluguel(int dias)
        {
            return this.ValorDiaria*dias;
        }
    }
}
