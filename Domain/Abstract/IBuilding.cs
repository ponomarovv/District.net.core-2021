using System.Collections.Generic;

namespace Domain.Abstract
{
    public interface IBuilding
    {
        //и, тут нарушается инкапсуляция? Или норм?
        public List<Apartment> Apartments { get; set; }




        public string Street { get; set; }
        public int BuildingNumber { get; set; }
    }
}