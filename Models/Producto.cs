using System.ComponentModel.DataAnnotations;

namespace GestionFarma.Models
{
    public class Producto
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(20, ErrorMessage = "El nombre no puede exceder los 20 caracteres")]
        [Display(Name = "Nombre del Producto")]
        public string Name { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        [StringLength(100, ErrorMessage = "La descripción no puede exceder los 100 caracteres")]
        [Display(Name = "Descripción del Producto")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que cero")]
        [Display(Name = "Precio del Producto")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "La fecha de caducidad es obligatoria")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Caducidad")]
        public DateTime ExpirationDate { get; set; }
    }
}
