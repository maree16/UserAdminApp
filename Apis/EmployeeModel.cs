using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAdminApp.ApiControl
{
    public class EmployeeModel : INotifyPropertyChanged
    {

        private string _id;

        public string Id
        {
            get { return _id; }
            set
            {
                _id = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged(_id);
            }
        }

        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (_firstName != value)
                    _firstName = value;
                // Call OnPropertyChanged whenever the property is updated

                OnPropertyChanged(_firstName);
            }
        }

        private string _lastName;

        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (_lastName != value)

                    _lastName = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged(_lastName);
            }
        }
// Declare the event
        public event PropertyChangedEventHandler PropertyChanged;

        // Propetychanged event
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}