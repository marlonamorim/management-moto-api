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
    [ApiExplorerSettings(GroupName = "Gestão de motos")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Bearer", Roles = "admin")]
    public class MotoController(IGetMotoAppService getMotoAppService,
        IUpsertMotoAppService upsertMotoAppService,
        IDeleteMotoAppService deleteMotoAppService) : ControllerBase
    {
        private readonly IGetMotoAppService _getMotoAppService = getMotoAppService;
        private readonly IUpsertMotoAppService _upsertMotoAppService = upsertMotoAppService;
        private readonly IDeleteMotoAppService _deleteMotoAppService = deleteMotoAppService;

        [HttpGet(Name = "ListAll")]
        [SwaggerOperation(Summary = "Lista de motos cadastradas")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<MotoViewModel>))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, Type = typeof(ForbidResult))]
        public async Task<IActionResult> ListAllAsync()
            => Ok(await _getMotoAppService.ListAllAsync());

        [HttpGet("{license-plate}", Name = "GetByLicensePlate")]
        [SwaggerOperation(Summary = "Busca de moto com filtro por placa")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(MotoViewModel))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, Type = typeof(ForbidResult))]
        [ServiceFilter(typeof(ExceptionFilter))]
        public async Task<IActionResult> GetByLicensePlateAsync([FromRoute(Name = "license-plate")] string licensePlate)
            => Ok(await _getMotoAppService.GetByLicensePlateAsync(licensePlate));

        [HttpPost(Name = "Upsert")]
        [SwaggerOperation(Summary = "Cadastro e atualização de moto")]
        [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(void))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, Type = typeof(ForbidResult))]
        [ServiceFilter(typeof(ExceptionFilter))]
        public async Task<IActionResult> PostAsync([FromBody] MotoViewModel model)
        {
            await _upsertMotoAppService.UpsertAsync(model);
            return Created();
        }

        [HttpDelete("{id}", Name = "Delete")]
        [SwaggerOperation(Summary = "Exclusão de moto por identificador")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(void))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, Type = typeof(ForbidResult))]
        [ServiceFilter(typeof(ExceptionFilter))]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            await _deleteMotoAppService.ExecuteAsync(new MotoViewModel { Id = id });
            return Ok();
        }
    }
}