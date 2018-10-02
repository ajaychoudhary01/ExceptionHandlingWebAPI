using AutoMapper;
using ExceptionHandlingWebAPI.Models;
using Newtonsoft.Json;
using StackExchange.StacMan;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ExceptionHandlingWebAPI.Repository
{
    public class StackServiceRepository : IStackServiceRepository
    {
        public async Task<IList<ExceptionHandlingWebAPI.Models.Tag>> GetTagsAsync()
        {
            var client = new StacManClient(version: "2.2");
            var response = await client.Tags.GetAll("stackoverflow");
            var tags = response.Data.Items.ToList();
            return Mapper.Map<IList<ExceptionHandlingWebAPI.Models.Tag>>(tags);
        }
    }
}