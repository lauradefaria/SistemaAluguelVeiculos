using AdaTech.AluguelVeiculos.Funcionalidades.Pagamentos.Enum;
using AdaTech.AluguelVeiculos.Veiculos.Enums;
using AdaTech.AluguelVeiculos.Veiculos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdaTech.AluguelVeiculos.Funcionalidades.Reservas;

namespace AdaTech.AluguelVeiculos.Usuarios
{
    internal class Funcionario
    {
        private readonly string _nome;
        private readonly string _cpf;
        private int _senha;
        private bool _ativo;

        internal string Cpf { get { return _cpf; } }
        internal string Nome { get { return _nome; } }
        internal int Senha
        {
            get { return _senha; }
            set { _senha = value; }
        }
        internal bool Ativo
        {
            get { return _ativo; }
            set { _ativo = value; }
        }

        internal Funcionario(string nome, string cpf, int senha)
        {

            this._nome = nome;
            this._cpf = cpf;
            this._senha = senha;
            this.Ativo = true;
        }

        internal bool CadastroVeiculo(string placa, int assentos, int portas, decimal valorDiria, string modelo, string cor,
            TipoVeiculoEnum veiculos, int senha)
        {
            if (senha == _senha)
            {
                EstoqueVeiculos.AdicionarVeiculo(placa, assentos, portas, valorDiria, modelo, placa, veiculos);
                return true;
            }
            else
            {
                Console.WriteLine("Senha incorreta, tente novamente");
                return false;
            }
        }
        internal bool ExcluirVeiculo(string placa, int senha)
        {
            if(senha == _senha)
            {
                EstoqueVeiculos.ExcluirVeiculo(placa);
                return true;
            }
            else
            {
                Console.WriteLine("Senha incorreta, tente novamente");
                return false;
            }
        }

        internal bool ConfirmarPagamentoCliente(int id)
        {
            var reserva = EstoqueVeiculosReservados.SelecionarReserva(id);
            if (reserva.Pagamento.StatusPagamento == StatusPagamentoEnum.Pago)
            {
                reserva.Veiculo.StatusCarro = StatusCarroEnum.Reservado;
                return true;
            }
            return false;
        }
        internal void AutorizarRetiradaVeiculo(int id)
        {
            var reserva = EstoqueVeiculosReservados.SelecionarReserva(id);
            if (ConfirmarPagamentoCliente(id))
            {

                reserva.RetiradaVeiculo();
                reserva.Retirada.RetiradaVeiculoAutorizada(reserva);
            }
        }
    }
}
