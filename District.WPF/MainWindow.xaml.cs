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
using District.Entities.Tables;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace District.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Эта трехуровневая архитектура буквально выпила мою душу. Она принесла мне огромное количество радости и разочарований. Спасибо.

        readonly IPersonService personService = new PersonService();
        readonly IApartmentService apartmentService = new ApartmentService();
        readonly IBuildingService buildingService = new BuildingService();
        readonly IEntranceService entranceService = new EntranceService();

        SquarePrice squarePrice = new SquarePrice();



        public MainWindow()
        {
            InitializeComponent();



            int n = 100;
            List<string> sss = new List<string>();
            for (int i = 0; i < n; i++)
            {
                sss.Add((i + 1).ToString());
            }

            ListBox_Persons.ItemsSource = null;
            ListBox_Persons.ItemsSource = sss;

            FindApartmentsByPersons.IsEnabled = false;


        }

        

        private void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private async void LoadPersons_Button_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Begin");
            //Generator generator = new Generator();
            //var res = generator.CreateBuildings(4);
            //await res;
            //MessageBox.Show("END");


            ListBox_Persons.ItemsSource = null;

            Task<List<PersonModel>> allPersons = personService.GetAllPersons();
            //allPersons.Wait();
            await allPersons;

            List<string> allPersonsString = new List<string>();
            
            List<PersonModel> allPersonsResult = allPersons.Result;
            int allPersonsLength = allPersons.Result.Capacity;

            for (int i = 0; i < allPersonsLength; i++)
            {
                PersonModel pers = allPersonsResult[i];
                allPersonsString.Add($"{pers.Name}");
            }

            ListBox_Persons.ItemsSource = allPersonsString;
            
            FindApartmentsByPersons.IsEnabled = true;

        }

        private async void Find_Apartments_by_Persons_Button_Click(object sender, RoutedEventArgs e)
        {
            int ListBox_Persons_SelectedItems_Count = ListBox_Persons.SelectedItems.Count;

            Task<List<PersonModel>> allPersons = personService.GetAllPersons();
            await allPersons;

            //string s = "Name2";


            List<PersonModel> allPersonsResult = allPersons.Result;
            

            if (ListBox_Persons.SelectedItems.Count == 0)
            {
                TextBox_OutPut.Text = "There are no selected Persons";
                MessageBox.Show("There are no selected Persons");
            }
            else
            {
                TextBox_OutPut.Text = "";

                List<ApartmentModel> apartments = new List<ApartmentModel>();
                List<string> apartmentsToString = new List<string>();

                foreach (string selectedItem in ListBox_Persons.SelectedItems)
                {
                    TextBox_OutPut.Text = selectedItem.ToString();
                    Task<PersonModel> somePerson = personService.FindPersonByName(selectedItem.ToString());
                    await somePerson;

                    Task<List<ApartmentModel>> apartmentsByPersonId = apartmentService.GetApartmentsByPersonId(somePerson.Result.Id);
                    await apartmentsByPersonId;

                    //apartments.AddRange(apartmentsByPersonId.Result);
                    foreach (ApartmentModel ap in apartmentsByPersonId.Result)
                    {
                        apartments.Add(ap);
                    }


                    //if (selectedItem.ToString() == "Name2")
                    //{
                    //    TextBox_OutPut.Text = "Got it.";
                    //}
                }

                foreach (var apartment in apartments)
                {
                    BuildingModel bm = new BuildingModel();
                    Task<BuildingModel> bmTask = buildingService.GetByIdAsync(apartment.BuildingId);
                    await bmTask;
                    bm = bmTask.Result;


                    PersonModel pm = new PersonModel();
                    Task<PersonModel> pmTask = personService.GetByIdAsync(apartment.PersonId);
                    await pmTask;
                    pm = pmTask.Result;

                    apartmentsToString.Add($"Building: {bm.BuildingNumber}, Apartment Number: {apartment.ApartmentNumber}, Own: {apartment.IsOwn}, Owner: {pm.Name}, Phone: {pm.PhoneNumber}, OrderDate: {apartment.OrderDate}");
                    //apartmentsToString.Add("1");

                }
                ListBox_OutPut.ItemsSource = null;
                ListBox_OutPut.ItemsSource = apartmentsToString;
            }
        }
    }
}
