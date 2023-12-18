using AdaTech.AluguelVeiculos.Funcionalidades.Pagamentos.Enum;
using AdaTech.AluguelVeiculos.Funcionalidades.Reservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.AluguelVeiculos.Funcionalidades.Pagamentos
{
    internal class Pagamento
    {
        private readonly decimal _valorFinal;
        private StatusPagamentoEnum _statusPagamento;
        private readonly decimal _taxaJuros = 0.1m;

        internal StatusPagamentoEnum StatusPagamento { get { return _statusPagamento; } }

        internal Pagamento(Reserva reserva)
        {
            _valorFinal = reserva.Veiculo.AlugarVeiculo(reserva.QuantidadeDias);
            _statusPagamento = StatusPagamentoEnum.EmAberto;
        }
        internal decimal PagamentoAtrasado(DateTime dataDevolvido, DateTime dataFim, decimal valor)
        {
            _statusPagamento = StatusPagamentoEnum.Atrasado;
            return ((dataDevolvido - dataFim).Days) * _taxaJuros * valor;
        }
        internal bool EfetuarPagamento(decimal valorPago)
        {
            if (valorPago >= _valorFinal)
            {
                Console.Clear();
                _statusPagamento = StatusPagamentoEnum.Pago;
                Console.WriteLine($"\t------ RECIBO ------\n");
                Console.WriteLine($"Data de pagamento: {DateTime.Now}");
                Console.WriteLine($"Valor pago: {valorPago}");
                Console.WriteLine($"Valor do aluguel: {_valorFinal}");
                Console.WriteLine("---------------------------");
                Console.WriteLine($"Troco: {_valorFinal - valorPago}\n");
                return true;
            }
            else
            {
                Console.WriteLine($"Pagamento não efetuado com sucesso. Faltam R$ {_valorFinal - valorPago} reais");
                return false;
            }

            Console.WriteLine("Pressione qualquer tecla para retornar...");
            Console.ReadLine();
        }
    }
}
