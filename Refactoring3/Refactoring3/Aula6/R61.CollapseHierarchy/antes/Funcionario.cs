using System;
using System.Collections.Generic;
using System.Text;

namespace refatoracao.R61.CollapseHierarchy.antes
{
    class Programa
    {
        void Main()
        {
            var vendedor = new Vendedor("Walter White", "555-12345", "666-65432");
        }
    }

    abstract class Funcionario
    {
        public string Nome { get; set; }
        public string TelefoneFixo { get; set; }
        public string Celular { get; set; }

        public Funcionario(string nome, string telefoneFixo, string celular)
        {
            Nome = nome;
            TelefoneFixo = telefoneFixo;
            Celular = celular;
        }
    }

    class Vendedor : Funcionario
    {
        public Vendedor(string nome, string telefoneFixo, string celular) : base(nome, telefoneFixo, celular)
        {
        }
    }
}
