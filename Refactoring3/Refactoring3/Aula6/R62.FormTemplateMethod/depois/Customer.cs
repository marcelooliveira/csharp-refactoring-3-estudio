using System;
using System.Collections.Generic;
using System.Text;

namespace refatoracao.R62.FormTemplateMethod.depois
{
    class Cliente
    {
        public Cliente()
        {
            var resumo = GetResumo();
            var resumoHTML = GetResumoHTML();
        }

        public string GetResumo()
        {
            var resultado = new StringBuilder();
            resultado.AppendLine("Resumo de locações de " + Nome);
            foreach (var locacao in Locacoes)
            {
                resultado.AppendLine("\t" + locacao.Filme.Titulo);
            }
            resultado.AppendLine("Total devido: " + ValorTotal.ToString());
            resultado.AppendLine($"Você ganhou: {PontosDeFidelidade.ToString()} pontos");
            return resultado.ToString();
        }

        public string GetResumoHTML()
        {
            var resultado = new StringBuilder();
            resultado.AppendLine("<h1>Locações de <em>" + Nome + "</em></h1>");
            foreach (var locacao in Locacoes)
            {
                resultado.AppendLine(locacao.Filme.Titulo + "<br/>");
            }
            resultado.AppendLine("<p> Você deve: <em>R$ " + ValorTotal.ToString() + "</em></p>");
            resultado.AppendLine("Você ganhou: " + PontosDeFidelidade.ToString() + "</em> pontos.");
            return resultado.ToString();
        }

        private IList<Locacao> locacoes;
        public IList<Locacao> Locacoes
        {
            get { return locacoes; }
            set { locacoes = value; }
        }

        private double valorTotal;
        public double ValorTotal
        {
            get { return valorTotal; }
            set { valorTotal = value; }
        }

        private double pontosDeFidelidade;
        public double PontosDeFidelidade
        {
            get { return pontosDeFidelidade; }
            set { pontosDeFidelidade = value; }
        }

        private string nome;
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
    }

    class Locacao
    {
        private Filme filme;

        public Filme Filme
        {
            get { return filme; }
            set { filme = value; }
        }
    }

    class Filme
    {
        private string titulo;

        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }
    }
}
