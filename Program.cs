namespace LinkLearnig
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Dados

            var employees = new List<Employee>
            {
               new Employee(1, "Luis", "TI", 10_000m, new List<Invoice>{new Invoice(1, "06/2023",1, 10_000m)}),
               new Employee(2, "Roberto","Marketing",15_000m, new List<Invoice>{new Invoice(2, "06/2023",2, 15_000m)}),
               new Employee(3, "Jesse","Support",8_200m, new List<Invoice>{new Invoice(3, "06/2023",3, 8_200m)}),
               new Employee(4, "Cassiano","Sales",12_000m, new List<Invoice>{new Invoice(4, "06/2023",4, 12_000m)}),
               new Employee(5, "Nathaly","HR",14_500m, new List<Invoice>{new Invoice(5, "06/2023",5, 15_500m)}),
               new Employee(6, "Gabriel","Marketing",15_500m, new List<Invoice>{new Invoice(6, "06/2023",6, 12_250m)}),
               new Employee(7, "Bruna","Sales",9_500m, new List<Invoice>{new Invoice(7, "06/2023",7, 11_200m)}),
               new Employee(8, "Gustavo","Support",7_000m, new List<Invoice>{new Invoice(8, "06/2023",8, 10_500m)}),
               new Employee(9, "Leandro","HR",15_000m, new List<Invoice>{ }),
               new Employee(10, "Lucas","TI",10_000m, new List<Invoice>{new Invoice(10, "06/2023",10, 10_500m), new Invoice(11, "07/2023", 10, 10_500m)})
            };
            #endregion



            //Filtragem
            var itEmployees = employees.Where(e => e.BusinessArea.Equals("TI")).ToList();
            var over10000SalaryEmployees = employees.Where(e => e.Salary > 10_000).ToList();
            var nonInvoiceEployees = employees.Where(e => !e.Invoices.Any()).ToList();

            #region Consoles
            // nonInvoiceEployees.ForEach(Console.WriteLine);
            //itEmployees.ForEach(Console.WriteLine);
            //over10000SalaryEmployees.ForEach(Console.WriteLine);

            #endregion

            //Busca
            var kaio = employees.Single(e => e.FullName.Equals("Kaio")); // Como não existe a pessoa é lançada uma exception
            //Console.WriteLine(kaio);

            //Projeção

            //Ordenação

            //Agrupamento



            Console.Read();
        }
    }  
  
}