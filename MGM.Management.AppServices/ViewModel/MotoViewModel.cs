using System.ComponentModel.DataAnnotations;

namespace MGM.Management.AppServices.ViewModel
{
    public class MotoViewModel
    {
        public string? Id { get; set; }

        [Required]
        public string LicensePlate { get; set; } = string.Empty;

        [Required]
        public Brand Brand { get; set; }

        [Required]
        [Range(minimum: 2014, maximum: 2024, ErrorMessage = "Informe um ano de fabrição válido entre os anos de 2014 e 2024")]
        public int ManufactureYear { get; set; }
    }
}
