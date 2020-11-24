using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AspnCrudDapper.Entities;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace AspnCrudDapper.Repository
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly IConfiguration _configuration;

        public FuncionarioRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionsStrings").GetSection("FuncConnection").Value;
            return connection;
        }

        public IEnumerable<Funcionario> GetAllFuncionarios()
        {
            var connectionString = this.GetConnection();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                const string query = "SELECT FuncionarioId, Nome, Cidade, Departamento, Sexo, Salario from crud_Funcionarios";

                return con.Query<Funcionario>(query);
            }
        }

        public int AddFuncionario(Funcionario funcionario)
        {
            var connectionString = this.GetConnection();
            int count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                const string comandoSQL = "Insert into crud_Funcionarios (Nome,Cidade,Departamento,Sexo,Salario) " +
                    "Values(@Nome, @Cidade, @Departamento, @Sexo, @Salario)";
                count = con.Execute(comandoSQL, funcionario);

                return count;
            }
        }

        public int UpdateFuncionario(Funcionario funcionario)
        {
            var connectionString = this.GetConnection();
            var count = 0;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string comandoSQL = "Update crud_Funcionarios set Nome = @Nome, Cidade = @Cidade, Departamento = @Departamento, Sexo = @Sexo, Salario = @Salario " +
                    "where FuncionarioId = " + funcionario.FuncionarioId;
                return count = con.Execute(comandoSQL, funcionario);
            }
        }

        public Funcionario GetFuncionario(long id)
        {
            var connectionString = this.GetConnection();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM crud_Funcionarios WHERE FuncionarioId= " + id;
                return con.Query<Funcionario>(sqlQuery).FirstOrDefault();
            }
        }

        public int DeleteFuncionario(long id)
        {
            var connectionString = this.GetConnection();
            var count = 0;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string comandoSQL = "Delete from crud_Funcionarios where FuncionarioId = " + id;
                return count = con.Execute(comandoSQL);
            }
        }
    }
}
