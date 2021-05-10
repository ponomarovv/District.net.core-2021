using System;
using System.Threading.Tasks;
using District.Dal.Abstact;
using District.Dal.Abstact.IRepository;
using District.Dal.Impl.Repository;

namespace District.Dal.Impl
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly DistrictDbContext _dbContext;
        private IApartmentRepository _apartmentRepository;
        private IPersonRepository _personRepository;  // 
        private IBuildingRepository _buildingRepository;
        private IEntranceRepository _entranceRepository;
        public UnitOfWork(DistrictDbContext dbContext, IApartmentRepository apartmentRepository, IPersonRepository personRepository, IBuildingRepository buildingRepository, IEntranceRepository entranceRepository)
        {
            this._dbContext = dbContext;
            _apartmentRepository = apartmentRepository;
            _personRepository = personRepository;
            _buildingRepository = buildingRepository;
            _entranceRepository = entranceRepository;


            //_apartmentRepository = new ApartmentRepository(_dbContext);
            //_personRepository = new PersonRepository(_dbContext);
        }

        public ApartmentRepository ApartmentRepository
        {
            get { return (ApartmentRepository) (_apartmentRepository ??= new ApartmentRepository(_dbContext)); }
        }

        public PersonRepository PersonRepository
        {
            get { return (PersonRepository) (_personRepository ??= new PersonRepository(_dbContext)); }
        }

        public BuildingRepository BuildingRepository
        {
            get { return (BuildingRepository) (_buildingRepository ??= new BuildingRepository(_dbContext)); }
        }

        public EntranceRepository EntranceRepository
        {
            get { return (EntranceRepository)(_entranceRepository ??= new EntranceRepository(_dbContext)); }
        }

       

        //public void Save()
        //{
        //    _dbContext.SaveChanges();
        //}

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }

        private bool _disposed = false;

        //public virtual void Dispose(bool disposing)
        //{
        //    if (!this._disposed)
        //    {
        //        if (disposing)
        //        {
        //            _dbContext.Dispose();
        //        }

        //        this._disposed = true;
        //    }
        //}

        public void Dispose()
        {
            //Dispose(true);
            _dbContext.Dispose();

            GC.SuppressFinalize(this);
        }
    }
}
