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
        private int _personId;
        private int _entranceId;
        private int _squareSize;
        private DateTime? _orderDate;
        private bool _isOwn = false;

        public ApartmentModel()
        {
            IsOwn = false;
        }
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

        public int PersonId
        {
            get => _personId;
            set
            {
                _personId = value;
                OnPropertyChanged(nameof(PersonId));
            }

        }

        public int EntranceId
        {
            get => _entranceId;
            set
            {
                _entranceId = value;
                OnPropertyChanged(nameof(EntranceId));

            }
        }

        public int SquareSize
        {
            get => _squareSize;
            set
            {
                _squareSize = value;
                OnPropertyChanged(nameof(SquareSize));

            }
        }

        public int ApartmentNumber
        {
            get => _apartmentNumber;
            set
            {
                _apartmentNumber = value;
                OnPropertyChanged(nameof(ApartmentNumber));
            }
        }

        public bool IsOwn
        {
            get => _isOwn;
            set
            {
                _isOwn = value;
                OnPropertyChanged(nameof(IsOwn));
            }
        }

        public DateTime? OrderDate
        {
            get => _orderDate;
            set
            {
                _orderDate = value;
                OnPropertyChanged(nameof(OrderDate));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
