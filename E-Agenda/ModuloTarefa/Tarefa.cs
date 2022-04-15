using E_Agenda.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Agenda.ModuloTarefa
{
    public class Tarefa : EntidadeBase
    {
        private string titulo;
        public DateTime dataInicial;
        public DateTime dataFinal;
        private Prioridade prioridade;
        public double porcentual;
        public List<DescriçãoTarefa> Descrições;
        public bool status;

        public Tarefa(string titulo, Prioridade prioridade, bool status)
        {
            this.status = status;
            this.Descrições = new List<DescriçãoTarefa> { };
            this.titulo = titulo;
            this.status = true;
            this.prioridade = prioridade;
        }
        public string Titulo { get { return titulo; } }
        public DateTime DataInicial { get { return dataInicial; } }
        public Prioridade Prioridade { get { return prioridade; } }
        public double Porcentual { get { return porcentual; } }



        public override string ToString()
        {
            return "Id: " + id + Environment.NewLine +
                "Titulo: " + Titulo + Environment.NewLine +
                "Data de criação da Tarefa: " + DataInicial + Environment.NewLine +
                "Data de Fechamento da Tarefa: "+ObterDatafinal() + Environment.NewLine +
                "Prioridade: " + Prioridade + Environment.NewLine +
                "Porcetual Concluido " + Porcentual + " % " + Environment.NewLine;


        }
        public string ObterDatafinal()
        {
            if (dataFinal == DateTime.MinValue)
            {
                return "Ainda aberto";
            }
            return dataFinal.ToString();
        }
    }  
}
