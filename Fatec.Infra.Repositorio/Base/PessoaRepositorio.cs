using Dapper;
using Fatec.Dominio.Modelos;
using Fatec.Dominio.Repositorio;
using Fatec.Infra.Repositorio.Contexto;
using System.Data;
using System.Linq;

namespace Fatec.Infra.Repositorio.Base
{
    public sealed class PessoaRepositorio : IRepositorioBase<Pessoa>
    {
        readonly DapperContexto _db;
        readonly IDbConnection _connection;
        public PessoaRepositorio()
        {
            _db = new DapperContexto();
            _connection = _db.Connection;
        }


        public int Inserir(Pessoa obj)
        {
            return _connection.Query<int>(@" INSERT Pessoa(Nome, Idade, Email)
                                           VALUES (@Nome, @Idade, @Email)
                                          SELECT CAST(SCOPE_IDENTITY() AS INT)", obj).First();
        }
        public void Alterar(Pessoa obj)
        {
            var sqlCommand = @"UPDATE Pessoa 
                                SET Nome = @Nome, Idade = @Idade, Email = @Email
                               WHERE Id = @Id";


            _connection.Execute(sqlCommand, obj);
        }

        public void Delete(int id)
        {
            _connection.Execute("DELETE FROM Pessoa WHERE Id = @Id", new { Id = id });
        }

    }
}
