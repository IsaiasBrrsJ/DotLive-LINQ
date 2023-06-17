using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkLearnig
{
    public class Invoice
    {
        public Invoice(int id, string referenceMonthYear, int employeeId, decimal amount)
        {
            Id = id;
            ReferenceMonthYear = referenceMonthYear;
            EmployeeId = employeeId;
            Amount = amount;

            GenerateAt = DateTime.Now;
        }

        public int Id { get; set; }
        public string ReferenceMonthYear { get; private set; } = string.Empty;
        public int EmployeeId { get; set; }
        public decimal Amount { get; set; }

        public DateTime GenerateAt { get; private set; }

        public override string ToString()
        {
            return $"\nInvoices--\nId: {Id}\nReferenceMonthYear: {ReferenceMonthYear}\nEmployeeId: {EmployeeId}\nAmount: {Amount}\nGeneratAt: {GenerateAt}";
        }

    }
}
