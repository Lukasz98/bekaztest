using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WymianaKsiazek.Api.Database;
using WymianaKsiazek.Api.Models;
using System.Collections.Generic;
using AutoMapper;

namespace WymianaKsiazek.Api.Controllers
{
    [ApiController]
    public class BookController : BaseController
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        
        public BookController(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet("books/category/{id}")]
        [Route("/")]
        public ActionResult<List<BookMP>> GetCategoryOffers(long id)
        {
            var books = _context.Book.Where(x => x.CategoryId == id).ToList();
            return _mapper.Map<List<BookMP>>(books);
        }
        /* zakomentowalam bo ksiazka nie ma usera i wgl nie wiem czy to bedzie potrzebne
        [HttpGet("books")] 
        public async Task<IActionResult> Get()
        {
            var books = await _context.Books.Where(x => x.UserId == CurrentUserId).ToListAsync();

            if (books.Count == 0)
                return NotFound();

            return Ok(books);
        }

        [HttpPost("books")]
        public async Task<IActionResult> Add([FromBody] string name)
        {
            _context.Books.Add(new BookEntity() { Name = name, UserId = CurrentUserId });
            await _context.SaveChangesAsync();

            return Ok();
        }
        */
    }
}
