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
    public class OrganizationModel : INotifyPropertyChanged
    {
 
        private string _id;

        public string Id {
            get { return _id; }
            set {
                _id = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged(_id);
            }
        }

        private string _organizationName;

        public string OrganizationName
        {
            get { return _organizationName; }
            set
            {
                if ( _organizationName != value )
                _organizationName = value;
                // Call OnPropertyChanged whenever the property is updated

                OnPropertyChanged(_organizationName);
            }
        }

        private string _organizationUrl;

        public string OrganizationUrl
        {
            get { return _organizationUrl; }
            set
            {
                if (_organizationUrl != value)

                    _organizationUrl = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged(_organizationUrl);
            }
        }


        private string _organizationType;

        public string OrganizationType
        {
            get { return _organizationType; }
            set
            {
                if (_organizationType != value)

                    _organizationType = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged(_organizationType);
            }
        }


        private int _organizationRegistrationNumber;

        public int OrganizationRegistrationNumber
        {
            get { return _organizationRegistrationNumber; }
            set
            {
                if (_organizationRegistrationNumber != value)

                    _organizationRegistrationNumber = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("_organizationRegistrationNumber");
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