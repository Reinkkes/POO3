using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVeiculo
{
    public interface IVeiculo
    {
        string Modelo { get; }
        string Marca { get; }
        int Ano { get; }
        double ValorDiaria { get; }
        bool Disponibilidade { get; set; }

        double CalcularAluguel(int dias);
    }
}
