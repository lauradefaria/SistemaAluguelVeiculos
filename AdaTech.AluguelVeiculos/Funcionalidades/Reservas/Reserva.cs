using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.AluguelVeiculos.Funcionalidades.Reservas
{
    using Veiculos;
    using Funcionalidades.Pagamentos;
    using Funcionalidades.Retiradas;
    using Funcionalidades.Devolucoes;
    using Usuarios;
    using AdaTech.AluguelVeiculos.Funcionalidades.Pagamentos.Enum;

    internal class Reserva
    {
        private readonly int _id;
        private readonly Veiculo? _veiculo;
        private readonly Cliente? _cliente;
        private int _quantidadeDias;
        private DateTime _dataInicio;
        private DateTime _dataFim;
        private decimal _valorTotal;
        private bool _retiradaAprovada = false;
        private Pagamento? _pagamentoCliente;
        private Retirada _retiradaVeiculo;
        private Devolucao _devolucaoVeiculo;

        internal int Id { get { return _id; } }
        internal Veiculo Veiculo { get { return _veiculo; } }
        internal int QuantidadeDias { get { return _quantidadeDias; } }
        internal DateTime DataInicio
        {
            get { return _dataInicio; }
            set { _dataInicio = value; }
        }
        internal DateTime DataFim
        {
            get { return _dataFim; }
            set { _dataFim = value; }
        }
        internal Pagamento Pagamento { get { return _pagamentoCliente; } }
        internal Retirada Retirada { get { return _retiradaVeiculo; } }
        internal Devolucao Devolucao { get { return _devolucaoVeiculo; } }

        internal void CalcularDias()
        {
            _quantidadeDias = (_dataFim - _dataInicio).Days;

        }
        internal void ValorTotalReserva()
        {
            CalcularDias();
            _valorTotal = _quantidadeDias * _veiculo.ValorDiaria;
        }

        internal Reserva(int id, Veiculo veiculo, Cliente cliente, DateTime dataInicio, DateTime dataFim)
        {
            this._id = id;
            this._veiculo = veiculo;
            this._cliente = cliente;
            this._dataInicio = dataInicio;
            this._dataFim = dataFim;

            ValorTotalReserva();
        }

        internal void RetiradaVeiculo()
        {
            this._retiradaVeiculo = new Retirada(this);
        }

        internal void DevolucaoVeiculo()
        {
            this._devolucaoVeiculo = new Devolucao(this);
        }
        internal void InformacoesReserva()
        {
            Console.Clear();
            Console.WriteLine("\t----- RESERVA -----");
            Console.WriteLine($"Id: {_id}");
            Console.WriteLine($"Data de Retirada: {_dataInicio}");
            Console.WriteLine($"Data de Devolucao: {_dataFim}\n");
            _veiculo.DescricaoVeiculo();
        }
    }
}
