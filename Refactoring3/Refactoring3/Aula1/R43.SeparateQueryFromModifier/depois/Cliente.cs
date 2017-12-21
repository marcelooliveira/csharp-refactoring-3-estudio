using System;
using System.Collections.Generic;
using System.Text;

namespace refatoracao.R43.SeparateQueryFromModifier.depois
{
    public class Program
    {
        void Main()
        {
            IList<NotaFiscal> notasFiscais = new List<NotaFiscal>
            {
                new NotaFiscal(1, 5000),
                new NotaFiscal(2, 1000),
                new NotaFiscal(3, 2000),
                new NotaFiscal(4, 7000),
                new NotaFiscal(5, 2000)
            };

            Cliente cliente = new Cliente();

            cliente.VerificarNotasFiscais(notasFiscais);
        }
    }

    class NotaFiscal
    {
        readonly int id;
        public int Id => id;

        readonly decimal valor;
        public decimal Valor => valor;

        public NotaFiscal(int id, decimal valor)
        {
            this.id = id;
            this.valor = valor;
        }
    }

    class Cliente
    {
        private const int VALOR_NF_CLIENTE_PREMIUM = 10000;

        // ...
        public void VerificarNotasFiscais(IList<NotaFiscal> notasFiscais)
        {
            NotaFiscal nf = ObterNFPremium(notasFiscais);
            if (nf != null)
            {
                EnviarEmailParabens(nf);
                CriarCartaoPremium(nf);
            }
        }

        public NotaFiscal ObterNFPremium(IList<NotaFiscal> notasFiscais)
        {
            foreach (var nf in notasFiscais)
            {
                if (nf.Valor > VALOR_NF_CLIENTE_PREMIUM)
                {
                    return nf;
                }
            }
            return null;
        }

        public NotaFiscal ObterNFPremiumEEnviarEmail(IList<NotaFiscal> notasFiscais)
        {
            foreach (var nf in notasFiscais)
            {
                if (nf.Valor > 10000)
                {
                    EnviarEmailParabens(nf);
                    return nf;
                }
            }
            return null;
        }

        private void CriarCartaoPremium(NotaFiscal nf)
        {
            //código para criar cartão de cliente premium
        }

        private void EnviarEmailParabens(NotaFiscal nf)
        {
            string mensagem = 
                "Prezado Cliente, " +
                "Parabéns! Você se tornou Cliente Premium " +
                "e receberá em breve um cartão exclusivo da nossa loja! " +
                "" +
                "Atenciosamente, " +
                "" +
                "A Sua Loja" +
                "http://asualojamaislegal.com.br";

            //aqui vai o código para enviar o email
        }
    }
}
