using District.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace District.Bl.Abstract.IServices
{
    public interface IApartmentService
    {
        Task<List<ApartmentModel>> GetAllApartments();
        Task<List<ApartmentModel>> GetApartmentsByBuildingId(int buildId);
        Task<ApartmentModel> CreateApartment(ApartmentModel model);
        Task<List<ApartmentModel>> GetApartmentsByPersonId(int personId);
    }
}
