using IntroASP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace IntroASP.Controllers
{
    public class BrandController : Controller
    {
        // Inyección de dependencias como en otros framework que trae los objetos de la BD
        // desde el archivo Models > PubContext
        private readonly PubContext _context;
        public BrandController(PubContext context)
        {
            _context = context;
        }

        // Enviar de forma independiente
        public async Task<IActionResult> Index()
        {
            
            // Envia un modelo, que es solo un molde con información
            // Espera la tabla Brands y la envia en forma de lista (Agregar biblioteca EntityFrameworkCore)
            // A la View de Brand
            return View(await _context.Brands.ToListAsync());
        }

    }
}

// 22:36