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
        // GET api/values/5
        [HttpGet("{guid}")]
        public ActionResult<GuidModel> Get(string guid)
        {
            //DateTimeOffset.FromUnixTimeMilliseconds(1532159755).UtcDateTime;
            var model = new GuidModel();
            model.guid = "xyz";
            model.expire = 1532159755;
            model.user = "My biz";
            return model;
        }

        // POST api/values
        [HttpPost("{guid?}")]
        public ActionResult<GuidModel> PostGeneratedGuid([FromBody] JObject body, string guid="")
        {
            GuidModel posted = body.ToObject<GuidModel>();
            var model = new GuidModel();
            model.guid = "xyz";
            model.expire = 1532159755;
            model.user = "My biz";
            return model;
        }

        // PUT api/values/5
        [HttpPut("{guid}")]
        public ActionResult<GuidModel> Put(string guid, [FromBody] JObject body)
        {
            GuidModel posted = body.ToObject<GuidModel>();
            var model = new GuidModel();
            model.guid = "xyz";
            model.expire = 1532159755;
            model.user = "My biz";
            return model;
        }

        // DELETE api/values/5
        [HttpDelete("{guid}")]
        public void Delete(string guid)
        {
        }
    }
}
