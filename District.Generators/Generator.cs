using District.Bl.Abstract.IServices;
using District.Bl.Impl.Services;

using District.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace District.Generators
{
    public class Generator
    {
        public async Task CreateBuildings(int countBuildings)
        {
            IBuildingService buildingService = new BuildingService();
            for (int i = 0; i < countBuildings; i++)
            {
                var res = await buildingService.CreateBuilding(new BuildingModel()
                {
                    BuildingNumber = i + 1,

                });
                await CreateEntrances(res.Id, 2);
            }
        }

        public async Task CreateEntrances(int buildingId, int countEntrances)
        {
            IEntranceService entranceServiceService = new EntranceService();
            for (int i = 0; i < countEntrances; i++)
            {
                var res = await entranceServiceService.CreateEntrance(new EntranceModel()
                {
                    BuildingId = buildingId,
                    EntranceNumber = i + 1,

                });
                await CreateAppartments(buildingId, res.Id, 75);
            }
        }

        public async Task CreateAppartments(int buildingId, int entranceId, int countApartments)
        {
            IApartmentService apartmentService = new ApartmentService();
            Random Rand = new Random();
            for (int i = 0; i < countApartments; i++)
            {
                var res = await apartmentService.CreateApartment(new ApartmentModel()
                {
                    BuildingId = buildingId,
                    EntranceId = entranceId,
                    IsOwn = false,
                    SquareSize = Rand.Next(50, 100),
                    ApartmentNumber = i + 1,
                    PersonId = 1,
                });
            }
        }
    }
}
