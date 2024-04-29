using MGM.Management.AppServices.Service.Persistence;
using MGM.Management.AppServices.ViewModel;
using MGM.Management.Moto.Infrastructure.Api.Filters;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace MGM.Management.Moto.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Gestão de usuários")]
    public class UserController(IUpsertUserAppService upsertUserAppService) : ControllerBase
    {
        private readonly IUpsertUserAppService _upsertUserAppService = upsertUserAppService;

        [HttpPost(Name = "UpsertUser")]
        [SwaggerOperation(Summary = "Cadastro e atualização de moto")]
        [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(void))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, Type = typeof(ForbidResult))]
        [ServiceFilter(typeof(ExceptionFilter))]
        public async Task<IActionResult> PostAsync([FromBody] UserViewModel model)
        {
            await _upsertUserAppService.UpsertAsync(model);
            return Created();
        }
    }
}
