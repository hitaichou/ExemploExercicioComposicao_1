using System;

namespace ExemploExercicioComposicao_1.Entities
{
    class HourContract
    {
        //Declaração das propriedades
        public DateTime Date { get; set; }
        public double ValuePerHour { get; set; }
        public int Hours { get; set; }

        public HourContract()
        {

        }

        public HourContract(DateTime date, double valuePerHour, int hour)
        {
            Date = date;
            ValuePerHour = valuePerHour;
            Hours = hour;
        }

        public double TotalValue()
        {
            return Hours * ValuePerHour; //retorna o calculo da hora
        }
    }
}
