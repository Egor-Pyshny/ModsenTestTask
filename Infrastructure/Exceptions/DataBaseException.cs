using Domain.Exceptions;

namespace Infrastructure.Exceptions
{
    public class DataBaseException : BaseException
    {
        public DataBaseException(string message) : base(message) { }
    }
}
