using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayRoll
{
    public class EmployeePayRollOperation
    {
        public List<EmployeeDetails> employeePayrollDetailList = new List<EmployeeDetails>();
        public void addEmployeeToPayRoll(List<EmployeeDetails> employeePayrollDetailList)
        {
            employeePayrollDetailList.ForEach(employeeData =>
            {
                Console.WriteLine("Employee being added: " + employeeData.EmployeeName);
                this.addEmployeePayRoll(employeeData);
                Console.WriteLine("Employee Added: " + employeeData.EmployeeName);

            }
            );
            Console.WriteLine(this.employeePayrollDetailList.ToString());
        }
        public void addEmloyeeToPayrollWithThread(List<EmployeeDetails> employeePayrollDetailList)
        {
            employeePayrollDetailList.ForEach(emloyeeData =>
            {
                Task thread = new Task(() =>
                {
                   Console.WriteLine("Emloyee being addded: " + emloyeeData.EmployeeName);
                    this.addEmployeePayRoll(emloyeeData);
                    Console.WriteLine("Employee added: " + emloyeeData.EmployeeName);
                });
                thread.Start();
            });
            Console.WriteLine(this.employeePayrollDetailList.Count());
        }
        public void addEmployeePayRoll(EmployeeDetails emp)
        {
            employeePayrollDetailList.Add(emp);
        }
        public int EmloyeeCount()
        {
            return this.employeePayrollDetailList.Count();
        }
    }
}
