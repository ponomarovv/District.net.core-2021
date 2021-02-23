using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace District.Models.Models
{
    public class EntranceModel
    {

        public int Id { get; set; }
        public int EntranceNumber { get; set; }
        //public Building Building { get; private set; }

        public int BuildingId { get; set; }


    }
}
