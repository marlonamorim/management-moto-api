using MGM.Management.AppServices.Service.Persistence;
using MGM.Management.AppServices.Service.Search;
using MGM.Management.AppServices.ViewModel;
using MGM.Management.Moto.Infrastructure.Api.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace MGM.Management.Moto.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Gestão de locação")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Bearer", Roles = "entregador")]
    public class RentalPlanController(IGetRentalPlanAppService getRentalPlanAppService,
        ICreateRentalPlanUserAppService createRentalPlanUserAppService,
        IGetQuotationRentalPlanAppService getQuotationRentalPlanAppService) : ControllerBase
    {
        private readonly IGetRentalPlanAppService _getRentalPlanAppService = getRentalPlanAppService;
        private readonly ICreateRentalPlanUserAppService _createRentalPlanUserAppService = createRentalPlanUserAppService;
        private readonly IGetQuotationRentalPlanAppService _getQuotationRentalPlanAppService = getQuotationRentalPlanAppService;

        [HttpGet(Name = "ListAllRentalPlan")]
        [SwaggerOperation(Summary = "Lista de planos de locação de moto")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<RentalPlanViewModel>))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, Type = typeof(ForbidResult))]
        public async Task<IActionResult> ListAllAsync()
            => Ok(await _getRentalPlanAppService.ListAllAsync());

        [HttpGet("quotation", Name = "QuotationRentalPlanUser")]
        [SwaggerOperation(Summary = "Gera cotação de aluguel de moto plano selecionado e previsão de data de entrega")]
        [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(RentalPlanQuotationViewModel))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, Type = typeof(ForbidResult))]
        [ServiceFilter(typeof(ExceptionFilter))]
        public async Task<IActionResult> GetByExpectedRentalEndDateByRentalPlanIdAsync(
            [FromQuery] DateTime expectedRentalEndDate,
            [FromQuery] string rentalPlanId)
            => Ok(await _getQuotationRentalPlanAppService.GetByExpectedRentalEndDateByRentalPlanIdAsync(
                expectedRentalEndDate,
                rentalPlanId));

        [HttpPost(Name = "CreateRentalPlanUser")]
        [SwaggerOperation(Summary = "Aluguel de moto por usuário logado")]
        [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(void))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, Type = typeof(ForbidResult))]
        [ServiceFilter(typeof(ExceptionFilter))]
        public async Task<IActionResult> PostAsync([FromBody] RentalPlanUserViewModel model)
        {
            await _createRentalPlanUserAppService.CreateAsync(model);
            return Created();
        }
    }
}
