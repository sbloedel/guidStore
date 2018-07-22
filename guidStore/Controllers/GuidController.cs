using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using guidStore.Data;
using guidStore.Data.Models;
using guidStore.Utils;
using Microsoft.EntityFrameworkCore;

namespace guidStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuidController : ControllerBase
    {
        private GuidDbContext _context;

        // GET api/values/5
        [HttpGet("{guid}")]
        public ActionResult<GuidModel> Get(string guid)
        {
            try
            {
                using (var context = _context ?? new GuidDbContext()) 
                {
                    var record = context.guids.SingleOrDefault(x => x.guid == guid);
                    if (record == null)
                    {
                        this.HttpContext.Response.StatusCode = 404;
                        return NotFound("Guid not found");
                    }
                    if (DateTimeUtils.EpochToDateTime(record.expire) <= DateTime.UtcNow)
                    {
                        this.HttpContext.Response.StatusCode = 400;
                        return BadRequest("Guid has expired");
                    }

                    return record;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                this.HttpContext.Response.StatusCode = 500;
                return null;
            }
        }

        // POST api/values
        [HttpPost("{guid?}")]
        public ActionResult<GuidModel> Post([FromBody] JObject body, string guid="")
        {
            //deserialize body and fill in a default guid and expiration date if necessary
            GuidModel posted = body.ToObject<GuidModel>();
            if (String.IsNullOrWhiteSpace(guid))
            {
                guid = Guid.NewGuid().ToString();
            }
            if (posted.expire == 0) {
                posted.expire = DateTimeUtils.DateTimeToEpoch(DateTime.UtcNow.AddDays(30));
            }

            posted.guid = guid.Replace("-", "");  //remove dashes

            try
            {
                using (var context = _context ?? new GuidDbContext()) 
                {
                    //check to see if guid exists
                    if (context.guids.FirstOrDefault(x => x.guid == posted.guid) != null)
                    {
                        this.HttpContext.Response.StatusCode = 409;
                        return BadRequest("Guid already exists");
                    }

                    context.guids.Add(posted);
                    context.SaveChanges();
                    return posted;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                this.HttpContext.Response.StatusCode = 500;
                return null;
            }
        }

        // PUT api/values/5
        [HttpPut("{guid}")]
        public ActionResult<GuidModel> Put(string guid, [FromBody] JObject body)
        {
            //deserialize body and validate guid and date
            GuidModel posted = body.ToObject<GuidModel>();
            if (String.IsNullOrWhiteSpace(guid))
            {
                this.HttpContext.Response.StatusCode = 400;
                return BadRequest("Invalid guid");
            }
            if (posted.expire == 0) {
                this.HttpContext.Response.StatusCode = 400;
                return BadRequest("Invalid expire value");
            }

            guid = guid.Replace("-", "");  //remove dashes

            try {
                using (var context = _context ?? new GuidDbContext()) 
                {
                    var valToUpdate = context.guids.FirstOrDefault(x => x.guid == guid);
                    if (valToUpdate == null)
                    {
                        this.HttpContext.Response.StatusCode = 400;
                        return BadRequest("Guid not found");
                    }

                    valToUpdate.expire = posted.expire;  //we're only updating the expiration date
                    context.SaveChanges();
                    return valToUpdate;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                this.HttpContext.Response.StatusCode = 500;
                return null;
            }
        }

        // DELETE api/values/5
        [HttpDelete("{guid}")]
        public ActionResult<GuidModel> Delete(string guid)
        {
            if (String.IsNullOrWhiteSpace(guid))
            {
                this.HttpContext.Response.StatusCode = 400;
                return BadRequest("Invalid guid");
            }

            guid = guid.Replace("-", "");  //remove dashes

            try {
                using (var context = _context ?? new GuidDbContext()) 
                {
                    var valToDelete = context.guids.FirstOrDefault(x => x.guid == guid);
                    if (valToDelete == null)
                    {
                        this.HttpContext.Response.StatusCode = 400;
                        return BadRequest("Guid not found");
                    }

                    context.Entry(valToDelete).State = EntityState.Deleted;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                this.HttpContext.Response.StatusCode = 500;
            }

            return null;
        }
    }
}
