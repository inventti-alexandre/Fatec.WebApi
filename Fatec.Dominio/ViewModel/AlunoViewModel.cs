using System;

namespace Fatec.Dominio.ViewModel
{
    public class AlunoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Email { get; set; }
        public string RA { get; set; }
        public string Curso { get; set; }
        public DateTime DataMatricula { get; set; }
    }
}
