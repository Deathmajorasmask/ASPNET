using IntroASP.Models;
using IntroASP.Models.View_Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace IntroASP.Controllers
{
    public class BeerController : Controller
    {
        private readonly PubContext _context;

        public BeerController(PubContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {

            // De la tabla Beers les incluye la marca Brand
            // El Include es importante para que se relacionen las dos tablas de datos
            var beers = _context.Beers.Include(b=>b.Brand);

            // Regresa a la vista una lista de forma Async
            return View(await beers.ToListAsync());
        }

        // La ruta seria de https://localhost:7035/Beer/Create que regresa a la vista
        // No ocupamos nada de la BD ni traer información, no es necesario el Asincrono
        public IActionResult Create()
        {
            // Crear un diccionario que podemos consultar desde la vista (using Microsoft.AspNetCore.Mvc.Rendering)
            // Es como un Combo box, que muestra los nombres de la marca, pero en realidad estas seleccionando el BrandId
            ViewData["Brands"] = new SelectList(_context.Brands, "BrandId", "Name");
            return View();
        }

        // Esta etiqueta es para decirle que solo funcionan estas funciones cuando hago viene de un Post
        [HttpPost]
        // Esta etiqueta evita información de afuera, solo de nuestro formulario
        [AutoValidateAntiforgeryToken]

        // Función que usamos para atrapar los datos del formulario de la View al hacer Post
        public async Task<IActionResult> Create(BeerViewModel model)
        {
            // Valida si el modelo de BeerViewModel con las etiquetas [Requiered] tienen información correcta
            if (ModelState.IsValid)
            {
                var beer = new Beer()
                {
                    Name = model.Name,
                    BrandId = model.BrandId
                };
                _context.Beers.Add(beer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Brands"] = new SelectList(_context.Brands, "BrandId", "Name", model.BrandId);
            return View(model);
        }
    }
}
