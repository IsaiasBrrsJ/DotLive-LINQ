using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkLearnig
{
    public class Employee
    {
       
        public Employee(int id, string fullName, string businessArea, decimal salary, List<Invoice> invoices)
        {
            Id = id;
            FullName = fullName;
            BusinessArea = businessArea;
            Salary = salary;
            Invoices = invoices;
        }

        public int Id { get; set; }
        public string FullName { get; set; } = String.Empty;
        public string BusinessArea { get; set; } = String.Empty;
        public decimal Salary { get; private set; }
        public List<Invoice> Invoices { get; set; } = default!;


    }
}
