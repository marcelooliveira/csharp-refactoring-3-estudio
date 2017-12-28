using System;
using System.Collections.Generic;
using System.Text;

namespace refatoracao.R61.CollapseHierarchy.depois
{
    //Como não aprender orientação a objetos: Herança
    //http://blog.caelum.com.br/como-nao-aprender-orientacao-a-objetos-heranca/
    class Programa
    {
        void Main()
        {
            var empregado = new Funcionario("Walter White", "555-12345", "666-65432");
        }
    }

    class Funcionario
    {
        public string Nome { get; set; }
        public string TelefoneFixo { get; set; }
        public string Celular { get; set; }
        public string CodigoFuncional { get; set; }

        public Funcionario(string nome, string telefoneFixo, string celular)
        {
            Nome = nome;
            TelefoneFixo = telefoneFixo;
            Celular = celular;
        }
    }
}
