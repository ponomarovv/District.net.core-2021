using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace District.Models.Models
{
    public class ApartmentModel : INotifyPropertyChanged
    {
        private int _id;
        private int _buildingId;
        private int _apartmentNumber;

        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        public int BuildingId
        {
            get => _buildingId;
            set
            {
                _buildingId = value;
                OnPropertyChanged(nameof(BuildingId));
            } 
        }

        public int PersonId { get; set; }
        public int EntranceId { get; set; }
        public int SquareSize { get; set; }

        public int ApartmentNumber
        {
            get => _apartmentNumber;
            set
            {
                _apartmentNumber = value;
                OnPropertyChanged(nameof(ApartmentNumber));
            } 
        }

        public bool IsOwn { get; set; } = false;
        public DateTime? OrderDate { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
