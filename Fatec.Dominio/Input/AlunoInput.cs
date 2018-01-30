using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fatec.Dominio.Input
{
    public class AlunoInput
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Email { get; set; }
        public string RA { get; set; }
        public string Curso { get; set; }
        public DateTime DataMatricula { get; set; }
    }
}
