using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fatec.SharedKernel.Excecoes
{
    [Serializable]
    public class NotFoundException : Exception
    {
        public int Id { get; private set; }

        public NotFoundException()
        {
        }

        public NotFoundException(int id)
        {
            Id = id;
        }

        public NotFoundException(string message, int id) : base(message)
        {
            Id = id;
        }
    }
}
