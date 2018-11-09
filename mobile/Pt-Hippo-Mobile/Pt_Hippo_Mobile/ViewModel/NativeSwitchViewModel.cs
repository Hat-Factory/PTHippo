using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Pt_Hippo_Mobile
{
    class NativeSwitchViewModel : INotifyPropertyChanged

    {

        bool isSwitchOn;

        public bool IsSwitchOn

        {

            get { return isSwitchOn; }

            set

            {

                if (isSwitchOn != value)

                {

                    isSwitchOn = value;

                    OnPropertyChanged();

                }

            }

        }



        public event PropertyChangedEventHandler PropertyChanged;



        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)

        {

            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)

            {

                handler(this, new PropertyChangedEventArgs(propertyName));

            }

        }

    }

}
   