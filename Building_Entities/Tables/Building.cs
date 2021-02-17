using System;
using System.Collections.Generic;
using System.Text;
//using System.ComponentModel.DataAnnotations.Schema;

namespace Building_Entities.Tables
{
    class Building
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //и, тут нарушается инкапсуляция? Или норм?
        //public List<Apartment> Apartments { get; set; }

        public string Street { get; set; }
        public int BuildingNumber { get; set; }


    }
}
