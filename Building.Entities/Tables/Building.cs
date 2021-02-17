using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace District.Entities.Tables
{
    public class Building
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //public List<Apartment> Apartments { get; set; }

        public string Street { get; set; }
        public int BuildingNumber { get; set; }
    }
}
