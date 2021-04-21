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
    public class EntranceModel : INotifyPropertyChanged
    {
        private int _entranceNumber;
        private int _id;
        private int _buildingId;

        public int Id
        {
            get => _id;
            set
            {
                 _id = value;
                 OnPropertyChanged(nameof(Id));
            }
        }

        public int EntranceNumber
        {
            get => _entranceNumber;
            set
            {
                _entranceNumber = value;
                OnPropertyChanged(nameof(EntranceNumber));
            }
        }
        //public Building Building { get; private set; }

        public int BuildingId
        {
            get => _buildingId;
            set
            {
                 _buildingId = value;
                 OnPropertyChanged(nameof(BuildingId));
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
