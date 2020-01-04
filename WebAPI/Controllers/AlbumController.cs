using MVCMusicStore2019.Infrastructure;
using MVCMusicStore2019.Models.MusicStores;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace WebAPI.Controllers
{
    public class AlbumController : ApiController
    {
        MusicDbContext db = new MusicDbContext();
        // GET: Album
        //public ActionResult Index()
        //{
        //    return View();
        //}

           
        public IEnumerable<Album>GetAlbums()
        {
            return db.Albums;
        }
        public IHttpActionResult Get(Guid id)
        {
            Album entity = db.Albums.Find(id);
            if(entity!=null)
                {
                return Ok(entity);
            }
            else
            {
                return NotFound();
            }
        }
        public IHttpActionResult Post(Album entity)
        {
            if(ModelState.IsValid)
            {
                db.Albums.Add(entity);
                db.SaveChanges();
                var uri = new Uri(Url.Link("", new { id = entity.Id }));
                return Created(uri, entity);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        public IHttpActionResult Put(Guid id,Album entity)
        {
            if(ModelState.IsValid&&id==entity.Id)
            {
                db.Entry(entity).State = EntityState.Modified;
                try
                {
                    db.SaveChanges();
                }
                catch(DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return Ok(entity);
            }
            else
            {
                return NotFound();
            }
        }

        //DELETE api
        public IHttpActionResult Delete(Guid id)
        {
            Album entity = db.Albums.Find(id);
            if(entity!=null)
            {
                db.Albums.Remove(entity);
                try
                {
                    db.SaveChanges();
                }
                catch(DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return Ok(entity);
            }
            else
            {
                return NotFound();
            }
        }
    }
}