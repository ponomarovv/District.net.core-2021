using System;
using System.Collections.Generic;
using System.Text;
using Domain.Abstract;

namespace Domain
{
    public class Building : IBuilding
    {
        //и, тут нарушается инкапсуляция? Или норм?
        public List<Apartment> Apartments { get; set; }
        
        public string Street { get; set; }
        public int BuildingNumber { get; set; }




    }
}
