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

        public PersonModel SelectedPerson { get; set; }
        public ApartmentModel SelectedApartment { get; set; }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public BuyApartmentCommand(IPersonService personService)
        {
            _personService = personService;
        }
        public bool CanExecute(object parameter)
        {
            return (this.SelectedApartment != null && this.SelectedPerson != null);
            //return true;
        }

        public void Execute(object parameter)
        {

            //Logic
            //SelectedPerson.id

            Buy(SelectedPerson.Id, SelectedApartment.Id);
            MessageBox.Show("Apartment was bought");
            //SelectedApartment.OnPropertyChanged();

        }

        public async Task Buy(int selectedPersonId, int selectedApartmentId)
        {
            await _personService.BuyApartment(selectedPersonId, selectedApartmentId);
        }
    }
}