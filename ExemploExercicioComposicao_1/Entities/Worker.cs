using ExemploExercicioComposicao_1.Entities.Enums;
using System.Collections.Generic;

namespace ExemploExercicioComposicao_1.Entities
{
    class Worker
    {
        public string Name { get; set; }
        public WorkerLevel Level { get; set; }
        public double BaseSalary { get; set; }
        //Composição de objeto
        public Department Department { get; set; }
        //Associação de objeto
        //um trabalho por ter vários contratos, por isso está sendo usado a lista
        //Instancia a lista para não ser nula
        public List<HourContract> Contracts { get; set; } = new List<HourContract>();

        public Worker()
        {

        }
        //Geralmente não se adiciona no contrutor o parâmetro do tipo lista
        //Pois isso será adicionado conforme necessidade
        public Worker(string name, WorkerLevel level, double baseSalary, Department department)
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Department = department;
        }

        //Método Adicionar Contrato
        public void AddContract(HourContract contract)
        {
            Contracts.Add(contract);
        }
        //Método Remove Contrato
        public void RemoveContract(HourContract contract)
        {
            Contracts.Remove(contract);
        }
        //Método Ganho no ano/mÊs
        public double Income(int year, int month)
        {
            double sum = BaseSalary;
            foreach(HourContract contract in Contracts)
            {
                if (contract.Date.Year == year && contract.Date.Month == month)
                {
                    //sum = sum + contract.TotalValue();
                    sum += contract.TotalValue(); 
                }
            }
            return sum;
        }

    }
}
