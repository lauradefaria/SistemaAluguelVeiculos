using AdaTech.AluguelVeiculos.Veiculos.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.AluguelVeiculos.Veiculos
{
    internal class Veiculo
    {
        private string _placa;
        private StatusCarroEnum _statusCarro;
        private int _assentos;
        private int _portas;
        private decimal _valorDiaria;
        private string _modelo;
        private string _cor;
        private TipoVeiculoEnum _tipoVeiculos;

        internal string Placa
        {
            get { return _placa; }
            set { _placa = value; }
        }

        internal StatusCarroEnum StatusCarro
        {
            get { return _statusCarro; }
            set { _statusCarro = value; }
        }

        internal int Assentos
        {
            get { return _assentos; }
            set { _assentos = value; }
        }

        internal int Portas
        {
            get { return _portas; }
            set { _portas = value; }
        }

        internal decimal ValorDiaria
        {
            get { return _valorDiaria; }
            set { _valorDiaria = value; }
        }

        internal string Modelo
        {
            get { return _modelo; }
            set { _modelo = value; }
        }

        internal string Cor
        {
            get { return _cor; }
            set { _cor = value; }
        }

        internal TipoVeiculoEnum TipoVeiculos
        {
            get { return _tipoVeiculos; }
            set { _tipoVeiculos = value; }
        }

        public Veiculo(string placa, int assentos, int portas, decimal valorDiria, string modelo, string cor,
            TipoVeiculoEnum tipoVeiculos)
        {
            this._placa = placa;
            this._assentos = assentos;
            this._portas = portas;
            this._valorDiaria = valorDiria;
            this._modelo = modelo;
            this._cor = cor;
            this._tipoVeiculos = tipoVeiculos;
            this._statusCarro = StatusCarroEnum.Disponivel;
        }

        internal decimal AlugarVeiculo (int quantidadeDias)
        {
            return quantidadeDias * _valorDiaria;
        }
        internal void DescricaoVeiculo()
        {
            Console.WriteLine("\t\t DESCRIÇÃO DO VEÍCULO\n");
            Console.WriteLine($"Placa: {Placa}\nModelo: {Modelo}\nCor: {Cor}\nTipo de Veículo: {TipoVeiculos}\nValor da diária: {ValorDiaria}");
        }
    }
}
