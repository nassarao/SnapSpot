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
    public class Spot_UserController : ApiController
    {
        private SnapSpotContext db = new SnapSpotContext();

        // GET api/Spot_User
        public IQueryable<Spot_User> GetSpot_User()
        {
            return db.Spot_User;
        }

        // GET api/Spot_User/5
        [ResponseType(typeof(Spot_User))]
        public async Task<IHttpActionResult> GetSpot_User(int id)
        {
            Spot_User spot_user = await db.Spot_User.FindAsync(id);
            if (spot_user == null)
            {
                return NotFound();
            }

            return Ok(spot_user);
        }

        // PUT api/Spot_User/5
        public async Task<IHttpActionResult> PutSpot_User(int id, Spot_User spot_user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != spot_user.Spot_UserId)
            {
                return BadRequest();
            }

            db.Entry(spot_user).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Spot_UserExists(id))
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

        // POST api/Spot_User
        [ResponseType(typeof(Spot_User))]
        public async Task<IHttpActionResult> PostSpot_User(Spot_User spot_user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Spot_User.Add(spot_user);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = spot_user.Spot_UserId }, spot_user);
        }

        // DELETE api/Spot_User/5
        [ResponseType(typeof(Spot_User))]
        public async Task<IHttpActionResult> DeleteSpot_User(int id)
        {
            Spot_User spot_user = await db.Spot_User.FindAsync(id);
            if (spot_user == null)
            {
                return NotFound();
            }

            db.Spot_User.Remove(spot_user);
            await db.SaveChangesAsync();

            return Ok(spot_user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Spot_UserExists(int id)
        {
            return db.Spot_User.Count(e => e.Spot_UserId == id) > 0;
        }
    }
}