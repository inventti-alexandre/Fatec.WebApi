using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fatec.SharedKernel.Excecoes
{
    [Serializable]
    public class FieldsValidationException : Exception
    {
        public int Id { get; private set; }

        public FieldsValidationException()
        {
        }

        public FieldsValidationException(int id)
        {
            Id = id;
        }

        public FieldsValidationException(string message, int id) : base(message)
        {
            Id = id;
        }
    }
}
