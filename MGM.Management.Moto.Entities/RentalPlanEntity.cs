using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MGM.Management.Moto.Entities
{
    public class RentalPlanEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; private set; }

        public string Name { get; private set; } = string.Empty;

        public int Days { get; private set; }

        public decimal CostPerDay { get; private set; }

        public bool UnderDeliveryPerformance { get; private set; }

        public decimal FineRateAppliedInPercentage { get; private set; }

        public decimal FineRateAppliedInMonetaryValue { get; private set; }

        public void AddId(string? value) => Id = value;

        public void AddName(string value) => Name = value;

        public void AddDays(int value) => Days = value;

        public void AddCostPerDay(decimal value) => CostPerDay = value;

        public void AddUnderDeliveryPerformance(bool value) => UnderDeliveryPerformance = value;

        public void AddFineRateAppliedInPercentage(decimal value) => FineRateAppliedInPercentage = value;

        public void AddFineRateAppliedInMonetaryValue(decimal value) => FineRateAppliedInMonetaryValue = value;
    }
}
