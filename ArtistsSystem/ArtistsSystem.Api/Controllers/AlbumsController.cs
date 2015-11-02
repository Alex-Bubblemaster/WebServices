namespace ArtistsSystem.Api.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    public class AlbumsController : ApiController
    {
        // GET: api/Albums
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Albums/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Albums
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Albums/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Albums/5
        public void Delete(int id)
        {
        }
    }
}
