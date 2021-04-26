using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using District.Bl.Abstract.IServices;
using District.Bl.Impl.Mappers;
using District.Models.Models;

namespace District.MVVM.Commands
{
    public class BuyApartmentCommand : ICommand
    {
        private readonly IPersonService _personService;

        private readonly PersonModel _selectedPerson;
        private readonly ApartmentModel _selectedApartment;

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public BuyApartmentCommand(IPersonService personService, PersonModel selectedPerson, ApartmentModel selectedApartment)
        {
            _personService = personService;
            _selectedPerson = selectedPerson;
            _selectedApartment = selectedApartment;
        }
        public bool CanExecute(object parameter)
        {
            return (this._selectedApartment != null && this._selectedPerson != null);
            //return true;
        }

        public void Execute(object parameter)
        {

            //Logic
            //SelectedPerson.id

            Buy(_selectedPerson.Id, _selectedApartment.Id);
            MessageBox.Show("Apartment was bought");
            

        }

        public async Task Buy(int selectedPersonId, int selectedApartmentId)
        {
            await _personService.BuyApartment(selectedPersonId, selectedApartmentId);
        }
    }
}