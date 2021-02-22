using District.Bl.Abstract.IMappers;
using District.Entities.Tables;
using District.Models.Models;


namespace District.Bl.Impl.Mappers
{
    public class ApartmentMapper : IBackMapper<Apartment, ApartmentModel>
    {
        public ApartmentModel Map(Apartment entity)
        {
            return new ApartmentModel
            {
                ApartmentNumber = entity.ApartmentNumber,
                BuildingId = entity.BuildingId,
                Id = entity.Id,
                IsOwn = entity.IsOwn,
                SquareSize = entity.SquareSize,
                EntranceId = entity.EntranceId,
                PersonId = entity.PersonId,
                OrderDate = entity.OrderDate,
            };
        }
        public Apartment MapBack(ApartmentModel model)
        {
            return new Apartment
            {
                ApartmentNumber = model.ApartmentNumber,
                BuildingId = model.BuildingId,
                Id = model.Id,
                IsOwn = model.IsOwn,
                SquareSize = model.SquareSize,
                EntranceId = model.EntranceId,
                PersonId = model.PersonId,
                OrderDate = model.OrderDate,
            };
        }
    }
}
