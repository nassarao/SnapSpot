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
    public class SpotController : ApiController
    {
        private SnapSpotContext db = new SnapSpotContext();

        // GET api/Spot
        public IQueryable<Spot> GetSpots()
        {
            return db.Spots;
        }

        // GET api/Spot/5
        [ResponseType(typeof(Spot))]
        public async Task<IHttpActionResult> GetSpot(int id)
        {
            Spot spot = await db.Spots.FindAsync(id);
            if (spot == null)
            {
                return NotFound();
            }

            return Ok(spot);
        }

        // PUT api/Spot/5
        public async Task<IHttpActionResult> PutSpot(int id, Spot spot)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != spot.SpotId)
            {
                return BadRequest();
            }

            db.Entry(spot).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpotExists(id))
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

        // POST api/Spot
        [ResponseType(typeof(Spot))]
        public async Task<IHttpActionResult> PostSpot(Spot spot)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Spots.Add(spot);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = spot.SpotId }, spot);
        }

        // DELETE api/Spot/5
        [ResponseType(typeof(Spot))]
        public async Task<IHttpActionResult> DeleteSpot(int id)
        {
            Spot spot = await db.Spots.FindAsync(id);
            if (spot == null)
            {
                return NotFound();
            }

            db.Spots.Remove(spot);
            await db.SaveChangesAsync();

            return Ok(spot);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SpotExists(int id)
        {
            return db.Spots.Count(e => e.SpotId == id) > 0;
        }
    }
}