using E_Agenda.ModuloCompromissos;
using E_Agenda.ModuloContatos;
using E_Agenda.ModuloTarefa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Agenda.Compartilhado
{
    public class TelaPrincipal
    {
        private TelaTarefa telaTarefa;
        private RepositorioTarefa repositorioTarefa;

        private TelaContatos telaContato;
        private RepositórioContatos repositórioContato;

        private TelaCompromisso telaCompromisso;
        private RepositorioCompromisso repositorioCompromisso;  

       public TelaPrincipal()
       {
            repositorioTarefa = new RepositorioTarefa();
            telaTarefa = new TelaTarefa(repositorioTarefa);

            repositórioContato=new RepositórioContatos();
            telaContato=new TelaContatos(repositórioContato);

            repositorioCompromisso=new RepositorioCompromisso();
            telaCompromisso = new TelaCompromisso(repositorioCompromisso,repositórioContato);
       }
        public string MostrarOpcoes()
        {
            Console.Clear();

            Console.WriteLine("Controle de Retirada de Medicamentos 1.0");

            Console.WriteLine();

            Console.WriteLine("Digite 1 para Gerenciar Suas Tarefas");
            Console.WriteLine("Digite 2 para Gerenciar Seus Contatos");
            Console.WriteLine("Digite 3 para Gerenciar Seus Compromissos");



            Console.WriteLine("Digite s para sair");

            string opcaoSelecionada = Console.ReadLine();

            return opcaoSelecionada;
        }
        public TelaBase ObterTelaBase()
        {
            TelaBase tela = null;
            string opcao=MostrarOpcoes();
            if (opcao == "1")
            {
                tela =telaTarefa;
            }else if(opcao == "2")
            {
                tela = telaContato;
            }else if (opcao == "3")
            {
                tela=telaCompromisso;   
            }
            return tela;    
        }
    }
}
