using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WymianaKsiazek.Api.Database;

namespace WymianaKsiazek.Api.Controllers
{
    //[Authorize] 
    [ApiController]
    [Route("")]
    public class AddressController : BaseController
    {
        private readonly Context _context;

        public AddressController(Context context)
        {
            _context = context;
        }

        [HttpGet("address/{address}")]  //returns list of addresses starting at given string
        public async Task<IActionResult> Get(string address)
        {
     

            var adreses = await _context.Address.Where(x => x.Name.StartsWith(address)).ToListAsync();

            if (adreses.Count == 0)
                return NotFound();

            return Ok(adreses);

        }

    }

   
}
