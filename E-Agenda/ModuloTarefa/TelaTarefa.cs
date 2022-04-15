using E_Agenda.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Agenda.ModuloTarefa
{
    public class TelaTarefa:TelaBase,Icadastravel 
    {
       public RepositorioTarefa repositorio;
        public TelaTarefa(RepositorioTarefa repositorio) : base("Cadastro Tarefa")
        {
            this.repositorio = repositorio; 
        }
        public override string MostrarOpcoes()
        {
            MostrarTitulo(Titulo);

            Console.WriteLine("Digite 1 para Inserir");
            Console.WriteLine("Digite 2 para Editar");
            Console.WriteLine("Digite 3 para Excluir");
            Console.WriteLine("Digite 4 para Visualizar suas Tarefas");
            Console.WriteLine("Digite 5 para finalizar sua tarefa");
            

            Console.WriteLine("Digite s para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }
        public void Inserir()
        {
            Tarefa novaTarefa = ObterTarefa();
            novaTarefa.dataInicial=DateTime.Now;
            string resultado =repositorio.Inserir(novaTarefa);
            if (resultado == "Registro_Valido")
            {
                Console.WriteLine("Registrado com sucesso!");
            }
            else
            {
                Console.WriteLine("Erro no cadastro"); 
            } 
        }
        public Tarefa ObterTarefa()
        {            
            Console.WriteLine("Escreva o Titulo da Tarefa");
            string titulo=Console.ReadLine();
            Prioridade prioridade = ObterPrioridade();              
            Tarefa novaTarefa = new Tarefa(titulo,prioridade,true);
            while (true)
            {
                DescriçãoTarefa descrição = ObterDescricao(titulo);
                novaTarefa.Descrições.Add(descrição);
                Console.WriteLine($"Deseja Adicionar mais atividades para a realização do {titulo} s/n");
                string opcao=Console.ReadLine();
                if (opcao == "n")
                {
                    break;
                }
                else
                {
                    continue;
                }
            }            
            novaTarefa.porcentual = 0;
            return novaTarefa; 
        }
        public void Editar()
        {
            Console.WriteLine("Escreva o Id da tarefa para editar");
            int idSelecionado=Convert.ToInt32(Console.ReadLine());
            Tarefa tarefaEditada=ObterTarefa();
            repositorio.Editar(idSelecionado,tarefaEditada);
        }
        public void Excluir()
        {
            Console.WriteLine("Escreva o id da tarefa para excluir");
            int id= Convert.ToInt32(Console.ReadLine());    
            repositorio.Excluir(id);
            Console.WriteLine("Excluido com sucesso");
        }
        public void VisualizarRegistros()
        {
          List<Tarefa>tarefas = repositorio.SelecionarTodos();
            if (tarefas.Count == 0)
            {
                Console.WriteLine("Nenhuma tarefa adicionada ainda");
            }  
          Console.WriteLine("Digite 1 para acessar tarefas em aberto ou 2 para acessar Tarefas fechadas");
            string opcao = Console.ReadLine();
            if(opcao == "1")
            {
                VizulizarTarefasAbertas(tarefas);
            }
            else
            {
                VizulizarTarefasFechadas(tarefas);
            }

        }
        public Prioridade ObterPrioridade()
        {
            Console.WriteLine("Escreva a prioridade da Tarefa entre Alta,Media,Baixa");
            string prioridade=Console.ReadLine();
            if (prioridade == "Alta")
            {
                return Prioridade.Alta;
            } else if (prioridade == "Media")
            {
                return Prioridade.Media;
            }
            return Prioridade.Baixa;   
        }
        public DescriçãoTarefa ObterDescricao(string nomeTarefa)
        {         
           Console.WriteLine($"Escreva uma atividade para a relização do {nomeTarefa}");
           string descrição = Console.ReadLine();
           DescriçãoTarefa novaDescricao = new DescriçãoTarefa(descrição,false);
           return novaDescricao;   
        }
        public void VizulizarTarefasAbertas(List<Tarefa>tarefas)
        {
            List<Tarefa> tarefasOrdenadas = tarefas.OrderByDescending(o=>o.Prioridade).ToList();
            Console.WriteLine("Tarefas em Aberto");
            Console.WriteLine();
            for (int i = 0; i < tarefasOrdenadas.Count; i++)
            {
                if (tarefasOrdenadas[i].status == true)
                {
                      Console.WriteLine(tarefasOrdenadas[i].ToString());
                }
                else
                {
                    Console.WriteLine("Nenhuma tarefa Aberta");

                }
            }
            Console.ReadLine();

        }
        public void VizulizarTarefasFechadas(List<Tarefa> tarefas)
        {
            
            Console.WriteLine("Tarefas Fechadas");
            Console.WriteLine();
            for (int i = 0; i < tarefas.Count; i++)
            {
                if (tarefas[i].status == false)
                {
                    Console.WriteLine(tarefas[i].ToString());
                }
                else
                {
                    Console.WriteLine("Nenhuma tarefa Fechada"); 
                    
                }
            }
            Console.ReadLine();
        }
        public void FinalizarTarefa()
        {
            Console.WriteLine("Escreva o id da tarefa para finalizar");
            int opcao = Convert.ToInt32(Console.ReadLine());
            Tarefa tarefa = repositorio.SelecionarRegistro(opcao);
            List< DescriçãoTarefa> descrições = tarefa.Descrições;
            Console.WriteLine("Ativadades para finalizar");
            Console.WriteLine();
            for (int i = 0; i < descrições.Count; i++)
            {
                if (descrições[i].status == false)
                {
                    Console.WriteLine(descrições[i].ToString());

                    Console.Write(" Deseja finalizar a sua atividade? s/n ");
                    string finalizar = Console.ReadLine();
                    if (finalizar == "s")
                    {
                        descrições[i].status = true;
                    }
                }                                        
            }
            double porcentagem = ObterPorcentagem(descrições);
            tarefa.porcentual = porcentagem;
            if (porcentagem == 100)
            {
                tarefa.status = false;
                tarefa.dataFinal=DateTime.Now;
            }

        }
        public double ObterPorcentagem(List<DescriçãoTarefa>NovaDescrição)
        {
            int p = 0; 
            List<DescriçãoTarefa> Descrições = NovaDescrição;
            double tudo = Descrições.Count;

            for (int i = 0; i < Descrições.Count; i++)
            {
                if (Descrições[i].Status == true)
                {
                    p++;
                    
                }
            }
            if (p== 0)
            {
                return 0;
            }
            
            double total = p * 100;
            double resultado = total / tudo;
            return ((int)resultado);
            

        }

    }
}                                 
