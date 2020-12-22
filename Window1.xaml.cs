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
using Newtonsoft.Json;

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

        private async Task<ObservableCollection<EmployeeModel>> GetEmployee()
        {
            var employees = await EmployeeProcessor.LoadEmployee();


            return employees;


        }



        // Add loadingrow function In datagrid for that
        //void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        //{
        //    e.Row.Header = (e.Row.GetIndex()).ToString();
        //}

        private async void UpdateDataGrid()
        {
            MainDataGrid.ItemsSource = null;
            MainDataGrid.ItemsSource = await GetEmployee();

        }




        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            var first_Name = firstName_txtbox.Text;
             var last_Name = lastName_txtbox.Text;
            EmployeeModel p = new EmployeeModel { FirstName = first_Name, LastName = last_Name };

        
            this.AUD(p, 0, null);

        }

        private void Button_Click_Update(object sender, RoutedEventArgs e)
        {

            var first_Name = firstName_txtbox.Text;
            string id = employeeId_txtbox.Text;
            var last_Name = lastName_txtbox.Text;
            EmployeeModel p = new EmployeeModel { FirstName = first_Name , LastName = last_Name };

            //Tranform it to Json object
          
       
              this.AUD(p, 1, id);

        }
        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            string id = employeeId_txtbox.Text;

            this.AUD(null, 2, id);
        }
        private void Button_Click_Reset(object sender, RoutedEventArgs e)
        {
            this.resetAll();
        }
        private void resetAll()
        {
            employeeId_txtbox.Text = "";
            firstName_txtbox.Text = "";
            lastName_txtbox.Text = "";
      
            Add_btn.IsEnabled = true;
            Update_btn.IsEnabled = false;
            Delete_btn.IsEnabled = false;
        }

        private void reset_btn_Click(object sender, RoutedEventArgs e)
        {
            this.resetAll();
        }

        private  void AUD(EmployeeModel statement, int state, string id)
        {
            String msg = "";


           
            switch (state)
            {
                case 0:
                    msg = "Row Inserted Successfully!";
                    OrganizationMethods.PostMethod(statement);
                    this.resetAll();
                    break;
                case 1:
                    msg = "Row Updated Successfully!";
                    OrganizationMethods.PutMethod(statement,id);
                    this.resetAll();
                    break;
                case 2:
                    msg = "Row Deleted Successfully!";
                    OrganizationMethods.DeleteMethod(id);
                    this.resetAll();
                    break;

            }
                    MessageBox.Show(msg);
            this.UpdateDataGrid();
        
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.UpdateDataGrid();
        }
    }
}