using MGM.Management.Moto.Entities;
using MGM.Management.Moto.Infrastructure.Api.ErrorHandling.HttpExceptions;
using Moq;
using System.Net;

namespace MGM.Management.Moto.Domain.UnitTests.Assertions
{
    public class MotoAssertion
    {
        private const string MOTO_IS_NOT_VALID_EXCEPTION_BADREQUEST_MESSAGE = "Valores informados para cadastro de moto não podem ser nulos ou vazios";
        private const string MOTOCYCLE_WITH_SAME_LICENSE_PLATE_EXCEPTION_BADREQUEST_MESSAGE = "Já existe cadastro de moto para a placa {0} informada.";
        private const string LICENSE_PLATE_NULL_OR_EMPTY_EXCEPTION_BADREQUEST_MESSAGE = "É preciso informar uma placa válida, valores nulos ou vazios não são permitidos.";
        private const string MOTO_NOT_NULL_AND_ID_NULL_OR_EMPTY_EXCEPTION_BADREQUEST_MESSAGE = "Não foi encontrada nenhuma moto para o identificador informado {0}.";
        private readonly Mock<IDefaultHttpClientErrorResponseHandler> _defaultHttpClientErrorResponseHandler;
        private readonly Management.Domain.Assertions.MotoAssertion _motoAssertion;
        private readonly MotoEntity _entity;

        public MotoAssertion()
        {
            _defaultHttpClientErrorResponseHandler = new Mock<IDefaultHttpClientErrorResponseHandler>();
            _motoAssertion = new Management.Domain.Assertions.MotoAssertion(_defaultHttpClientErrorResponseHandler.Object);
            _entity = new MotoEntity();
            _entity.AddBrand("BMW");
            _entity.AddLicensePlate("ORG8G81");
            _entity.AddManufactoreYear(2024);
        }

        [Fact(DisplayName = "Shold_Generate_BadRequestException_When_Moto_Is_Not_Valid")]
        public void MotoNeedsToBeValid_SholdReturnBadRequestException()
        {
            _defaultHttpClientErrorResponseHandler.Setup(c => c.ThrowResponseError(HttpStatusCode.BadRequest, string.Empty, MOTO_IS_NOT_VALID_EXCEPTION_BADREQUEST_MESSAGE))
                .Returns(new HttpClientBadRequestException(MOTO_IS_NOT_VALID_EXCEPTION_BADREQUEST_MESSAGE));

            HttpClientBadRequestException exception = Assert.Throws<HttpClientBadRequestException>(() => _motoAssertion.MotoNeedsToBeValid(null));
            Assert.Equal(MOTO_IS_NOT_VALID_EXCEPTION_BADREQUEST_MESSAGE, exception.Message);
        }

        [Theory(DisplayName = "Shold_Generate_BadRequestException_When_There_Is_Already_Motocycle_With_The_Same_LicensePlate")]
        [InlineData("ORG8G81")]
        public void ThereMustBeNoMotoWhithLicensePlate_SholdReturnBadRequestException(string licensePlate)
        {
            _defaultHttpClientErrorResponseHandler.Setup(c => c.ThrowResponseError(HttpStatusCode.BadRequest, string.Empty, string.Format(MOTOCYCLE_WITH_SAME_LICENSE_PLATE_EXCEPTION_BADREQUEST_MESSAGE, licensePlate)))
                .Returns(new HttpClientBadRequestException(string.Format(MOTOCYCLE_WITH_SAME_LICENSE_PLATE_EXCEPTION_BADREQUEST_MESSAGE, licensePlate)));

            HttpClientBadRequestException exception = Assert.Throws<HttpClientBadRequestException>(() => _motoAssertion.ThereMustBeNoMotoWhithLicensePlate(_entity, licensePlate));
            Assert.Equal(string.Format(MOTOCYCLE_WITH_SAME_LICENSE_PLATE_EXCEPTION_BADREQUEST_MESSAGE, licensePlate), exception.Message);
        }

        [Theory(DisplayName = "Shold_Generate_BadRequestException_When_LicensePlate_IsNullOrEmpty")]
        [InlineData("")]
        [InlineData(null)]
        public void LicensePlateNeedsToBeFill_SholdReturnBadRequestException(string? licensePlate)
        {
            _defaultHttpClientErrorResponseHandler.Setup(c => c.ThrowResponseError(HttpStatusCode.BadRequest, string.Empty, LICENSE_PLATE_NULL_OR_EMPTY_EXCEPTION_BADREQUEST_MESSAGE))
                .Returns(new HttpClientBadRequestException(LICENSE_PLATE_NULL_OR_EMPTY_EXCEPTION_BADREQUEST_MESSAGE));

            HttpClientBadRequestException exception = Assert.Throws<HttpClientBadRequestException>(() => _motoAssertion.LicensePlateNeedsToBeFill(licensePlate));
            Assert.Equal(LICENSE_PLATE_NULL_OR_EMPTY_EXCEPTION_BADREQUEST_MESSAGE, exception.Message);
        }

        [Theory(DisplayName = "Shold_Generate_BadRequestException_When_Moto_IsNotNull_And_Identifier_IsNullOrEmpty")]
        [InlineData("662f0b0fcf7510100bbe4b65")]
        public void MotoEntityMustExists_SholdReturnBadRequestException(string motoId)
        {
            _defaultHttpClientErrorResponseHandler.Setup(c => c.ThrowResponseError(HttpStatusCode.BadRequest, string.Empty, string.Format(MOTO_NOT_NULL_AND_ID_NULL_OR_EMPTY_EXCEPTION_BADREQUEST_MESSAGE, motoId)))
                .Returns(new HttpClientBadRequestException(string.Format(MOTO_NOT_NULL_AND_ID_NULL_OR_EMPTY_EXCEPTION_BADREQUEST_MESSAGE, motoId)));

            HttpClientBadRequestException exception = Assert.Throws<HttpClientBadRequestException>(() => _motoAssertion.MotoEntityMustExists(_entity, motoId));
            Assert.Equal(string.Format(MOTO_NOT_NULL_AND_ID_NULL_OR_EMPTY_EXCEPTION_BADREQUEST_MESSAGE, motoId), exception.Message);
        }
    }
}