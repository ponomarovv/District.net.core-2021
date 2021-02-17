using District.Bl.Abstract.IMappers;
using District.Entities.Tables;
using District.Models.Models;


namespace District.Bl.Impl.Mappers
{
    public class ApartmentMapper : IMapper<Apartment, ApartmentModel>
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
            };
        }
    }
}
