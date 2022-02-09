using System;

namespace CarApi.Infastructure.MyException
{
    public class NotFoundException:Exception
    {
        public NotFoundException(string mes) : base(mes)
        {

        }
    }
}
