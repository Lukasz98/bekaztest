using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WymianaKsiazek.Api.Database;
using WymianaKsiazek.Api.Database.Entities;
using WymianaKsiazek.Api.Models;

namespace WymianaKsiazek.Api.Controllers
{
    //[Authorize] for logged in only users
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : BaseController
    {
        private readonly Context _context;

        public OfferController(Context context)
        {
            _context = context;
        }

        [HttpPost("addoffers")] 
        public async Task<IActionResult> AddOffer([FromBody] CreateOfferInput model)
        {
            Console.WriteLine("tu");
            return await CreateOffer(model);
        }

        [HttpGet("categories")] //returns list of categories
        public async Task<IActionResult> Get()
        {
            var categories = await _context.Category.ToListAsync();

            if (categories.Count == 0)
                return NotFound();

            return Ok(categories);
        }

        [HttpGet("offers/{name}")] //returns ids of offer suitable (only by name) to searched
        public async Task<IActionResult> Get(string name)
        {
           
           
            var books = await _context.Book.Where(x => x.Title.StartsWith(name)).ToListAsync();

            if (books.Count == 0)
                return NotFound();

            return Ok(books);

         
        }
      
        private async Task<IActionResult> CreateOffer(CreateOfferInput model)
        {
            
                OfferEntity offer = new OfferEntity();
                BookEntity siazka = new BookEntity();

                offer.Content = model.Content;    
                offer.AddressId = model.AddressId;
                offer.Price = model.Price;
                offer.Type = model.Type;
                offer.UserId = CurrentUserId;

            siazka.Author = model.Author;
            siazka.Title = model.Title;
            siazka.CategoryId = model.CategoryId;


            var record = _context.Book.FirstOrDefault(x => x.Title == model.Title && x.Author == model.Author);

            if (record == null)
            {
                _context.Book.Add(siazka);
                await _context.SaveChangesAsync();
                record = _context.Book.FirstOrDefault(x => x.Title == model.Title);
            }

            offer.BookId = record.Id;
            _context.Offer.Add(offer);
            await _context.SaveChangesAsync();
            

            return Ok();
        }
    }
}
