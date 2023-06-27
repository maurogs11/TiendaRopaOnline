using System.ComponentModel.DataAnnotations;

namespace TiendaRopaOnline.Web.Models
{
    public class ProductViewModel : ValidationAttribute
    {
        public int Id { get; set; }

        public string? Size { get; set; }

        public string? Color { get; set; }

        [RegularExpression(@"^(0|-?\d{0,15}(\.\d{0,2})?)$", ErrorMessage = "Put decimal value between 0.00 and 9999999999999.99")]
        public decimal? Price { get; set; }

        public string? Description { get; set; }

        public override bool IsValid(object? product)
        {
            if (product == null)
                return false;
            return true;
        }
    }
}
