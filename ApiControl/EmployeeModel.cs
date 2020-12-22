using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAdminApp.ApiControl
{
    public class EmployeeModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public static explicit operator EmployeeModel(List<EmployeeModel> v)
        {
            throw new NotImplementedException();
        }
    }
}
