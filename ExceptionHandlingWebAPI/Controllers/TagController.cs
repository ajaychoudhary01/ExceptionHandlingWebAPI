using ExceptionHandlingWebAPI.Models;
using ExceptionHandlingWebAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ExceptionHandlingWebAPI.Controllers
{
    public class TagController : ApiController
    {
        private readonly IStackServiceRepository stateServiceRepository;

        public TagController()
        {
            //Use IOC here
            this.stateServiceRepository = new StackServiceRepository();
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetTagsAsync()
        {
            var states = await stateServiceRepository.GetTagsAsync();
            return Ok(states);
        }

        [HttpPost]
        // POST api/home
        public void PostAsync([FromBody]Tag state)
        {
            throw new SystemException("This method is not implemented to test Global Exception Handler");
        }
                
        [HttpPut]
        // PUT api/home/5
        public void PutAsync(int id, [FromBody]Tag state)
        {
            throw new SystemException("This method is not implemented to test Global Exception Handler");
        }

        [Route("states")]
        [HttpDelete]
        // DELETE api/home/5
        public void DeleteAsync(int id)
        {
            throw new NotImplementedException("This method is not implemented to test Global Exception Handler");
        }
    }
}
