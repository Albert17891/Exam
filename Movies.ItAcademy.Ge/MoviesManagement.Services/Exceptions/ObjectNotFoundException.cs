using System;

namespace MoviesManagement.Services.Exceptions
{
    public class ObjectNotFoundException : Exception
    {
        public string Code = "Object Not Found";
        public ObjectNotFoundException(string mes) : base(mes)
        {

        }
    }
}
