using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace District.Entities.Tables
{
    public class Entrance  
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey(nameof(Building))]
        public int BuildingId { get; set; }
        public Building Building { get; set; }



        public int EntranceNumer { get; set; }
        //public Building Building { get; private set; }
    }
}
