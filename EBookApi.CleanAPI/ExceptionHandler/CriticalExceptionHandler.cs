using EBookApi.Domain.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace EBookApi.CleanAPI.ExceptionHandler
{
    public class CriticalExceptionHandler : IExceptionHandler
    {
        public ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is CriticalException)
            {
                Console.WriteLine("Hata");
            }
            return ValueTask.FromResult(false);
        }
    }
}
