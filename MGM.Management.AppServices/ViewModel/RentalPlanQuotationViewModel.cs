using System.Text.Json.Serialization;

namespace MGM.Management.AppServices.ViewModel
{
    public class RentalPlanQuotationViewModel
    {
        [JsonPropertyName("ValorTotal")]
        public decimal TotalCost { get; set; }

        [JsonPropertyName("ValorTotalAdicionalComMulta")]
        public decimal AdditionalTotalCost { get; set; }

        [JsonPropertyName("TaxaMultaEmValorMonetario")]
        public decimal FineRateAppliedInMonetaryValue { get; set; }

        [JsonPropertyName("TaxaMultaEmPorcentagem")]
        public decimal FineRateAppliedInPercentage { get; set; }
    }
}
