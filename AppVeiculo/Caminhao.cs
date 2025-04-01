using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVeiculo
{
    public class Caminhao : Veiculo, IVeiculo
    {
            public Caminhao(string modelo, string marca, int ano, double valorAluguel, bool disponibilidade) : base(modelo, marca, ano, valorAluguel, disponibilidade) { }

            public override double CalcularAluguel(int dias)
            {
                return ValorDiaria * dias *1.2;
            }
    }
}
