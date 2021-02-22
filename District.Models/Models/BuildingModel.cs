using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace District.Models.Models
{
    public class BuildingModel
    {
        public int Id { get; set; }
        //public List<Apartment> Apartments { get; set; }

        public string Street { get; set; } = "Street";
        public int BuildingNumber { get; set; }
    }
}
