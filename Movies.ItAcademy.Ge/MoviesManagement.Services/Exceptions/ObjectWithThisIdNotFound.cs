using System;

namespace MoviesManagement.Services.Exceptions
{
    public class ObjectWithThisIdNotFound : Exception
    {
        public string Code = "Object With This Id Not Found";
        public ObjectWithThisIdNotFound(string mes) : base(mes)
        {

        }
    }
}
