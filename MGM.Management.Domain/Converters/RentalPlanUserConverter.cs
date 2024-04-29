using MGM.Management.Domain.ValueObjects;
using MGM.Management.Moto.Entities;

namespace MGM.Management.Domain.Converters
{
    public static class RentalPlanUserConverter
    {
        public static RentalPlanUserEntity ToEntity(this RentalPlanUserValueObject vo)
        {
            RentalPlanUserEntity entity = new();
            entity.AddRentalPlan(vo.RentalPlan.ToEntity());
            entity.AddMoto(vo.Moto.ToEntity());
            entity.AddRentalStartDate(vo.RentalStartDate);
            entity.AddRentalEndDate(vo.RentalEndDate);
            entity.AddExpectedRentalEndDate(vo.ExpectedRentalEndDate);
            entity.AddCreateAt();
            entity.AddUserId(vo.UserId);
            entity.AddRentalTotalCost(vo.RentalTotalCost);

            return entity;
        }
    }
}
