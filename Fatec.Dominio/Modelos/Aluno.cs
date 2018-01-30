using System;

namespace Fatec.Dominio.Modelos
{
    public class Aluno
    {
        public int Id { get; set; }
        public int IdPessoa { get; set; }
        public Pessoa Pessoa { get; set; }
        public string RA { get; set; }
        public string Curso { get; set; }
        public DateTime DataMatricula { get; set; }
    }
}
