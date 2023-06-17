namespace LinkLearnig
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var employees = new List<Employee>
            {
               new Employee(1, "Luis", "TI", 10_000m, new List<Invoice>{new Invoice(1, "06/2023",1, 30_000m)}),
               new Employee(2, "Roberto","Marketing",15_000m, new List<Invoice>{new Invoice(2, "06/2023",2, 30_000m)}),
               new Employee(3, "Jesse","Support",8_200m, new List<Invoice>{new Invoice(3, "06/2023",3, 30_000m)}),
               new Employee(4, "Cassiano","Sales",12_000m, new List<Invoice>{new Invoice(4, "06/2023",4, 30_000m)}),
               new Employee(5, "Nathaly","HR",14_500m, new List<Invoice>{new Invoice(5, "06/2023",5, 30_000m)}),
               new Employee(6, "Gabriel","Marketing",15_500m, new List<Invoice>{new Invoice(6, "06/2023",6, 30_000m)}),
               new Employee(7, "Bruna","Sales",9_500m, new List<Invoice>{new Invoice(7, "06/2023",7, 30_000m)}),
               new Employee(8, "Gustavo","Support",7_000m, new List<Invoice>{new Invoice(8, "06/2023",8, 30_000m)}),
               new Employee(9, "Leandro","HR",15_000m, new List<Invoice>{ }),
               new Employee(10, "Lucas","TI",10_000m, new List<Invoice>{new Invoice(10, "06/2023",10, 30_000m)})
            };


        }
    }  
  
}