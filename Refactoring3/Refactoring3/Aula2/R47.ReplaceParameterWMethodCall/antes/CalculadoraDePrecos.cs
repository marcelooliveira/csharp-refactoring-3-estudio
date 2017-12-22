using System;
using System.Collections.Generic;
using System.Text;

namespace refatoracao.R47.ReplaceParameterWMethodCall.antes
{
    class Program
    {
        void Main(decimal descontoInicial, int quantidade, string cpfCliente)
        {
            int clienteHaQuantosAnos = ServicoDeCredito.ClienteHaQuantosAnos(cpfCliente);
            bool clienteNegativado = ServicoDeCredito.VerificaClienteNegativado(cpfCliente);

            var descontoCliente =
                new CalculadoraDePrecos()
                .GetDescontoFinal(descontoInicial, quantidade, clienteHaQuantosAnos, clienteNegativado);

            Console.WriteLine($"Desconto final: {descontoCliente}");
        }
    }

    class CalculadoraDePrecos
    {
        private const decimal LIMITE_MAXIMO_DESCONTO_INICIAL = 50m;
        private const int LIMITE_MINIMO_QUANTIDADE = 100;
        private const int LIMITE_MINIMO_ANOS_CLIENTE = 4;
        private const decimal DESCONTO_MAXIMO = 50m;
        private const decimal INCREMENTO_DESCONTO_POR_QUANTIDADE = 15m;
        private const decimal INCREMENTO_DESCONTO_POR_TEMPO = 10m;

        public decimal GetDescontoFinal(decimal descontoInicial, int quantidade, int clienteHaQuantosAnos, bool clienteNegativado)
        {
            if (clienteNegativado)
            {
                return 0; //early return
            }

            var result = descontoInicial;
            if (descontoInicial > LIMITE_MAXIMO_DESCONTO_INICIAL)
            {
                result = DESCONTO_MAXIMO;
            }
            if (quantidade > LIMITE_MINIMO_QUANTIDADE)
            {
                result += INCREMENTO_DESCONTO_POR_QUANTIDADE;
            }
            if (clienteHaQuantosAnos > LIMITE_MINIMO_ANOS_CLIENTE)
            {
                result += INCREMENTO_DESCONTO_POR_TEMPO;
            }
            return result;
        }
    }

    class ServicoDeCredito
    {
        internal static int ClienteHaQuantosAnos(string cpfCliente)
        {
            return 5;
        }

        internal static bool VerificaClienteNegativado(string cpfCliente)
        {
            return false;
        }
    }
}
