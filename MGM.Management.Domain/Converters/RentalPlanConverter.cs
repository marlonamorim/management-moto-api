using MGM.Management.Domain.ValueObjects;
using MGM.Management.Moto.Entities;

namespace MGM.Management.Domain.Converters
{
    public static class RentalPlanConverter
    {
        public static RentalPlanValueObject ToValueObject(this RentalPlanEntity entity) =>
            new()
            {
                Id = entity.Id,
                Name = entity.Name,
                Days = entity.Days,
                CostPerDay = entity.CostPerDay,
                FineRateAppliedInMonetaryValue = entity.FineRateAppliedInMonetaryValue,
                FineRateAppliedInPercentage = entity.FineRateAppliedInPercentage,
                UnderDeliveryPerformance = entity.UnderDeliveryPerformance
            };

        public static RentalPlanEntity ToEntity(this RentalPlanValueObject vo)
        {
            var entity = new RentalPlanEntity();
            entity.AddId(vo.Id);
            entity.AddName(vo.Name);
            entity.AddDays(vo.Days);
            entity.AddCostPerDay(vo.CostPerDay);
            entity.AddUnderDeliveryPerformance(vo.UnderDeliveryPerformance);
            entity.AddFineRateAppliedInPercentage(vo.FineRateAppliedInPercentage);
            entity.AddFineRateAppliedInMonetaryValue(vo.FineRateAppliedInMonetaryValue);

            return entity;
        }
    }
}
