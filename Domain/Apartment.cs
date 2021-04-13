using System;
using System.Collections.Generic;
using System.Text;
using Domain.Abstract;

namespace Domain
{
    public class Apartment : IApartment  
    {
        public int SquareSize { get; set; }
        public int ApartmentNumber { get; set; }


        public static int square_price = 10; // 10 грн за квадратный метр.

        public bool IsOwn { get; set; }
        public string OwnerName { get; set; } // maybe it will be failed. Should to do another way...
    }
}
