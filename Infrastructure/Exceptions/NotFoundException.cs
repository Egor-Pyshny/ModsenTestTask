using Domain.Exceptions;

namespace Infrastructure.Exceptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException(string message) : base(message) { }
    }
}
