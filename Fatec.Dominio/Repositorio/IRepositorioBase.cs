using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fatec.Dominio.Repositorio
{
    public interface IRepositorioBase<TEntidade> where TEntidade : class
    {
        int Inserir(TEntidade obj);
        void Alterar(TEntidade obj);
        void Delete(int id);
    }
}
