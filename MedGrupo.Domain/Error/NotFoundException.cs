using System;

namespace MedGrupo.Domain.Error
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message):base(message)
        {

        }
    }
}
