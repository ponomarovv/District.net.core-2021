using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using District.Models.Annotations;

namespace District.Models.Models
{
    public class BuildingModel : INotifyPropertyChanged
    {
        private int _buildingNumber;
        private string _street = "Street";
        private int _id;

        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged(nameof(BuildingNumber));
            }
        }
        //public List<Apartment> Apartments { get; set; }

        public string Street
        {
            get => _street;
            set
            {
                _street = value;
                OnPropertyChanged(nameof(BuildingNumber));
            }
        }

        public int BuildingNumber
        {
            get => _buildingNumber;
            set
            {
                _buildingNumber = value;
                OnPropertyChanged(nameof(BuildingNumber));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
