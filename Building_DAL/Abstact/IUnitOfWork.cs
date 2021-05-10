using System.Threading.Tasks;
using District.Dal.Impl.Repository;

namespace District.Dal.Abstact
{
    public interface IUnitOfWork
    {
         ApartmentRepository ApartmentRepository { get; }


         PersonRepository PersonRepository { get; }

         BuildingRepository BuildingRepository { get; }

         EntranceRepository EntranceRepository { get; }

        //void Save();
        Task Save();

    }
}