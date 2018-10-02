using ExceptionHandlingWebAPI.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandlingWebAPI.Core
{
    public interface ILogger
    {
        Task LogAsync(LogSchema data);

        Task LogAsync(string message, int eventId);
    }
}
