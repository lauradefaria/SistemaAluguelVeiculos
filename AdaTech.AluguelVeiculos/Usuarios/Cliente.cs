using AdaTech.AluguelVeiculos.Funcionalidades.Pagamentos;
using AdaTech.AluguelVeiculos.Funcionalidades.Reservas;
using AdaTech.AluguelVeiculos.Veiculos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.AluguelVeiculos.Usuarios
{
    internal class Cliente
    {
        private readonly string _cpf;
        private readonly string _nome;
        private readonly string _cnh;
        private bool _habilitado;
        private Reserva _reservaCliente;

        internal string Cpf { get { return _cpf; } }
        internal string Nome {get { return _nome; } }
        internal string Cnh { get { return _cnh; } }

        internal bool Habilitado
        {
            get { return _habilitado; }
            set { _habilitado = value; }
        }
        internal Reserva Reserva { get { return _reservaCliente; } }
        internal void ReservarVeiculo(string placa, DateTime dataInicio, DateTime dataFim)
        {
            int idReserva = EstoqueVeiculosReservados.QuantidadeReservas();
            if(idReserva >= 0)
            {
                idReserva++;
            }
            else
            {
                idReserva = 0;
            }

            Veiculo veiculo = EstoqueVeiculos.SelecionarVeiculo(placa);
            _reservaCliente = new Reserva(idReserva, veiculo, this, dataInicio, dataFim);
            EstoqueVeiculosReservados.AdicionarReserva(_reservaCliente);
        }

        internal void RealizarPagamento(int id, decimal valorPago)
        {
            var reserva = EstoqueVeiculosReservados.SelecionarReserva(id);
            reserva.Pagamento.EfetuarPagamento(valorPago);
        }
    }
}
