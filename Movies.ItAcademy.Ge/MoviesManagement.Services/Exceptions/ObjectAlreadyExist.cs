using System;

namespace MoviesManagement.Services.Exceptions
{
    public class ObjectAlreadyExist : Exception
    {
        public string Code = "Object Already Exist ";
        public ObjectAlreadyExist(string mes) : base(mes)
        {

        }
    }
}
