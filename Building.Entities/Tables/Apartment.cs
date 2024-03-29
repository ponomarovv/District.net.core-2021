﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace District.Entities.Tables
{
    public class Apartment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey(nameof(Building))]
        public int BuildingId { get; set; }
        public Building Building { get; set; }

        [ForeignKey(nameof(Person))]
        public int PersonId { get; set; }
        public Person Person { get; set; }

        [ForeignKey(nameof(Entrance))]
        public int EntranceId { get; set; }
        public Entrance Entrance { get; set; }




        public int SquareSize { get; set; }
        public int ApartmentNumber { get; set; }

        public bool IsOwn { get; set; } = false;
        public DateTime? OrderDate { get; set; }


        //public int BuildingNumber
    }
}
