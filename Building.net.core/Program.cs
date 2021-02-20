
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
        static void Main(string[] args)
        {
            //IApartmentService apartmentService = new ApartmentService();
            //var res = apartmentService.CreateApartment(new ApartmentModel()
            //{
            //    ApartmentNumber = 1,
            //    BuildingId = 1,
            //    IsOwn = false,
            //    SquareSize = 12,
            //    EntranceId = 1,
            //    PersonId = 1,
            //});
            //res.Wait();
            //Task<List<ApartmentModel>> apartments = apartmentService.GetAllApartments();
            //apartments.Wait();
            //foreach (var apartment in apartments.Result)
            //{
            //    Console.WriteLine($"{apartment.ApartmentNumber}, {apartment.SquareSize}, {apartment.IsOwn} ");
            //}


            //IPersonService PersonService = new PersonService();
            //var res = PersonService.CreatePerson(new ApartmentModel()
            //{
            //    ApartmentNumber = 1,
            //    BuildingId = 1,
            //    IsOwn = false,
            //    SquareSize = 12,
            //    EntranceId = 1,
            //    PersonId = 1,
            //});
            //res.Wait();
            //Task<List<PersonModel>> persons = PersonService.GetAllPersons();
            //persons.Wait();
            //foreach (var person in persons.Result)
            //{
            //    Console.WriteLine($"{person.Name}, {person.SquareSize}, {person.IsOwn} ");
            //}



            Console.WriteLine("End of program");
            Console.ReadLine();
        }
    }
}

