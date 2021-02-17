using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace District.Dal
{
    public class DbContextManager
    {
        private static DistrictDbCondext _districtDbCondext = null;
        public static DistrictDbCondext DistrictDbCondext
        {
            get => _districtDbCondext ??= new DistrictDbCondext();
            private set => _districtDbCondext = value;
        }
    }
}
