using System.ComponentModel.DataAnnotations;

namespace IntroASP.Models.View_Models
{
    public class BeerViewModel
    {
        [Required]
        // Cuando se muestre el Name, se mostrara como Nombre (Solo es visual)
        [Display(Name = "Nombre")]
        public string Name { get; set; }
        
        [Required]
        // Cuando se muestre BrandId se cambiara por Marca (Solo es visual)
        [Display(Name = "Marca")]
        public int BrandId { get; set; }


    }
}
