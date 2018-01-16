using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Music_Store.Models;
using System.Data.Entity;
namespace Music_Store.Controllers.API
{
    [Authorize]
    [RoutePrefix("api/ShoppingCart")]
    public class ShoppingCartController : ApiController
    {
        ApplicationDbContext db;
        public ShoppingCartController()
        {
            db = new ApplicationDbContext();
        }

        [Route("GetShopping")]
        public IHttpActionResult GetCart(string CartId)
        {
            var cart = db.carts
                .Include(c=> c.Album)
                .Where(c => c.CartId == CartId)
                .ToList();
            return Ok(cart);
        }


       [Route("AddToCart")]
       [HttpGet]
        public IHttpActionResult AddToCart(int AlbumId, string CartId)
        {
            
            var cartItem = db.carts.SingleOrDefault(c => c.AlbumId == AlbumId 
                && c.CartId == CartId);

            if (cartItem == null)
            {
                Cart cart = new Cart
                {
                    AlbumId = AlbumId,
                    DateCreated = DateTime.Today,
                    CartId = CartId,
                    Count = 1
                };
                db.carts.Add(cart);
            }
            else
            {
                cartItem.Count++;
            }

            db.SaveChanges();


            return Ok();


        }



       [Route("RemoveFromCart")]
       [HttpGet]
       public IHttpActionResult RemoveFromCart (int AlbumId, string CartId)
       {

           var cartItem = db.carts.SingleOrDefault(c => c.AlbumId == AlbumId
               && c.CartId == CartId);
           int count = 0;

           if (cartItem != null)
           {
               if (cartItem.Count <= 1)
               {
                   db.carts.Remove(cartItem);

               }
               else
               {
                   cartItem.Count--;
                   count = cartItem.Count;
               }

               db.SaveChanges();
           }

          


           return Ok(count);


       }

       [Route("Total")]
       [HttpGet]
       public IHttpActionResult Total(string CartId)
       {
           decimal? total = (from cartItem in db.carts
                        where cartItem.CartId == CartId
                        select (int?)cartItem.Count * cartItem.Album.Price).Sum();

           return Ok(total ?? decimal.Zero);

                       
       }


       [Route("Count")]
       [HttpGet]
       public IHttpActionResult CartCount(string CartId)
       {
           int? Count = (from cartItem in db.carts
                             where cartItem.CartId == CartId
                             select (int?)cartItem.Count).Sum();

           return Ok(Count ?? decimal.Zero);


       }
    }
}
