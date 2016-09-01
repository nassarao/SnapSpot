using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using SnapSpotService.DataObjects;
using SnapSpotService.Models;

namespace SnapSpotService.Controllers
{
    public class Spot_MediaController : ApiController
    {
        private SnapSpotContext db = new SnapSpotContext();

        // GET api/Spot_Media
        public IQueryable<Spot_Media> GetSpot_Media()
        {
            return db.Spot_Media;
        }

        // GET api/Spot_Media/5
        [ResponseType(typeof(Spot_Media))]
        public async Task<IHttpActionResult> GetSpot_Media(int id)
        {
            Spot_Media spot_media = await db.Spot_Media.FindAsync(id);
            if (spot_media == null)
            {
                return NotFound();
            }

            return Ok(spot_media);
        }

        // PUT api/Spot_Media/5
        public async Task<IHttpActionResult> PutSpot_Media(int id, Spot_Media spot_media)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != spot_media.Spot_MediaId)
            {
                return BadRequest();
            }

            db.Entry(spot_media).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Spot_MediaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Spot_Media
        [ResponseType(typeof(Spot_Media))]
        public async Task<IHttpActionResult> PostSpot_Media(Spot_Media spot_media)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Spot_Media.Add(spot_media);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = spot_media.Spot_MediaId }, spot_media);
        }

        // DELETE api/Spot_Media/5
        [ResponseType(typeof(Spot_Media))]
        public async Task<IHttpActionResult> DeleteSpot_Media(int id)
        {
            Spot_Media spot_media = await db.Spot_Media.FindAsync(id);
            if (spot_media == null)
            {
                return NotFound();
            }

            db.Spot_Media.Remove(spot_media);
            await db.SaveChangesAsync();

            return Ok(spot_media);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Spot_MediaExists(int id)
        {
            return db.Spot_Media.Count(e => e.Spot_MediaId == id) > 0;
        }
    }
}