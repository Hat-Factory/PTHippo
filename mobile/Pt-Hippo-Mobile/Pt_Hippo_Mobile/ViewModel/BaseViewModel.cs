using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Pt_Hippo_Mobile.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged  

    {

        #region INotifyPropertyChanged implementation



        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler CanExecuteChanged;



        #endregion



        protected virtual void OnPropertyChanged(string propertyName)

        {

            if (PropertyChanged != null)

            {

                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

            }

        }
        protected virtual void OnPropertyChangedEventhander([CallerMemberName] string PropertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
            }
        }

        protected bool ChangeAndNotify<T>(ref T property, T value, [CallerMemberName] string propertyName = "")
        {
            if (!EqualityComparer<T>.Default.Equals(property, value))
            {
                property = value;
                OnPropertyChangedEventhander(propertyName);
                return true;
            }


            return false;
        }

        public BaseViewModel()
        {

        }

    }
}
