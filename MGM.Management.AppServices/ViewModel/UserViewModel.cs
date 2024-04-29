using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace MGM.Management.AppServices.ViewModel
{
    public class UserViewModel
    {
        public string? Id { get; set; }

        [Required]
        [NotNull]
        public string Name { get; set; } = string.Empty;

        [Required]
        [NotNull]
        public string Login { get; set; } = string.Empty;

        [Required]
        [NotNull]
        public string Password { get; set; } = string.Empty;

        public DateTime BirthDate { get; set; }

        public string Cnh { get; set; } = string.Empty;

        public CnhCategory CnhCategory { get; set; }

        public string CnhImageBase64 { get; set; } = string.Empty;

        [JsonIgnore]
        public string CnhFileName { get; set; } = string.Empty;

        [Required]
        [NotNull]
        public string Cnpj { get; set; } = string.Empty;

        public UserType UserType { get; set; }
    }
}
