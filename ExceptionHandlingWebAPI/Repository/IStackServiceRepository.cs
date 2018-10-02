using ExceptionHandlingWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandlingWebAPI.Repository
{
    public interface IStackServiceRepository
    {
        Task<IList<Tag>> GetTagsAsync();
    }
}
