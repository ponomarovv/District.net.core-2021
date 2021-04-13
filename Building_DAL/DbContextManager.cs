using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace District.Dal
{
    public class DbContextManager
    {
        private static DistrictDbContext _districtDbContext = null;
        public static DistrictDbContext DistrictDbContext
        {
            get
            {
                if (_districtDbContext == null)
                {
                    _districtDbContext = new DistrictDbContext();
                }
                return _districtDbContext;
            }

            private set
            {
                _districtDbContext = value;
            }
        }
    }
}
