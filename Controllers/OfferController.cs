using AutoMapper;
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
using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Identity;

namespace WymianaKsiazek.Api.Controllers
{
    [ApiController]
    public class OfferController : BaseController
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        private readonly UserManager<UserEntity> _userManager;

        public OfferController(Context context, IMapper mapper, UserManager<UserEntity> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }

        /*[HttpPost("books")] //jeszcze niezrobiony
        public async Task<IActionResult> Add([FromBody] string content, long addressId, Boolean type, decimal price )
        {
            _context.Offer.Add(new OfferEntity { Content = content, AddressId=addressId, Type=type, Price=price,  UserId = CurrentUserId });
            await _context.SaveChangesAsync();
            return Ok();
        }*/
        [HttpGet("offers")]
        [Route("/")]
        public ActionResult<List<OfferMP>> GetAllOffers()
        {
            var offers = _context.Offer.ToList();
            return _mapper.Map<List<OfferMP>>(offers);
        }
        [HttpPost("books")]
        [Route("/")]
        [Authorize]
        public async Task<IActionResult> AddOffer([FromBody]OfferAdd off)
        {
            var checkbook = _context.Book.Where(x => x.Author == off.Book.Author && x.Title == off.Book.Title).FirstOrDefault();
            long id;
            //long addressid = _context.Address.Where(x => x.Name == off.Address).Select(x=>x.Id).FirstOrDefault();
            string userid = _userManager.GetUserId(HttpContext.User);
            if (checkbook == null)
            {
                var book = new BookEntity { Title = off.Book.Title, Author = off.Book.Author, CategoryId = off.Book.CategoryId, Isbn = off.Book.Isbn};
                _context.Book.Add(book);
                await _context.SaveChangesAsync();
                var book2 = _context.Book.Where(x => x.Author == off.Book.Author && x.Title == off.Book.Title).FirstOrDefault();
                id = book2.Id;
            }
            else
            {
                id = checkbook.Id;
            }
            var offer = new OfferEntity {Content = off.Content, Price = off.Price, BookId = id, Type = off.Type, AddressId = off.AddressId, UserId = userid};
            _context.Offer.Add(offer);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpGet("{id}")]
        [Route("/")]
        public ActionResult<OfferMP> offer(long id)
        {
            var offer = _context.Offer.Include(x => x.Book).ThenInclude(b => b.Category)
                .Include(x => x.User).Include(x => x.Address).Where(x => x.Id == id).FirstOrDefault();
            if(offer == null)
            {
                return NotFound();
            }
            return _mapper.Map<OfferMP>(offer);
        }
        [HttpGet("Profile/{id}")]
        [Route("/")]
        public ActionResult<UserMP> Profile(string id)
        {
            var user = _context.User.Include(x => x.Offers).Where(x => x.Id == id).FirstOrDefault();
            if (user == null)
            {
                return NotFound();
            }
            return _mapper.Map<UserMP>(user);
        }
        [HttpGet("offers/{addressname}")]
        [Route("/")]
        public ActionResult<List<OfferMP>> GetCityOffers(string address)
        {
            long addressid = _context.Address.Where(x => x.Name == address).Select(x => x.Id).FirstOrDefault();
            var offers = _context.Offer.Where(x => x.AddressId == addressid).ToList();
            return _mapper.Map<List<OfferMP>>(offers);
        }
        [HttpGet("offers/address/{id}")]
        [Route("/")]
        public ActionResult<List<OfferMP>> GetOffersFromCity(long id)
        {
            var offers = _context.Offer.Where(x => x.AddressId == id).ToList();
            return _mapper.Map<List<OfferMP>>(offers);
        }
        [HttpGet("offers/book/{id}")]
        [Route("/")]
        public ActionResult<List<OfferMP>> GetBookOffers(long id)
        {
            var offers = _context.Offer.Where(x => x.BookId == id).ToList();
            return _mapper.Map<List<OfferMP>>(offers);
        }

    }
}
