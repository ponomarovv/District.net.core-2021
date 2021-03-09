using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using District.Bl.Abstract.IServices;
using District.Bl.Impl.Services;
using District.Generators;

namespace District.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IPersonService personService = new PersonService();
        IApartmentService apartmentService = new ApartmentService();
        IBuildingService buildingService = new BuildingService();


        public MainWindow()
        {
            InitializeComponent();




        }

        private void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Эта трехуровневая архитектура буквально выпила мою душу. Она принесла мне огромное количество радости и разочарований. Спасибо.



            //Generator generator = new Generator();
            //var res = generator.CreateBuildings(4);
            //res.Wait();



            //Console.WriteLine("Enter someName please:");
            //string s = Console.ReadLine();

            //string someName = "Building Creator";
            string someName = "Name2";

            //while (true)
            //{
            //    Task<List<PersonModel>> persons = personService.GetAllPersons();
            //    persons.Wait();
            //    foreach (var person in persons.Result)
            //    {
            //        if (person.Name == someName)
            //        {
            //            break;
            //        }
            //        Console.WriteLine($"{person.Id}, {person.Name}, {person.PhoneNumber}");
            //    }
            //}
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
                //lb1.
            }
            Console.WriteLine();

            //find all
            var allPerson = personService.GetAllPersons();
            somePerson.Wait();

            foreach (var person in allPerson.Result)
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
        }


    }
}
