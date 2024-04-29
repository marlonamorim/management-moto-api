using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace MGM.Management.AppServices.ViewModel
{
    public class RentalPlanUserViewModel
    {
        [Required]
        [NotNull]
        public string RentalPlanId { get; set; } = string.Empty;

        [Required]
        [NotNull]
        public string MotoId { get; set; } = string.Empty;

        [Required]
        [NotNull]
        public DateTime ExpectedRentalEndDate { get; set; }
    }
}
