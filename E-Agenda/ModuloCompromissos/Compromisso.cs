using E_Agenda.Compartilhado;
using E_Agenda.ModuloContatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Agenda.ModuloCompromissos
{
    public class Compromisso:EntidadeBase
    {
        private string assusto;
        private string local;
        private DateTime data;
        private string horaInicial;
        private string horaFinal;
        Contatos contato;

        public Compromisso(string assusto, string local, DateTime data, string horaInicial, string horaFinal,Contatos contato)
        {
            this.contato = contato;
            this.assusto = assusto;
            this.local = local;
            this.data = data;
            this.horaInicial = horaInicial;
            this.horaFinal = horaFinal;
        }

        public string Assusto { get { return assusto; }}
        public string Local { get { return local; }}
        public DateTime Data { get { return data; }}
        public string HoraInicial { get { return horaInicial; }}
        public string HoraFinal { get { return horaFinal; }}
        public string Contato { get { return contato.Nome; } }

        public override string ToString()
        {
            return "Id: " + id + Environment.NewLine +
                "Assusto: " + Assusto + Environment.NewLine +
                "Local: " + Local + Environment.NewLine +
                "Data: " + Data.ToShortDateString() + Environment.NewLine +
                "Contato: "+Contato + Environment.NewLine +
                "Hora Inicial: " + HoraInicial + Environment.NewLine +
                "Hora Final: " + HoraFinal   + Environment.NewLine;
        }
    }
}
