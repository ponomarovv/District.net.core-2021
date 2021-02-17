
using District.Bl.Abstract.IServices;
using District.Bl.Impl.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Building_BL
{
    public class PersonOwnerService : IPersonOwnerService
    {
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public DateTime OrderDate { get; set; }
        //public List<Apartment> Apartments { get; set; } 

        public void BuyApartment(ApartmentService apartment)
        {

        }

    }
}
