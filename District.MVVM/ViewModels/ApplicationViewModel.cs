using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using District.Bl.Abstract.IServices;
using District.Bl.Impl.Services;
using District.Models.Models;

namespace MVVM
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private ApartmentModel _selectedApartment;
        private IApartmentService _apartmentService;
        private ObservableCollection<ApartmentModel> _apartments;

        //private PersonModel _selectedPerson;
        private IPersonService _personService;
        private ObservableCollection<PersonModel> _persons;

        public ObservableCollection<ApartmentModel> Apartments
        {
            get => _apartments;
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
                //if (_selectedApartment == null) 
                //{
                //    return new ApartmentModel();
                //}
                return _selectedApartment;
            }
            set
            {
                
                _selectedApartment = value;
                OnPropertyChanged("SelectedApartment");

                SetSelectedPersonModel(SelectedApartment);
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

        private RelayCommand _closeCommand;
        public RelayCommand CloseCommand
        {
            get
            {
                return _closeCommand ??
                       (_closeCommand = new RelayCommand
                           (obj => 
                           {
                               //MessageBox.Show("Program is closing.", caption: "Close info");
                               Application.Current.Shutdown();

                           })
                       );
            }
        }


 

        public ApplicationViewModel()
        {
            InitData();
        }

        private async void InitData()
        {
            _apartmentService = new ApartmentService();
            _personService = new PersonService();
            var allApartments = await _apartmentService.GetAllApartments();
            Apartments = new ObservableCollection<ApartmentModel>(allApartments);

            //_personService = new PersonService();
            //var personOfApartment = await _personService.GetByIdAsync(SelectedApartment.PersonId);
            //Persons = new ObservableCollection<PersonModel>();
            //Persons.Add(personOfApartment);
        }

        public async Task SetSelectedPersonModel(ApartmentModel selectedApartment)
        {
            var personOfApartment = await _personService.GetByIdAsync(selectedApartment.PersonId);
            Persons = new ObservableCollection<PersonModel>() { };
            Persons.Add(personOfApartment);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}