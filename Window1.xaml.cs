using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Configuration;
using UserAdminApp.ApiControl;
using System.Collections.ObjectModel;

namespace UserAdminApp
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {

        public Window1()
        {
        
            InitializeComponent();
            ApiHelper.InitializeClient();


        }

        private async void GetEmployee(object sender, RoutedEventArgs e)
        {
           List<EmployeeModel> employees = await EmployeeProcessor.LoadEmployee();

            MainDataGrid.ItemsSource = employees;


        }



        // Add loadingrow function In datagrid for that
        //void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        //{
        //    e.Row.Header = (e.Row.GetIndex()).ToString();
        //}

        //private void UpdateDataGrid()
        //{
        //    DataTable dt = new DataTable();
        //    ObservableCollection<Employee> employees = new ObservableCollection<Employee>(); 
        //    employees.Add(new Employee() { FirstName = "John", LastName = " Doe", });
        //    employees.Add(new Employee() { FirstName = "Jane", LastName = " Doe", });
        //    employees.Add(new Employee() { FirstName = "Sammy", LastName = " Doe", });


        //    MainDataGrid.ItemsSource = employees;

        //}


    

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_Update(object sender, RoutedEventArgs e)
        {

        }
        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {

        }
        private void Button_Click_Reset(object sender, RoutedEventArgs e)
        {

        }

        private void AUD(string statement, int state)
        {
            //String Message = '';
        }

    

   

        private void MainDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;

            MessageBox.Show("SelectionChanged event happened!");

            DataGridRow dr = dg.SelectedItem as DataGridRow;

            EmployeeModel employee = (EmployeeModel)dg.SelectedItem;
            if (employee != null)
            {

                employeeId_txtbox.Text = employee.Id.ToString();

                firstName_txtbox.Text = employee.FirstName.ToString();
                        lastName_txtbox.Text = employee.LastName.ToString();

                Add_btn.IsEnabled = false;
                Update_btn.IsEnabled = true;
                Delete_btn.IsEnabled = true;

            }
        }


    }
}