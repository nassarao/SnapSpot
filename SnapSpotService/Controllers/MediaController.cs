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
    public class MediaController : ApiController
    {
        private SnapSpotContext db = new SnapSpotContext();

        // GET api/Media
        public IQueryable<Media> GetMedia()
        {
            return db.Media;
        }

        // GET api/Media/5
        [ResponseType(typeof(Media))]
        public async Task<IHttpActionResult> GetMedia(int id)
        {
            Media media = await db.Media.FindAsync(id);
            if (media == null)
            {
                return NotFound();
            }

            return Ok(media);
        }

        // PUT api/Media/5
        public async Task<IHttpActionResult> PutMedia(int id, Media media)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != media.MediaId)
            {
                return BadRequest();
            }

            db.Entry(media).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MediaExists(id))
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

        // POST api/Media
        [ResponseType(typeof(Media))]
        public async Task<IHttpActionResult> PostMedia(Media media)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Media.Add(media);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = media.MediaId }, media);
        }

        // DELETE api/Media/5
        [ResponseType(typeof(Media))]
        public async Task<IHttpActionResult> DeleteMedia(int id)
        {
            Media media = await db.Media.FindAsync(id);
            if (media == null)
            {
                return NotFound();
            }

            db.Media.Remove(media);
            await db.SaveChangesAsync();

            return Ok(media);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MediaExists(int id)
        {
            return db.Media.Count(e => e.MediaId == id) > 0;
        }
    }
}