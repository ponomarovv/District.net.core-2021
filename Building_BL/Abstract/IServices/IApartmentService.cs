using District.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace District.Bl.Abstract.IServices
{
    public interface IApartmentService
    {

        Task<ApartmentModel> CreateApartment(ApartmentModel model);
        Task<ApartmentModel> GetByIdAsync(int id);
        Task UpdateApartment(ApartmentModel model);
        Task DeleteApartment(int id);


        Task<List<ApartmentModel>> GetApartmentsByPersonId(int personId);
        Task<List<ApartmentModel>> GetAllApartments();
        Task<List<ApartmentModel>> GetApartmentsByBuildingId(int buildId);
    }
}
