using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Music_Store.Models;
using System.Data.Entity;
namespace Music_Store.Controllers
{
    public class StoreController : ApiController
    {
        private ApplicationDbContext db;

        public StoreController()
        {
            db = new ApplicationDbContext();
        }

        public IHttpActionResult GetStore()
        {
            var genre = db.genres.ToList();
            return Ok(genre);
        }

        public IHttpActionResult GetStore(string Name)
        {
            var genre = db.genres.Include("Albums")
                .Single(g => g.Name == Name);

            return Ok(genre);
        }


        public IHttpActionResult GetStore(int? id)
        {
            var album = db.albums
                .Include(a=> a.Artist)
                .SingleOrDefault(a => a.AlbumId == id);

            return Ok(album);
        }
    }
}
