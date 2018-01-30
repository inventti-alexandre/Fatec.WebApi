using Dapper;
using Fatec.Dominio.Modelos;
using Fatec.Dominio.Repositorio;
using Fatec.Dominio.ViewModel;
using Fatec.Infra.Repositorio.Contexto;
using System.Data;
using System.Linq;


namespace Fatec.Infra.Repositorio.Base
{
    public sealed class AlunoRepositorio : IRepositorioBase<Aluno>
    {
        readonly DapperContexto _db;
        readonly IDbConnection _connection;
        public AlunoRepositorio()
        {
            _db = new DapperContexto();
            _connection = _db.Connection;
        }

        public AlunoViewModel SelecionarPorId(int id)
        {
            var sqlCommand = @"SELECT a.Id, p.Nome, p.Idade, p.Email, a.RA, a.Curso, a.DataMatricula  
                                FROM Aluno a
                                INNER JOIN Pessoa p on a.IdPessoa = p.Id 
                                WHERE a.id = @id";

            return _connection.Query<AlunoViewModel>(sqlCommand, new { id }).SingleOrDefault();
        }

        public Aluno SelecionarPessoaAluno(int id)
        {
            var sqlCommand = @"SELECT *  
                                FROM Aluno a
                                INNER JOIN Pessoa p on a.IdPessoa = p.Id 
                                WHERE a.id = @id";

            var resultado = _connection.Query<Aluno, Pessoa, Aluno>(sqlCommand, (a, p) => 
                                {
                                    a.Pessoa = p;
                                    return a;
                                },
                                param: new { id },
                                splitOn: "Id"
            ).FirstOrDefault();



            return resultado;
        }

        public int Inserir(Aluno obj)
        {
            return _connection.Query<int>(@" INSERT Aluno (IdPessoa, RA, Curso, DataMatricula)
                                           VALUES (@IdPessoa, @RA, @Curso, @DataMatricula)
                                          SELECT CAST (SCOPE_IDENTITY() as int)", obj).First();
        }

        public void Alterar(Aluno obj)
        {
            var sqlCommand = @"UPDATE Aluno 
                                SET RA = @RA, Curso = @Curso, DataMatricula = @DataMatricula
                               WHERE Id = @Id";


            _connection.Execute(sqlCommand, obj);
        }

        public void Delete(int id)
        {
            _connection.Execute("DELETE FROM Aluno WHERE Id = @Id", new { Id = id });
        }
    }
}
