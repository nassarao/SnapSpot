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
using Microsoft.Azure.Mobile.Server;

namespace SnapSpotService.Controllers
{
    public class SnapSpotUserController : ApiController
    {
        private SnapSpotContext db = new SnapSpotContext();

        // GET api/SnapSpotUser
        public IQueryable<SnapSpotUser> GetSnapSpotUsers()
        {
            return db.SnapSpotUsers;
        }

        // GET api/SnapSpotUser/5
        [ResponseType(typeof(SnapSpotUser))]
        public async Task<IHttpActionResult> GetSnapSpotUser(int id)
        {
            SnapSpotUser snapspotuser = await db.SnapSpotUsers.FindAsync(id);
            if (snapspotuser == null)
            {
                return NotFound();
            }

            return Ok(snapspotuser);
        }

        // PUT api/SnapSpotUser/5
        public async Task<IHttpActionResult> PutSnapSpotUser(int id, SnapSpotUser snapspotuser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != snapspotuser.SnapSpotUserId)
            {
                return BadRequest();
            }

            db.Entry(snapspotuser).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SnapSpotUserExists(id))
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

        // POST api/SnapSpotUser
        [ResponseType(typeof(SnapSpotUser))]
        public async Task<IHttpActionResult> PostSnapSpotUser(SnapSpotUser snapspotuser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SnapSpotUsers.Add(snapspotuser);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = snapspotuser.SnapSpotUserId }, snapspotuser);
        }

        // DELETE api/SnapSpotUser/5
        [ResponseType(typeof(SnapSpotUser))]
        public async Task<IHttpActionResult> DeleteSnapSpotUser(int id)
        {
            SnapSpotUser snapspotuser = await db.SnapSpotUsers.FindAsync(id);
            if (snapspotuser == null)
            {
                return NotFound();
            }

            db.SnapSpotUsers.Remove(snapspotuser);
            await db.SaveChangesAsync();

            return Ok(snapspotuser);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SnapSpotUserExists(int id)
        {
            return db.SnapSpotUsers.Count(e => e.SnapSpotUserId == id) > 0;
        }
    }
}