using E_Agenda.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Agenda.ModuloContatos
{
    public class Contatos:EntidadeBase  
    {
        private string nome;
        private string email;
        private int numero;
        private string empresa;
        private string cargo;

        public Contatos(string nome, string email, int numero, string empresa, string cargo)
        {
            this.nome = nome;
            this.email = email;
            this.numero = numero;
            this.empresa = empresa;
            this.cargo = cargo;
        }
        public string Nome { get { return nome; }  }
        public string Email { get { return email; } }
        public int Numero { get { return numero; } }
        public string Empresa { get { return empresa; } }
        public string Cargo { get { return cargo; } }

        public override string ToString()
        {
            return "Id: " + id + Environment.NewLine +
                "Nome: " + Nome + Environment.NewLine +
                "Email: " + Email + Environment.NewLine +
                "Numero: " + Numero + Environment.NewLine +
                "Empresa: " + Empresa + Environment.NewLine +
                "Cargo:" + Cargo + " % " + Environment.NewLine;


        }
    }
}
