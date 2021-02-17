using Building_BL;
using District.Bl.Abstract.IServices;
using District.Bl.Impl.Services;
using District.Models.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace District.CLI
{
    class Program
    {
        //static async void  Main(string[] args)
        static void Main(string[] args)
        {            
            IApartmentService apartmentService = new ApartmentService();

            //List<ApartmentModel> apartments = await apartmentService.GetAllApartments();

            Console.WriteLine("End of program");
            //Console.ReadLine();
        }
    }
}

