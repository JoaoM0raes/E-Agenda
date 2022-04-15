using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Agenda.Compartilhado
{
    public  class repositorioBase<T> : Irepositorio<T> where T : EntidadeBase
    {
        public int contadorId;
        List<T> registros;
        public repositorioBase()
        {
            registros = new List<T>();
        }
        public string Inserir(T entidade)
        {
            entidade.id = ++contadorId;
            registros.Add(entidade);
            return "Registro_Valido";
        }
        public bool Editar(int idSelecionado, T entidade)
        {
            for (int i = 0; i < registros.Count; i++)
            {
                if(registros[i].id==idSelecionado)
                {
                    registros[i].id = idSelecionado;
                    registros[i] = entidade;
                    return true;
                }

            }
            return false;
        }
        public bool Excluir(int idSelecionado)
        {
            for (int i = 0; i < registros.Count; i++)
            {
                if (registros[i].id == idSelecionado)
                {
                    registros.Remove(registros[i]);
                    return true;
                }
            }
            return false;
        }
        public bool ExisteRegistro(int idSelecionado)
        {
            for (int i = 0; i < registros.Count; i++)
            {
                if (registros[i].id == idSelecionado)
                {
                    return true;
                }
            }
            return false;
        }
        public T SelecionarRegistro(int idSelecionado)
        {
            foreach (T registro in registros)
            {
                if(registro.id == idSelecionado)
                {
                    return registro;
                }
            }
            return null;
        }
        public List<T> SelecionarTodos()
        {
            return registros; 
        }


    }
}
