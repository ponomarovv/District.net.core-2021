using System;
using District.Dal.Abstact;
using District.Dal.Impl.Repository;

namespace District.Dal.Impl
{
    public class UnitOfWork : IDisposable
    {
        private readonly DistrictDbContext _dbContext = DbContextManager.DistrictDbContext;
        private ApartmentRepository _apartmentRepository;
        private PersonRepository _personRepository;

        public ApartmentRepository ApartmentRepository
        {
            get { return _apartmentRepository ??= new ApartmentRepository(_dbContext); }
        }

        public PersonRepository PersonRepository
        {
            get { return _personRepository ??= new PersonRepository(_dbContext); }
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        private bool _disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }

                this._disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
