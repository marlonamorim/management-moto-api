using MGM.Management.Moto.Entities;
using MGM.Management.Moto.Infrastructure.Api.ErrorHandling.HttpExceptions;
using System.Net;

namespace MGM.Management.Domain.Assertions
{
    public class RentalPlanUserAssertion(IDefaultHttpClientErrorResponseHandler defaultHttpClientErrorResponseHandler) : IRentalPlanUserAssertion
    {
        private readonly IDefaultHttpClientErrorResponseHandler _defaultHttpClientErrorResponseHandler = defaultHttpClientErrorResponseHandler;
        
        public void ThereMustBeUserId(string? userId)
        {
            if(string.IsNullOrEmpty(userId))
                throw _defaultHttpClientErrorResponseHandler.ThrowResponseError(HttpStatusCode.BadRequest,
                    string.Empty,
                    $"Sistema não conseguiu identificar usuário logado. Favor realizar autenticação novamente.");
        }

        public void UserThereMustBeCnhCategory(UserEntity user, ICollection<string> cnhCategories)
        {
            if (!cnhCategories.Contains(user.CnhCategory))
                throw _defaultHttpClientErrorResponseHandler.ThrowResponseError(HttpStatusCode.BadRequest,
                    string.Empty,
                    $"Não é permitido realizar a locação, pois a categoria da CNH do usuário é {user.CnhCategory}.");
        }

        public void ThereMustBeRentalPlan(RentalPlanEntity? rentalPlan, string rentalPlanId)
        {
            if (rentalPlan is null)
                throw _defaultHttpClientErrorResponseHandler.ThrowResponseError(HttpStatusCode.BadRequest,
                    string.Empty,
                    $"Sistema não conseguiu identificar plano de locação disponível com o identificador {rentalPlanId}.");
        }
    }
}
