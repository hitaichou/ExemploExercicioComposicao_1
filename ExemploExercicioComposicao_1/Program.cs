using System;
using System.Globalization;
using ExemploExercicioComposicao_1.Entities.Enums;
using ExemploExercicioComposicao_1.Entities;

namespace ExemploExercicioComposicao_1
{
    /*
     * Ler os dados de um trabalhador com N contratos (N fornecido pelo usuário). Depois, solicitar
       do usuário um mês e mostrar qual foi o salário do funcionário nesse mês
     */
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Entre com o nome do departamento: ");
            string deptName = Console.ReadLine();
            Console.WriteLine("Entre com os dados do trabalhador:");
            Console.Write("Entre com o nome do trabalhador: ");
            string name = Console.ReadLine();
            Console.Write("Nível (Junior/MidLevel/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine()); //conversão do texto para o tipo enum
            Console.Write("Salário Base: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            //Instancias
            Department dept = new Department(deptName);
            Worker worker = new Worker(name, level, baseSalary, dept);

            Console.Write("Quantos contratos para este trabalhador? ");
            int n = int.Parse(Console.ReadLine());
            for(int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Entre com dado do contrato #{i}: ");
                Console.Write("Data (dd/mm/yyyy): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Valor por hora: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duração da hora: ");
                int hours = int.Parse(Console.ReadLine());
                //instanciando o contrato
                HourContract contract = new HourContract(date, valuePerHour, hours);
                //Adicionando Contrato 
                worker.AddContract(contract);
            }
            Console.WriteLine("");
            Console.Write("Entre com o mês e ano para calcular o ganho (MM/YYYY): ");
            string monthAndYear = Console.ReadLine();
            //Recortando o dado
            int month = int.Parse(monthAndYear.Substring(0, 2));
            int year = int.Parse(monthAndYear.Substring(3));
            Console.WriteLine("Name: " + worker.Name);
            Console.WriteLine("Department: " + worker.Department.Name);
            Console.WriteLine("Income for : " +monthAndYear + ": " + worker.Income(year, month).ToString("F2"));
        }
    }
}
