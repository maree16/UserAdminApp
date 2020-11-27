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
using System.Windows.Shapes;

namespace UserAdminApp
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        Employee employee = new Employee { FirstName = "Salman", LastName = "Ahmad" };

        public Window1()
        {
            InitializeComponent();
            this.DataContext = employee;

        }






        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string message = employee.FirstName + employee.LastName;
            MessageBox.Show(message);
        }


        public class Employee
        {

            private string firstName;

            public string FirstName
            {
                get { return firstName; }
                set
                {
                    if (value != firstName)
                    {
                        firstName = value;
                    }
                }
            }

            private string lastName;

            public string LastName
            {
                get { return lastName; }
                set {
                    if (value != lastName)
                    {
                        lastName = value;
                    }
                }

            }

        }

    }
} 