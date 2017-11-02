using MoodUp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MoodUp.APIControllers
{
    public class MoodController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
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

        [HttpGet]
        public string Get(string user, double mood)
        {
            Models.ApplicationDbContext applicationDbContext = new Models.ApplicationDbContext();
            var _user = applicationDbContext.Users.FirstOrDefault(e => e.Id == user);
            if (_user == null) throw new HttpResponseException(HttpStatusCode.NotFound);
            _user.Moods = new List<Moods>();
            _user.Moods.Add(new Models.Moods { mood = mood, timestamp = DateTime.Now });
            applicationDbContext.SaveChanges();


            return "Success";
        }
    }
}