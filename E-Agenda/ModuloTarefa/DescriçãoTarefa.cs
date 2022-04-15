using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Agenda.ModuloTarefa
{
    public class DescriçãoTarefa
    {
        private string descricao;
        public bool status;
        public DescriçãoTarefa(string descricao, bool status)
        {
            this.descricao = descricao;
            this.status = status;
        }
         public string Descricao { get { return descricao; } }
         public bool Status { get { return status; } }

        public override string ToString()
        {
            return "Descrição: " + Descricao + Environment.NewLine +
              "Status: " + EstaFinalizado() + Environment.NewLine;

        }
        public string EstaFinalizado()
        {
            if (Status == true)
            {
                return "Fechado";
            }
            return "Aberto";
        }


    }
}
