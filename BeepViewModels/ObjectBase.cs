using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Beep.ViewModels
{
    public class ObjectBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(propertyName, true);
        }

        protected virtual void OnPropertyChanged(string propertyName, bool makeDirty)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

            if (makeDirty)
                _IsDirty = true;
        }


        bool _IsDirty=false;

        public bool IsDirty
        {
            get { return _IsDirty; }
        }

    }
}
