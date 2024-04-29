using MGM.Management.Domain.ValueObjects;
using MGM.Management.Moto.Entities;
using MGM.Management.Moto.Infrastructure.Api.ErrorHandling.HttpExceptions;
using System.Net;

namespace MGM.Management.Domain.Assertions
{
    public class MotoAssertion(IDefaultHttpClientErrorResponseHandler defaultHttpClientErrorResponseHandler) : IMotoAssertion
    {
        private readonly IDefaultHttpClientErrorResponseHandler _defaultHttpClientErrorResponseHandler = defaultHttpClientErrorResponseHandler;

        public void MotoNeedsToBeValid(MotoValueObject? valueObject)
        {
            if(valueObject is null)
                throw _defaultHttpClientErrorResponseHandler.ThrowResponseError(HttpStatusCode.BadRequest,
                    string.Empty,
                    "Valores informados para cadastro de moto não podem ser nulos ou vazios");
        }

        public void ThereMustBeNoMotoWhithLicensePlate(MotoEntity? moto, string licensePlate)
        {
            if(moto != null && moto.LicensePlate.Equals(licensePlate, StringComparison.CurrentCultureIgnoreCase))
                throw _defaultHttpClientErrorResponseHandler.ThrowResponseError(HttpStatusCode.BadRequest, 
                    string.Empty, 
                    $"Já existe cadastro de moto para a placa {licensePlate} informada.");
        }

        public void LicensePlateNeedsToBeFill(string? licensePlate)
        {
            if (string.IsNullOrEmpty(licensePlate))
                throw _defaultHttpClientErrorResponseHandler.ThrowResponseError(HttpStatusCode.BadRequest,
                    string.Empty,
                    "É preciso informar uma placa válida, valores nulos ou vazios não são permitidos.");
        }

        public void MotoEntityMustExists(MotoEntity? moto, string motoId)
        {
            if (moto != null && string.IsNullOrEmpty(moto.Id))
                throw _defaultHttpClientErrorResponseHandler.ThrowResponseError(HttpStatusCode.BadRequest,
                    string.Empty,
                    $"Não foi encontrada nenhuma moto para o identificador informado {motoId}.");
        }
    }
}
