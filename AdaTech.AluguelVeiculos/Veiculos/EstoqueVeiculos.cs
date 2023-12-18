using AdaTech.AluguelVeiculos.Veiculos.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.AluguelVeiculos.Veiculos
{
    internal class EstoqueVeiculos
    {
        public static List<Veiculo> _listaVeiculos = new List<Veiculo>();

        public static List<Veiculo> ListaVeiculos => _listaVeiculos;

        internal static void AdicionarVeiculo(string placa, int assentos, int portas, decimal valorDiaria, string modelo, string cor,
    TipoVeiculoEnum veiculos)
        {
            if(!PlacaExisteNaLista(placa, _listaVeiculos))
            {
                var veiculo = new Veiculo(placa, assentos, portas, valorDiaria, modelo, cor, veiculos);
                _listaVeiculos.Add(veiculo);
            }
            
        }

        internal static bool PlacaExisteNaLista(string placa, List<Veiculo> lista)  //Verificar se já existe a placa no estoque de veiculos
        {
            foreach (Veiculo veiculo in lista)
            {
                if (veiculo.Placa == placa)
                {
                    return true; 
                }
            }
            return false; 
        }

        internal static void ExcluirVeiculo(string placa)
        {
            _listaVeiculos.RemoveAll(veiculo => veiculo.Placa == placa);
        }

        internal static Veiculo SelecionarVeiculo(string placa)
        {
            return _listaVeiculos.FirstOrDefault(veiculo => veiculo.Placa == placa);
        }

        internal static void ExibirCatalogoVeiculos()
        {
            Console.Clear();
            Console.WriteLine("\tEstoque de Veículos:\n");

            foreach (var veiculo in _listaVeiculos)
            {
                Console.WriteLine($"Placa: {veiculo.Placa}, Modelo: {veiculo.Modelo}, Cor: {veiculo.Cor}");
            }

            Console.WriteLine("Pressione qualquer tecla para retornar...");
            Console.ReadLine();
        }
    }
}
