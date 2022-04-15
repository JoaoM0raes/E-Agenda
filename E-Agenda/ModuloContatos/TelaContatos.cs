using E_Agenda.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace E_Agenda.ModuloContatos
{
    public class TelaContatos:TelaBase,Icadastravel
    {
        RepositórioContatos repositorio;
        public TelaContatos(RepositórioContatos repositorio) : base("Cadastro Contatos")
        {
         this.repositorio = repositorio;    
        }
        public void Inserir() {

            Contatos novoContato = ObterContato();
            repositorio.Inserir(novoContato);
        }
        public void Editar() {
            Console.WriteLine("Escreva o id do Contado para sua edição");
            int id =Convert.ToInt32(Console.ReadLine());
            Contatos contatos = ObterContato();
            repositorio.Editar(id,contatos);

        }
        public void Excluir() {
            Console.WriteLine("Escreva o id do Contado para exlcuir" );
            int id = Convert.ToInt32(Console.ReadLine());
            repositorio.Excluir(id);

        }
        public void VisualizarRegistros()
        {
            List<Contatos> contatos = repositorio.SelecionarTodos();
            foreach (Contatos contato in contatos)
            {
                Console.WriteLine(contato.ToString());
                Console.ReadLine();
            }
        }

        public Contatos ObterContato()
        {
          Console.WriteLine("Escreva o nome do seu contato");
          string nome = Console.ReadLine();
          string email;
            while (true)
            {
                Console.WriteLine($"Escreva o email do seu contato exemplo {nome}@gmail.com");
                email = Console.ReadLine();
                bool validarEmail = ValidarObterEmail(email);
                if (validarEmail == false)
                {
                    
                    Console.WriteLine("Favor colocar um Email válido");
                    
                    continue;
                }
                else
                    break; 
            }
            int numero;
            while (true)
            {
                Console.WriteLine("Escreva o telefone do seu contato Obs precisa ter 9 digitos");
               numero = Convert.ToInt32(Console.ReadLine());
                bool validar = ValidarObterNumero(numero);
                if (validar == false)
                {
                    Console.WriteLine("Favor colocar um número válido");

                    continue;
                }
                else
                    break;
            }
          
            


          Console.WriteLine("Escreva a empresa do seu contato");
          string empresa=Console.ReadLine();

          Console.WriteLine("Escreva o cargo do seu contato");
          string cargo = Console.ReadLine();

          Contatos novoContato = new Contatos(nome,email,numero,empresa,cargo);
          return novoContato; 

         
        }
        public bool ValidarObterEmail(string conteudo)
        {
               
            try
            {
                MailAddress NovoEmail = new MailAddress(conteudo);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }

        }
        public bool ValidarObterNumero(int numero)
        {
            string total = numero.ToString();
            if(total.Length > 9 && total.Length<9 )
            {
                return false;
            }
            else
            {
                return true; 
            }
        }
        
     

    }
}
