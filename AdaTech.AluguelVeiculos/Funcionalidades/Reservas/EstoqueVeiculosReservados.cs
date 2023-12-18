using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.AluguelVeiculos.Funcionalidades.Reservas
{
    internal class EstoqueVeiculosReservados
    {
        private static List<Reserva> _listaReservas = new List<Reserva>();

        internal static void AdicionarReserva(Reserva reserva)
        {
            _listaReservas.Add(reserva);
        }

        internal static void ExcluirReserva(int id)
        {
            _listaReservas.RemoveAll(reserva => reserva.Id == id);
        }

        internal static Reserva SelecionarReserva(int id)
        {
            return _listaReservas.FirstOrDefault(reserva => reserva.Id == id);
        }
        internal static void ExibirCatalogoReservas()
        {
            Console.Clear();
            Console.WriteLine("\tRESERVAS NOS PRÓXIMOS 30 DIAS\n");
            
            DateTime proximoMes = DateTime.Now.AddMonths(+1);

            foreach (var reserva in _listaReservas)
            {
                if (reserva.DataInicio >= proximoMes)
                {
                    reserva.InformacoesReserva();
                }
            }

            Console.WriteLine("Pressione qualquer tecla para retornar...");
            Console.ReadLine();
        }
    }
}
