using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.AluguelVeiculos.Funcionalidades.Retiradas
{
    using Funcionalidades.Reservas;
    internal class Retirada
    {
        private bool _veiculoRetirado = false;

        public bool VeiculoRetirado { get { return _veiculoRetirado; } }

        internal Retirada(Reserva reserva)
        {
            if (reserva.DataInicio == DateTime.Now)
            {
                _veiculoRetirado = true;
            }
            else
            {
                _veiculoRetirado = false;
            }

        }
        internal void RetiradaVeiculoAutorizada(Reserva reserva)
        {
            this._veiculoRetirado = true;
            reserva.DataInicio = DateTime.Now;
            reserva.Veiculo.Alugado();
        }
    }
}
