using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MoodUp.APIControllers
{
    public class LoginController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(string email)
        {
            //return "value";
            Models.ApplicationDbContext applicationDbContext = new Models.ApplicationDbContext();
            var user = applicationDbContext.Users.FirstOrDefault(e => e.Email == email);
            if (user == null) throw new HttpResponseException(HttpStatusCode.NotFound);
            return user.Id;
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}