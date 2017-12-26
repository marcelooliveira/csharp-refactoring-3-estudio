using System;
using System.Collections.Generic;
using System.Text;

namespace refatoracao.R53.ReplaceExceptionwithTest.antes
{
    class Programa
    {
        void Main()
        {
            var segurado = new Segurado();
            segurado.CumprindoCarencia = true;
            segurado.MensalidadesAtrasadas = 2;
            segurado.MesesSemSinistro = 3;

            decimal seguroAReceber = 0;

            try
            {
                segurado.ValorSeguroAReceber();
            }
            catch 
            {
            }

            Console.WriteLine($"Valor do seguro: {seguroAReceber}");
        }
    }

    class Segurado
    {
        bool cumprindoCarencia;
        public bool CumprindoCarencia
        {
            get => cumprindoCarencia;
            set => cumprindoCarencia = value;
        }

        int mensalidadesAtrasadas;
        public int MensalidadesAtrasadas
        {
            get => mensalidadesAtrasadas;
            set => mensalidadesAtrasadas = value;
        }

        int mesesSemSinistro;
        public int MesesSemSinistro
        {
            get => mesesSemSinistro;
            set => mesesSemSinistro = value;
        }

        public decimal ValorSeguroAReceber()
        {
            if (NaoEhElegivelParaSeguro())
            {
                throw new Exception("Segurado não é elegível para receber seguro");
            }

            decimal resultado = 0;

            //
            //Aqui é calculado o valor do seguro...
            //
            return resultado;
        }

        private bool NaoEhElegivelParaSeguro()
        {
            return cumprindoCarencia 
                || mensalidadesAtrasadas > 1 
                || mesesSemSinistro < 12;
        }
    }
}
