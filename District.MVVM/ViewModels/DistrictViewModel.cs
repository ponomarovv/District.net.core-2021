using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using District.Bl.Abstract.IServices;
using District.Models.Models;
using District.MVVM.Commands;
//using MVVM;

namespace District.MVVM.ViewModels
{
    public class DistrictViewModel : INotifyPropertyChanged
    {
        private ApartmentModel _selectedApartment;
        private readonly IApartmentService _apartmentService;
        private ObservableCollection<ApartmentModel> _apartments;

        private PersonModel _selectedPerson;
        private readonly IPersonService _personService;
        private ObservableCollection<PersonModel> _persons;

        private readonly Action _updateData;

        private readonly ICommand _closeCommand;
        public ICommand CloseCommand
        {
            get => _closeCommand;
        }


        private ICommand _buyApartmentCommand;
        public ICommand BuyApartmentCommand
        {
            get => _buyApartmentCommand;

        }



        public ObservableCollection<ApartmentModel> Apartments
        {
            get
            {
                return _apartments;
            } 
            set
            {
                _apartments = value;
                OnPropertyChanged(nameof(Apartments));
            }
        }

        public ApartmentModel SelectedApartment
        {
            get
            {

                return _selectedApartment;
            }
            set
            {

                _selectedApartment = value;
                ((BuyApartmentCommand) _buyApartmentCommand).SelectedApartment = value;
                OnPropertyChanged("SelectedApartment");

               
            }
        }

        public PersonModel SelectedPerson
        {
            get
            {
                
                return _selectedPerson;
            }
            set
            {

                _selectedPerson = value;
                ((BuyApartmentCommand) _buyApartmentCommand).SelectedPerson = value;
                OnPropertyChanged("SelectedPerson");
            }


        }

        public ObservableCollection<PersonModel> Persons
        {
            get => _persons;
            set
            {
                _persons = value;
                OnPropertyChanged(nameof(Persons));
            }
        }

       

        public DistrictViewModel(IApartmentService apartmentService, IPersonService personService)
        {
            _apartmentService = apartmentService;
            _personService = personService;

            _closeCommand = new CloseCommand();
            _updateData += InitData;
            _buyApartmentCommand = new BuyApartmentCommand(_personService, _updateData);

            
            InitData();
        }

        private async void InitData()
        {
            List<ApartmentModel> allApartments = await _apartmentService.GetAllApartments();
            Apartments = new ObservableCollection<ApartmentModel>(allApartments);

            List<PersonModel> allPersons = await _personService.GetAllPersons();
            Persons = new ObservableCollection<PersonModel>(allPersons);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}