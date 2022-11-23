using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayRoll
{
    public class EmployeeDetails
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string PhoneNumber { get; set; }
        public EmployeeDetails (int emloyeeId,string employeeName,string phonenumber)
        {
            EmployeeId = emloyeeId;
            employeeName = employeeName;
            PhoneNumber = phonenumber;
        }
    }
}
