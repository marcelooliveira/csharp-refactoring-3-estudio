using System;
using System.Collections.Generic;
using System.Text;

namespace refatoracao.R62.FormTemplateMethod.depois
{
    class Cliente
    {
        public Cliente()
        {
            var resumo = new Resumo(this).GetResumo();
            var resumoHTML = new ResumoHTML(this).GetResumo();
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

    abstract class BaseResumo
    {
        protected readonly Cliente cliente;

        public BaseResumo(Cliente cliente)
        {
            this.cliente = cliente;
        }

        public string GetResumo()
        {
            var result = new StringBuilder();
            result.AppendLine(GetTitulo());
            foreach (var locacao in cliente.Locacoes)
            {
                result.AppendLine(GetDetalheLocacao(locacao));
            }
            result.AppendLine(GetTextoValorDevido());
            result.AppendLine(GetTextoPontosDeFidelidade());
            return result.ToString();
        }

        protected abstract string GetTextoPontosDeFidelidade();

        protected abstract string GetTextoValorDevido();

        protected abstract string GetDetalheLocacao(Locacao locacao);

        protected abstract string GetTitulo();
    }

    class Resumo : BaseResumo
    {
        public Resumo(Cliente cliente) : base(cliente)
        {
        }

        protected override string GetTextoPontosDeFidelidade()
        {
            return $"Você ganhou: { cliente.PontosDeFidelidade.ToString() } pontos";
        }

        protected override string GetTextoValorDevido()
        {
            return "Total devido: " + cliente.ValorTotal.ToString();
        }

        protected override string GetDetalheLocacao(Locacao locacao)
        {
            return "\t" + locacao.Filme.Titulo;
        }

        protected override string GetTitulo()
        {
            return "Resumo de locações de " + cliente.Nome;
        }
    }

    class ResumoHTML : BaseResumo
    {
        public ResumoHTML(Cliente cliente) : base(cliente)
        {
        }

        protected override string GetTextoPontosDeFidelidade()
        {
            return $"Você ganhou <em>{cliente.PontosDeFidelidade.ToString()}</em> pontos.";
        }

        protected override string GetTextoValorDevido()
        {
            return "<p>Total devido: <em>" + cliente.ValorTotal.ToString() + "</em></p>";
        }

        protected override string GetDetalheLocacao(Locacao locacao)
        {
            return locacao.Filme.Titulo + "<br/>";
        }

        protected override string GetTitulo()
        {
            return "<h1>Locações de <em>" + cliente.Nome + "</em></h1>";
        }
    }
}
