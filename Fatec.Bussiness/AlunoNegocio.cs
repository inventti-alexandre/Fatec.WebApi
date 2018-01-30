using Fatec.Dominio.Input;
using Fatec.Dominio.Modelos;
using Fatec.Dominio.ViewModel;
using Fatec.Infra.Repositorio.Base;
using Fatec.SharedKernel.Excecoes;
using Microsoft.AspNetCore.JsonPatch;

namespace Fatec.Bussiness
{
    public sealed class AlunoNegocio
    {
        PessoaRepositorio _pessoaRepositorio;
        AlunoRepositorio _alunoRepositorio;

        public AlunoNegocio()
        {
            _pessoaRepositorio = new PessoaRepositorio();
            _alunoRepositorio = new AlunoRepositorio();
        }

        public AlunoViewModel Adicionar(AlunoInput obj)
        {
            var objPessoa = new Pessoa()
            {
                Email = obj.Email,
                Nome = obj.Nome,
                Idade = obj.Idade
            };

            var idPessoa = _pessoaRepositorio.Inserir(objPessoa);

            var objAluno = new Aluno()
            {
                IdPessoa = idPessoa,
                Curso = obj.Curso,
                DataMatricula = obj.DataMatricula,
                RA = obj.RA
            };

            var idAluno = _alunoRepositorio.Inserir(objAluno);

            return _alunoRepositorio.SelecionarPorId(idAluno);
        }

        public AlunoViewModel Atualizar(int id, AlunoInput obj)
        {
            var aluno = _alunoRepositorio.SelecionarPessoaAluno(id);

            if (aluno == null)
                throw new NotFoundException("Aluno não encontrado!", id);

            aluno.Pessoa.Nome = obj.Nome;
            aluno.Pessoa.Idade = obj.Idade;
            aluno.Pessoa.Email = obj.Email;
            aluno.RA = obj.RA;
            aluno.Curso = obj.Curso;
            aluno.DataMatricula = obj.DataMatricula;

            _pessoaRepositorio.Alterar(aluno.Pessoa);
            _alunoRepositorio.Alterar(aluno);

            return _alunoRepositorio.SelecionarPorId(id);
        }

        public AlunoViewModel Atualizar(int id, JsonPatchDocument<Aluno> obj)
        {
            var aluno = _alunoRepositorio.SelecionarPessoaAluno(id);
            if (aluno == null)
                throw new NotFoundException("Aluno não encontrado!", id);

            obj.ApplyTo(aluno);

            _alunoRepositorio.Alterar(aluno);

            return _alunoRepositorio.SelecionarPorId(id);
        }

        public void Deletar(int id)
        {
            var aluno = _alunoRepositorio.SelecionarPessoaAluno(id);
            if (aluno == null)
                throw new NotFoundException("Aluno não encontrado!", id);

            _alunoRepositorio.Delete(id);
            _pessoaRepositorio.Delete(aluno.IdPessoa);
        }

        public AlunoViewModel SelecionarPorId(int id)
        {
            return _alunoRepositorio.SelecionarPorId(id);
        }
    }
}
