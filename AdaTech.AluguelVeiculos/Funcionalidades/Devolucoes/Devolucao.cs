using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.AluguelVeiculos.Funcionalidades.Devolucoes
{
    using Reservas;
    internal class Devolucao
    {
        private DateTime _dataDevolucao;
        private readonly bool _veiculoDevolvido = false;
        internal DateTime DataDevolucao
        {
            get { return _dataDevolucao; }
            set { _dataDevolucao = value; }
        }
        internal Devolucao (Reserva reserva)
        {
            this._veiculoDevolvido = true;
            _dataDevolucao = DateTime.Now;
            reserva.Veiculo.StatusCarro = Veiculos.Enums.StatusCarroEnum.Disponivel;
        }
    }
}
