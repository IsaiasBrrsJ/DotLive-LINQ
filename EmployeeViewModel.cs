using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkLearnig
{
    public class EmployeeViewModel
    {
        public EmployeeViewModel(int id, string fullName, string businessArea)
        {
            Id = id;
            FullName = fullName;
            BusinessArea = businessArea;
        }

        public int Id { get; set; }

        public string FullName { get; set; } = String.Empty;

        public string BusinessArea { get; set; } = String.Empty;

        public override string ToString()
        {
            return $"Id: {Id}\nFullName: {FullName}\nBussinessArea: {BusinessArea}\n";
        }
    }
}
