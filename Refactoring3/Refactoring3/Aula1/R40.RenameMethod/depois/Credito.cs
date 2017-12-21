using System;
using System.Collections.Generic;
using System.Text;

namespace refatoracao.R40.RenameMethod.depois
{
    class Programa
    {
        void Main()
        {
            var credito = new Credito("Walter White", 10000, 9700);
            Console.WriteLine($"Crédito disponível - Nome: {credito.NomeCliente}, " +
                $"Valor: {credito.GetCreditoDisponivel()}");
        }
    }

    class Credito
    {
        readonly string nomeCliente;
        public string NomeCliente => nomeCliente;

        readonly decimal creditoTotal;
        public decimal CreditoTotal => creditoTotal;

        readonly decimal creditoUtilizado;
        public decimal CreditoUtilizado => creditoUtilizado;

        public Credito(string nomeCliente, decimal creditoTotal, decimal creditoUtilizado)
        {
            this.nomeCliente = nomeCliente;
            this.creditoTotal = creditoTotal;
            this.creditoUtilizado = creditoUtilizado;
        }

        public decimal GetCreditoDisponivel()
        {
            return this.creditoTotal - this.creditoUtilizado;
        }
    }
}
