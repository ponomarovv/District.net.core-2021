using District.Dal.Impl.Repository;

namespace District.Dal.Abstact
{
    public interface IUnitOfWork
    {
        ApartmentRepository ApartmentRepository { get; }


        public PersonRepository PersonRepository { get; }

        public BuildingRepository BuildingRepository { get; }

        public EntranceRepository EntranceRepository { get; }

        void Save();

    }
}