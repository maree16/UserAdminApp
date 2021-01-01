using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAdminApp.ApiControl;

namespace UserAdminApp.Apis
{
    public class OrganizationViewModel : OrganizationModel
    {

        private ObservableCollection<OrganizationModel> _organizationList = new ObservableCollection<OrganizationModel>();
        public ObservableCollection<OrganizationModel> OrganizationList
        {
            get { return _organizationList; }
            set { _organizationList = value; }
        }

        public OrganizationViewModel()
        {
            _organizationList = new ObservableCollection<OrganizationModel>();
            OrganizationList = new ObservableCollection<OrganizationModel>();
            this.OrganizationList.CollectionChanged += this.OnCollectionChanged;
            GetOrganization();
        }

        private async void GetOrganization()
        {
            //  ObservableCollection<OrganizationModel> organizations = null;
            var organizationg = await OrganizationProcessor.LoadOrganization();
            foreach (OrganizationModel orga in organizationg)
            {
                OrganizationList.Add(orga);
            }

        }

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (OrganizationModel newItem in e.NewItems)
                {
                   // _organizationList.Add(newItem);
                    //Add listener for each item on PropertyChanged event
                    newItem.PropertyChanged += this.OnItemPropertyChanged;
                }
            }

            if (e.OldItems != null)
            {
                foreach (OrganizationModel oldItem in e.OldItems)
                {

                  //  _organizationList.Add(oldItem);

                    oldItem.PropertyChanged -= this.OnItemPropertyChanged;
                }
            }
        }

        void OnItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OrganizationModel item = sender as OrganizationModel;
            if (item != null)
                _organizationList.Add(item);
        }

    }
}