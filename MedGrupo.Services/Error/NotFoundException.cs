using System;

namespace MedGrupo.Services.Error
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message):base(message)
        {

        }
    }
}
