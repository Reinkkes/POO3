using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVeiculo
{
    public class Moto : Veiculo, IVeiculo
    {
        public Moto(string modelo, string marca, int ano, double valorAluguel, bool disponibilidade) : base(modelo, marca, ano, valorAluguel, disponibilidade) { }

        public override double CalcularAluguel(int dias)
        {
            return ValorDiaria * dias - (this.ValorDiaria*dias*0.1);
        }
    }
}
