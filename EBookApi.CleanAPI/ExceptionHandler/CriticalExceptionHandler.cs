using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EBookApi.Domain.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

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
