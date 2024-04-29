using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MGM.Management.Moto.Entities
{
    public class RentalPlanUserEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; private set; }

        public string UserId { get; private set; } = string.Empty;

        public DateTime RentalStartDate { get; private set; }

        public DateTime RentalEndDate { get; private set; }

        public DateTime ExpectedRentalEndDate { get; private set; }

        public DateTime CreateAt { get; private set; }

        public decimal RentalTotalCost { get; private set; }

        public RentalPlanEntity RentalPlan { get; private set; } = new();

        public MotoEntity Moto { get; private set; } = new();

        public void AddUserId(string value) => UserId = value;

        public void AddRentalStartDate(DateTime value) => RentalStartDate = value;

        public void AddRentalEndDate(DateTime value) => RentalEndDate = value;

        public void AddExpectedRentalEndDate(DateTime value) => ExpectedRentalEndDate = value;

        public void AddRentalTotalCost(decimal value) => RentalTotalCost = value;

        public void AddRentalPlan(RentalPlanEntity value) => RentalPlan = value;

        public void AddMoto(MotoEntity value) => Moto = value;

        public void AddCreateAt() => CreateAt = DateTime.Now;
    }
}
