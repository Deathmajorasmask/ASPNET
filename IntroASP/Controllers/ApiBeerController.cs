using IntroASP.Models;
using IntroASP.Models.View_Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntroASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // Trae de un JSON la información y la pone en una lista, para ser ejecutada por el front
    public class ApiBeerController : ControllerBase
    {
        private readonly PubContext _context;
        public ApiBeerController(PubContext context)
        {
            _context = context;
        }

        // Trae el Json de https://localhost:7035/api/ApiBeer atraves del modelo creado BeerBrandViewModel
        public async Task<List<BeerBrandViewModel>> Get()
            // Traer una referencia ciclica, que al mandarlo a llamar, este manda a llamar a si mismo A->B->A
            => await _context.Beers.Include(b=>b.Brand)
                .Select(b=>new BeerBrandViewModel
                {
                    Name = b.Name,
                    Brand = b.Brand.Name
                })
                .ToListAsync();
    }
}
