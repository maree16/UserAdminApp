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
    public class EmployeeViewModel : EmployeeModel
    {

        private ObservableCollection<EmployeeModel> _employeeList = new ObservableCollection<EmployeeModel>();
        public ObservableCollection<EmployeeModel> EmployeeList
        {
            get { return _employeeList; }
            set { _employeeList = value; }
        }

        public EmployeeViewModel()
        {
            _employeeList = new ObservableCollection<EmployeeModel>();
            EmployeeList = new ObservableCollection<EmployeeModel>();
            this.EmployeeList.CollectionChanged += this.OnCollectionChanged;
            GetEmployee();
        }

        private async void GetEmployee()
        {
            //  ObservableCollection<EmployeeModel> employees = null;
            var employeeGroup = await EmployeeProcessor.LoadEmployee();
            foreach (EmployeeModel employee in employeeGroup)
            {
                EmployeeList.Add(employee);
            }

        }

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (EmployeeModel newItem in e.NewItems)
                {
                    // _employeeList.Add(newItem);
                    //Add listener for each item on PropertyChanged event
                    newItem.PropertyChanged += this.OnItemPropertyChanged;
                }
            }

            if (e.OldItems != null)
            {
                foreach (EmployeeModel oldItem in e.OldItems)
                {

                    //  _employeeList.Add(oldItem);

                    oldItem.PropertyChanged -= this.OnItemPropertyChanged;
                }
            }
        }

        void OnItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            EmployeeModel item = sender as EmployeeModel;
            if (item != null)
                _employeeList.Add(item);
        }

    }
}