using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace guidStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuidController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public ActionResult<GuidModel> PostGuid([FromBody] JObject body)
        {
            GuidModel posted = body.ToObject<GuidModel>();
            var model = new GuidModel();
            model.guid = "xyz";
            model.expire = "oh my";
            model.user = "My biz";
            return model;
        }

        // POST api/values
        [HttpPost("{guid}")]
        public ActionResult<GuidModel> PostGeneratedGuid(string guid, [FromBody] JObject body)
        {
            GuidModel posted = body.ToObject<GuidModel>();
            var model = new GuidModel();
            model.guid = "xyz";
            model.expire = "oh my";
            model.user = "My biz";
            return model;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
