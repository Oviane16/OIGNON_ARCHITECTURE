using System.ComponentModel.DataAnnotations;

namespace PRODUCT.UI.Models.Product
{
    public class CreateProductModel
    {
        [Required(ErrorMessage = "Le nom est requis")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Le matricule est requis")]
        public string Matricule { get; set; }
        [Required(ErrorMessage = "Le slug est requis")]
        public string Slug { get; set; }
    }
}
