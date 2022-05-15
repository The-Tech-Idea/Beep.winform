using System.Collections.Generic;
using System.ComponentModel;

namespace KOC.DHUB3.Models
{


    public class clsLocation : INotifyPropertyChanged
    {
        public double _latitude;
        public double Latitude
        {
            get
            {
                return _latitude;
            }
            set
            {
                SetField(ref _latitude, value, "Latitude");
            }
        }

        public double _longitude;
        public double Longitude
        {
            get
            {
                return _longitude;
            }
            set
            {
                SetField(ref _longitude, value, "Longitude");
            }
        }

        public string _id;
        public string ID
        {
            get
            {
                return _id;
            }
            set
            {
                SetField(ref _id, value, "ID");
            }
        }

        public clsLocation()
        {
        }

        public clsLocation(double latititude, double longitude, string id = "")
        {
            Latitude = latititude;
            Longitude = longitude;
            ID = id;
        }


        // boiler-plate
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        protected bool SetField<T>(ref T field, T value, string propertyName)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
            {
                return false;
            }
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}