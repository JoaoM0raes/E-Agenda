using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Agenda.Compartilhado
{
    public  interface Irepositorio<T> where T : EntidadeBase
    {
        public string Inserir(T entidade);
        public bool Editar(int idSelecionado, T entidade);
        public bool Excluir(int idSelecionado);
        public bool ExisteRegistro(int idSelecionado);
        public T SelecionarRegistro(int idSelecionado);
        List<T> SelecionarTodos();
    }
}
