using MGM.Management.Domain.Assertions;
using MGM.Management.Domain.Converters;
using MGM.Management.Domain.Services;
using MGM.Management.Domain.ValueObjects;
using MGM.Management.Moto.Repository;

namespace MGM.Management.Domain.Command.Persistence
{
    public class CreateRentalPlanUserCommand(IRentalPlanUserRepository rentalPlanUserRepository,
        IRentalPlanRepository rentalPlanRepository,
        IUserRepository userRepository,
        IMotoRepository motoRepository,
        IContextAccessorService contextAccessorService,
        IQuotationService quotationService,
        IRentalPlanUserAssertion rentalPlanUserAssertion,
        IMotoAssertion motoAssertion) : ICreateRentalPlanUserCommand
    {
        private readonly IRentalPlanUserRepository _rentalPlanUserRepository = rentalPlanUserRepository;
        private readonly IRentalPlanRepository _rentalPlanRepository = rentalPlanRepository;
        private readonly IContextAccessorService _contextAccessorService = contextAccessorService;
        private readonly IQuotationService _quotationService = quotationService;
        private readonly IRentalPlanUserAssertion _rentalPlanUserAssertion = rentalPlanUserAssertion;
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IMotoRepository _motoRepository = motoRepository;
        private readonly IMotoAssertion _motoAssertion = motoAssertion;

        private RentalPlanUserValueObject? RentalPlanUser;
        private readonly ICollection<string> CnhCategories = ["A", "AB"];

        public void AddPayload(RentalPlanUserValueObject obj)
            => RentalPlanUser = obj;

        public async Task ExecuteAsync()
        {
            var userId = _contextAccessorService.GetUserId();

            _rentalPlanUserAssertion.ThereMustBeUserId(userId);

            var user = await _userRepository.GetByIdAsync(userId!);

            _rentalPlanUserAssertion.UserThereMustBeCnhCategory(user, CnhCategories);

            var rentalPlan = await _rentalPlanRepository.GetByIdAsync(RentalPlanUser!.RentalPlanId);

            _rentalPlanUserAssertion.ThereMustBeRentalPlan(rentalPlan, RentalPlanUser.RentalPlanId);

            var moto = await _motoRepository.GetByIdAsync(RentalPlanUser.MotoId);

            _motoAssertion.MotoEntityMustExists(moto, RentalPlanUser.MotoId);

            RentalPlanUser!.UserId = userId!;
            RentalPlanUser.RentalStartDate = DateTime.Now.AddDays(1);
            RentalPlanUser.RentalEndDate = DateTime.Now.AddDays(rentalPlan.Days + 1);
            RentalPlanUser.RentalPlan = rentalPlan.ToValueObject();
            RentalPlanUser.Moto = moto.ToValueObject();

            var quotation = await _quotationService.GetByExpectedRentalEndDateAsync(
                RentalPlanUser!.ExpectedRentalEndDate,
                RentalPlanUser.RentalPlanId);

            RentalPlanUser.RentalTotalCost = quotation.TotalCost;

            await _rentalPlanUserRepository.CreateAsync(RentalPlanUser.ToEntity());
        }
    }
}
