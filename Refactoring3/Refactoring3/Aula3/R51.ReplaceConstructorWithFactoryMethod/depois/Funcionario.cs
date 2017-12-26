using System;
using System.Collections.Generic;
using System.Text;

namespace refatoracao.R51.ReplaceConstructorWithFactoryMethod.depois
{
    class Programa
    {
        void Main()
        {
            Funcionario funcionario = Funcionario.CriarFuncionario("José da Silva", 1000);
        }
    }

    class Funcionario
    {
        readonly string nome;
        public string Nome => nome;

        readonly decimal salario;
        public decimal Salario => salario;

        private Funcionario(string nome, decimal salario)
        {
            this.nome = nome;
            this.salario = salario;
        }

        public static Funcionario CriarFuncionario(string nome, decimal salario)
        {
            Funcionario funcionario = new Funcionario(nome, salario);
            LancarRegistrosNoBancoDeDados(funcionario);
            GerarDocumentosFiscais(funcionario);
            EnviarEmailDeBoasVindas(funcionario);
            return funcionario;
        }

        private static void EnviarEmailDeBoasVindas(Funcionario funcionario)
        {
            //método criado apenas para ilustração
        }

        private static void GerarDocumentosFiscais(Funcionario funcionario)
        {
            //método criado apenas para ilustração
        }

        private static void LancarRegistrosNoBancoDeDados(Funcionario funcionario)
        {
            //método criado apenas para ilustração
        }
    }
}
