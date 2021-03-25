
using District.Bl.Abstract.IServices;
using District.Bl.Impl.Services;
using District.Models.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using District.Generators;


namespace District.CLI
{
    class Program
    {
        static void SomeApartmentToName2()
        {


            Console.WriteLine("Do not press enter");
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            //Эта трехуровневая архитектура буквально выпила мою душу. Она принесла мне огромное количество радости и разочарований. Спасибо.


            SomeApartmentToName2();
            //Generator generator = new Generator();
            //var res = generator.CreateBuildings(4);
            //res.Wait();

            IPersonService personService = new PersonService();
            IApartmentService apartmentService = new ApartmentService();
            IBuildingService buildingService = new BuildingService();

            //Console.WriteLine("Enter someName please:");
            //string s = Console.ReadLine();

            //string someName = "Building Creator";
            string someName = "Name2";


            SquarePrice squarePrice = new SquarePrice();
            //squarePrice.priceForOneM2 = 100;

            var somePerson = personService.FindPersonByName(someName);
            somePerson.Wait();

            var foundApartments = apartmentService.GetApartmentsByPersonId(somePerson.Result.Id);
            foundApartments.Wait();
            foreach (var apartment in foundApartments.Result)
            {
                var tempBuilding = buildingService.GetByIdAsync(apartment.BuildingId);
                tempBuilding.Wait();
                Console.WriteLine($"{somePerson.Result.Name}, {tempBuilding.Result.BuildingNumber} , {apartment.ApartmentNumber},  {apartment.SquareSize}, {apartment.SquareSize * squarePrice.priceForOneM2}, {apartment.OrderDate}, {somePerson.Result.PhoneNumber}");
            }
            Console.WriteLine();

            //find all
            var allPerson = personService.GetAllPersons();
            allPerson.Wait();
            
            foreach (var person  in allPerson.Result)
            {
                if (person.Id == 1)
                {
                    continue;
                }
                var personApartments = apartmentService.GetApartmentsByPersonId(person.Id);
                personApartments.Wait();
                foreach (var personApartment in personApartments.Result)
                {
                    var tempBuilding = buildingService.GetByIdAsync(personApartment.BuildingId);
                    tempBuilding.Wait();
                    Console.WriteLine($"{person.Name}, {tempBuilding.Result.BuildingNumber}, {personApartment.ApartmentNumber},  {personApartment.OrderDate}, {person.PhoneNumber} {personApartment.SquareSize}, {personApartment.SquareSize * squarePrice.priceForOneM2},");
                }
            }
            
            
            //

            //var item = personService.CreatePerson(new PersonModel
            //{
            //    Id = 2,
            //    Name = "Name1",
            //    PhoneNumber = 0670000001,
            //});
            //item.Wait();

            // Buy apartment
            //var person = personService.BuyAppartment(3, 9);
            //person.Wait();

            //var item2 = personService.CreatePerson(new PersonModel
            //{
            //    Id = 3,
            //    Name = "Name3",
            //    PhoneNumber = 0670000003,
            //});
            //item2.Wait();





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


            //IPersonService personService = new PersonService();
            ////var res = personService.CreatePerson(new PersonModel()
            ////{
            ////    //Id = 0,
            ////    Name = "Name2",
            ////    PhoneNumber = 0670000002,
            ////});
            ////res.Wait();

            ////res = personService.
            ////res.Wait();

            //Task<List<PersonModel>> persons = personService.GetAllPersons();
            //persons.Wait();
            //foreach (var person in persons.Result)
            //{
            //    Console.WriteLine($"{person.Id}, {person.Name}, {person.PhoneNumber}");
            //}



            Console.WriteLine("End of program");
            Console.ReadLine();
        }
    }
}


