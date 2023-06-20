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
            //var kaio = employees.Single(e => e.FullName.Equals("Kaio")); // Como não existe a pessoa ou se existir mais de uma é lançada uma exception
            var kaioI = employees.SingleOrDefault(e => e.FullName.Equals("Kaio"));
            var luis = employees.SingleOrDefault(e => e.FullName.Equals("Luis"));
            var luisById = employees.SingleOrDefault(e => e.Id.Equals(1));
            var salary10000 = employees.First(e => e.Salary == 10_000m);
            //var salaryOver20000 = employees.First(e => e.Salary > 20_000m); lança exception
            var salaryOver20000 = employees.FirstOrDefault(e => e.Salary > 20_000m);
            var salaryGreater20000Any = employees.Any(e => e.Salary > 20_000m);
            var salaryGreaterOrEqual15000Any = employees.Any(e => e.Salary >= 15_000m);

            #region Console
            //Console.WriteLine(kaio);
            //Console.WriteLine(kaioI);
            //Console.WriteLine(luis);
            //Console.WriteLine(luisById);
            //Console.WriteLine(salary10000);
            //Console.WriteLine(salaryOver20000);
            //Console.WriteLine(salaryGreater20000Any);
            //Console.WriteLine(salaryGreaterOrEqual15000Any);
            #endregion

            //Projeção

            var names = employees.Select(e => e.FullName).ToList();

            var employeesViewModel = employees.Select(e => new EmployeeViewModel(e.Id, e.FullName, e.BusinessArea)).ToList();
           

            var AllInvoices = employees.SelectMany(e => e.Invoices).ToList();// usando SelectMany Linq
            //var invoices = new List<Invoice>();
            //foreach (var employee in employees) { invoices.AddRange(employee.Invoices); } //Usando ForEach

            #region Console
            //names.ForEach(Console.WriteLine);
            //employeesViewModel.ForEach(Console.WriteLine);
            // AllInvoices.ForEach(Console.WriteLine);
            #endregion

            //Ordenação
            var employeeOrderBySalary = employees.OrderBy(e => e.Salary).ToList();
            var employeeOrderByDescendingSalary = employees.OrderBy(e => e.Salary).ToList();

            var employeeOrderByAreaThenSalary = employees
                .OrderBy(e => e.BusinessArea)
                .ThenByDescending(e => e.Salary)
                .ToList();


            #region Console
            //employeeOrderBySalary.ForEach(Console.WriteLine);
            //employeeOrderByDescendingSalary.ForEach(Console.WriteLine);
            //employeeOrderByAreaThenSalary.ForEach(Console.WriteLine);
            #endregion



            //Agrupamento
            var employeeCountBusiness = employees
                .GroupBy(e => e.BusinessArea)
                .Select(g => new
                {
                    Department = g.Key,
                    Count = g.Count()
                })
                .ToList();

            var employeesOver10_000CountByArea = employees
                .GroupBy(e => e.BusinessArea)
                .Where(e => e.Count(e => e.Salary < 10_000m) > 0)
                .Select(d => new
                {
                    Department = d.Key,
                    Count = d.Count(e => e.Salary < 10_000m)
                })
                .ToList();

            var amountOfInvoices = employees 
                .GroupBy(i => i.Invoices.Count)
                .Select
                (  e => 
                   new
                   {  
                      Count = e.Key, 
                      Employees = e.Select(e => e.FullName).ToList() 
                   }
                )
                .ToList();

            #region Console
            //employeeCountBusiness.ForEach(Console.WriteLine);
            //employeesOver10_000CountByArea.ForEach(Console.WriteLine);
            //amountOfInvoices.ForEach(Console.WriteLine);
            #endregion

            //Junção
            var invoices = employees.SelectMany(e => e.Invoices).ToList();

            var innerJoin = employees.Join(invoices,
                employees => employees.Id,
                invoices => invoices.EmployeeId,
                (employees, invoices) =>
                 new
                 {
                     Name = employees.FullName,
                     Invoice = invoices.Amount,
                     InvoiceId = invoices.Id
                 })
                .ToList();// Sintaxe de método

            var innerJoinQuerySyntax =
                from employee in employees
                join invoice in invoices
                on employee.Id equals invoice.EmployeeId
                select new
                {
                    Name = employee.FullName,
                    Invoice = invoice.Amount,
                    InvoiceId = invoice.Id
                }; //Sintaxe de query

            var innerJoinQuerySyntaxResult = innerJoinQuerySyntax.ToList();


            var leftJoin = employees.GroupJoin(invoices,
                employees => employees.Id,
                invoices => invoices.EmployeeId,
                (employees, invoices) =>
                new
                {
                    Name = employees.FullName,
                    Invoices = invoices.ToList().Count()
                })
                .ToList();

            var leftJoinQuerySyntax =
                from employee in employees
                join invoice in invoices
                on employee.Id equals invoice.EmployeeId into tempInvoices
                select new
                {
                    Name = employee.FullName,
                    Invoices = tempInvoices.Count()
                };

            var leftJoinQuerySyntaxResult = leftJoinQuerySyntax.ToList();

            #region Console
            //innerJoin.ForEach(Console.WriteLine);
            // innerJoinQuerySyntaxResult.ForEach(Console.WriteLine);
            //leftJoin.ForEach(Console.WriteLine);
            leftJoinQuerySyntaxResult.ForEach(Console.WriteLine);
            #endregion

            Console.Read();
        }
    }  
  
}