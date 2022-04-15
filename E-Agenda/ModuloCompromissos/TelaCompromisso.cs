using E_Agenda.Compartilhado;
using E_Agenda.ModuloContatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Agenda.ModuloCompromissos
{
    internal class TelaCompromisso:TelaBase,Icadastravel
    {
        RepositorioCompromisso repositorio;
        RepositórioContatos repositorioContato;
        public TelaCompromisso(RepositorioCompromisso repositorio,RepositórioContatos repositorioContato) : base("Cadastro Compromisso")
        {
            this.repositorio = repositorio;
            this.repositorioContato = repositorioContato;
        }
        public void Inserir()
        {

            Compromisso novoComprimisso = ObterCompromisso();
            repositorio.Inserir(novoComprimisso);
        }
        public void Editar()
        {
            Console.WriteLine("Escreva o id do Compromisso para sua edição");
            int id = Convert.ToInt32(Console.ReadLine());
            Compromisso compromisso  = ObterCompromisso();
            repositorio.Editar(id, compromisso);

        }
        public void Excluir()
        {
            Console.WriteLine("Escreva o id do Compromisso para Ecluir");
            int id = Convert.ToInt32(Console.ReadLine());
            repositorio.Excluir(id);

        }
        public void VisualizarRegistros()
        {
            while (true)
            {
                Console.WriteLine("Escreva a primeira data para filtrar Ex 00/00/0000");
                DateTime primeiraData = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Escreva a segunda data para filtrar Ex 00/00/0000");
                DateTime segundaData = Convert.ToDateTime(Console.ReadLine());

                bool encontrou = false;
                List<Compromisso> compromissos = repositorio.SelecionarTodos();

                foreach (Compromisso compromisso in compromissos)
                {
                    if (compromisso.Data >= primeiraData && compromisso.Data <= segundaData)
                    {
                        Console.WriteLine(compromisso.ToString());
                        Console.ReadLine();
                        encontrou = true;
                    }
                }
                if (encontrou == false)
                {
                    Console.WriteLine("Nenhum Compromisso encontrado nesse periodo");
                    Console.WriteLine();
                    Console.WriteLine("Deseja continuar? s/n");
                    string opcao = Console.ReadLine();
                    if (opcao == "s")
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                 else
                 {
                    break;
                 }
            }
          

        }

        public Compromisso ObterCompromisso()
        {
            Console.WriteLine("Escreva o assunto do Compromisso");
            string assunto =Console.ReadLine()
                ;
            Console.WriteLine("Escreva o local do seu Compromisso");
            string local=Console.ReadLine();

            Console.WriteLine("Escreva a data do seu Compromisso Ex 00/00/0000");
            DateTime data= Convert.ToDateTime(Console.ReadLine());
            Contatos contato = ObterContato();

            Console.WriteLine("Escreva a hora inicial do Compromisso");
            string horaInicial=Console.ReadLine();

            Console.WriteLine("Escreva a hora final do Compromisso");
            string horaFinal=Console.ReadLine();


            Compromisso novoCompromisso=new Compromisso(assunto,local,data,horaInicial,horaFinal,contato);
            return novoCompromisso;



        }
        public Contatos ObterContato()
        {
            Console.WriteLine("Escreva o id do seu contato para o seu compromisso");
            int id=Convert.ToInt32(Console.ReadLine());
           Contatos novoContato= repositorioContato.SelecionarRegistro(id);
            return novoContato;
        }
        
    }
}
