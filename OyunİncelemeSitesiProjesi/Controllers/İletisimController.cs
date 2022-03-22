using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using OyunİncelemeSitesiProjesi.DAL;
using OyunİncelemeSitesiProjesi.Models;

namespace OyunİncelemeSitesiProjesi.Controllers
{
    public class İletisimController : ApiController
    {
        private OyunContext db = new OyunContext();

        // GET: api/İletisim
        public IQueryable<İletisim> Getİletisimler()
        {
            return db.İletisimler;
        }

        // GET: api/İletisim/5
        [ResponseType(typeof(İletisim))]
        public IHttpActionResult Getİletisim(int id)
        {
            İletisim İletisim = db.İletisimler.Find(id);
            if (İletisim == null)
            {
                return NotFound();
            }

            return Ok(İletisim);
        }

        // PUT: api/İletisim/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putİletisim(int id, İletisim İletisim)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != İletisim.MesajID)
            {
                return BadRequest();
            }

            db.Entry(İletisim).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!İletisimExists(id))
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

        // POST: api/İletisim
        [ResponseType(typeof(İletisim))]
        public IHttpActionResult Postİletisim(İletisim İletisim)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.İletisimler.Add(İletisim);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = İletisim.MesajID }, İletisim);
        }

        // DELETE: api/İletisim/5
        [ResponseType(typeof(İletisim))]
        public IHttpActionResult Deleteİletisim(int id)
        {
            İletisim İletisim = db.İletisimler.Find(id);
            if (İletisim == null)
            {
                return NotFound();
            }

            db.İletisimler.Remove(İletisim);
            db.SaveChanges();

            return Ok(İletisim);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool İletisimExists(int id)
        {
            return db.İletisimler.Count(e => e.MesajID == id) > 0;
        }
    }
}