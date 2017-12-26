using System;
using System.Collections.Generic;
using System.Text;

namespace refatoracao.R51.ReplaceConstructorWithFactoryMethod.antes
{
    class Programa
    {
        void Main()
        {
            Funcionario funcionario = new Funcionario("José da Silva", 1000);
        }
    }

    class Funcionario
    {
        readonly string nome;
        public string Nome => nome;

        readonly decimal salario;
        public decimal Salario => salario;

        public Funcionario(string nome, decimal salario)
        {
            this.nome = nome;
            this.salario = salario;

            LancarRegistrosNoBancoDeDados(this);
            GerarDocumentosFiscais(this);
            EnviarEmailDeBoasVindas(this);
        }

        private void EnviarEmailDeBoasVindas(Funcionario funcionario)
        {
            //método criado apenas para ilustração
        }

        private void GerarDocumentosFiscais(Funcionario funcionario)
        {
            //método criado apenas para ilustração
        }

        private void LancarRegistrosNoBancoDeDados(Funcionario funcionario)
        {
            //método criado apenas para ilustração
        }
    }
}
