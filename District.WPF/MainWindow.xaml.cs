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
using District.Models.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace District.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Эта трехуровневая архитектура буквально выпила мою душу. Она принесла мне огромное количество радости и разочарований. Спасибо.

        IPersonService personService = new PersonService();
        IApartmentService apartmentService = new ApartmentService();
        IBuildingService buildingService = new BuildingService();
        IEntranceService entranceService = new EntranceService();

        SquarePrice squarePrice = new SquarePrice();



        public MainWindow()
        {
            InitializeComponent();

            int n = 10;
            List<string> sss = new List<string>();
            for (int i = 0; i < n; i++)
            {
                sss.Add((i + 1).ToString());
            }

            lb1.ItemsSource = null;
            lb1.ItemsSource = sss;


            //lb1.ItemsSource = allPersons.Result;
            //List<PersonModel> p = new List<PersonModel>();
            //List<string> p = new List<string>();
            //foreach (var person in allPersons.Result)
            //{
            //    p.Add(person.Name);
            //}

            //lb1.ItemsSource = p;
        }

        private void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            lb1.ItemsSource = null;

            var allPersons = personService.GetAllPersons();
            //allPersons.Wait();
            await allPersons;

            List<string> allPersonsString = new List<string>();

            int allPersonsLength = allPersons.Result.Capacity;

            for (int i = 0; i < allPersonsLength; i++)
            {
                allPersonsString.Add(allPersons.Result[i].Name);
            }

            lb1.ItemsSource = allPersonsString;
            





            ////string s = Console.ReadLine();

            ////string someName = "Building Creator";
            //string someName = "Name2";

            ////while (true)
            ////{
            ////    Task<List<PersonModel>> persons = personService.GetAllPersons();
            ////    persons.Wait();
            ////    foreach (var person in persons.Result)
            ////    {
            ////        if (person.Name == someName)
            ////        {
            ////            break;
            ////        }
            ////        Console.WriteLine($"{person.Id}, {person.Name}, {person.PhoneNumber}");
            ////    }
            ////}
            ////squarePrice.priceForOneM2 = 100;

            //var somePerson = personService.FindPersonByName(someName);
            //somePerson.Wait();

            //var foundApartments = apartmentService.GetApartmentsByPersonId(somePerson.Result.Id);
            //foundApartments.Wait();

            //List<ApartmentModel> aps = new List<ApartmentModel>();
            //foreach (var apartment in foundApartments.Result)
            //{
            //    //var tempBuilding = buildingService.GetByIdAsync(apartment.BuildingId);
            //    //tempBuilding.Wait();
            //    //Console.WriteLine($"{somePerson.Result.Name}, {tempBuilding.Result.BuildingNumber} , {apartment.ApartmentNumber},  {apartment.SquareSize}, {apartment.SquareSize * squarePrice.priceForOneM2}, {apartment.OrderDate}, {somePerson.Result.PhoneNumber}");


            //    aps.Add(apartment);
            //}

            //lb1.ItemsSource = aps;



            ////find all
            //var allPerson = personService.GetAllPersons();
            //somePerson.Wait();

            //foreach (var person in allPerson.Result)
            //{
            //    if (person.Id == 1)
            //    {
            //        continue;
            //    }
            //    var personApartments = apartmentService.GetApartmentsByPersonId(person.Id);
            //    personApartments.Wait();
            //    foreach (var personApartment in personApartments.Result)
            //    {
            //        var tempBuilding = buildingService.GetByIdAsync(personApartment.BuildingId);
            //        tempBuilding.Wait();
            //        Console.WriteLine($"{person.Name}, {tempBuilding.Result.BuildingNumber}, {personApartment.ApartmentNumber},  {personApartment.OrderDate}, {person.PhoneNumber} {personApartment.SquareSize}, {personApartment.SquareSize * squarePrice.priceForOneM2},");
            //    }
            //}
        }

    }
}
