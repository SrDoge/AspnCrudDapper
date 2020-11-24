using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspnCrudDapper.Entities;

namespace AspnCrudDapper.Repository
{
    public interface IFuncionarioRepository
    {
        IEnumerable<Funcionario> GetAllFuncionarios();
        int AddFuncionario(Funcionario funcionario);
        int UpdateFuncionario(Funcionario funcionario);
        Funcionario GetFuncionario(long id);
        int DeleteFuncionario(long id);
    }
}
