using ExceptionHandlingWebAPI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ExceptionHandlingWebAPI.Core
{
    public class ExceptionLogger : ILogger
    {
        public Task LogAsync(Core.Data.LogSchema data)
        {
            return Task.FromResult(0);
        }

        public Task LogAsync(string message, int eventId)
        {
            return Task.FromResult(0);
        }
    }
}