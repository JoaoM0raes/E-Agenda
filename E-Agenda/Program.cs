using System;
using E_Agenda.Compartilhado;
using E_Agenda.ModuloTarefa;

namespace E_Agenda
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TelaPrincipal principal = new TelaPrincipal();
            while (true)
            {
                TelaBase telaSelecionada= principal.ObterTelaBase();
                string opcao = telaSelecionada.MostrarOpcoes();
                if (telaSelecionada is Icadastravel)
                {
                    Icadastravel telaCadastravel = (Icadastravel)telaSelecionada;
                    if (opcao == "1")
                    {
                        telaCadastravel.Inserir();
                    }
                    if (opcao == "2")
                    {
                        telaCadastravel.Editar();
                    }
                    if(opcao == "3")
                    {
                        telaCadastravel.Excluir();
                    }
                    if (opcao == "4")
                    {
                        telaCadastravel.VisualizarRegistros();
                    }
                    if(telaSelecionada is TelaTarefa)
                    {
                        TelaTarefa telaTarefa = (TelaTarefa)telaSelecionada;
                        if(opcao == "5")
                        {
                             telaTarefa.FinalizarTarefa();
                        }
                    }
                }
            }
        }
    }
}
                                                    