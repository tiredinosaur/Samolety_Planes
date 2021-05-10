using System;
using System.Collections.Generic;
using System.Text;

namespace Planes
{
    class CivilPlanes // гражданский самолет
    {
        public string Name { get; set; } // имя самолета
        public int Capacity { get; set; } // количество мест в самолете
        public int Speed { get; set; } // его скорость 
        public Company Company { get; set; } // экземпляр класса  
        public string Appointment { get; set; } // предназначение самолета

        public CivilPlanes(string name, Company company)
        {
            if (string.IsNullOrEmpty(name)) // проверка строки на пустоты
            {
                throw new ArgumentException();
            }

            Name = name; 
            Company = company ?? throw new ArgumentException();
            Capacity = 1;
            Speed = 1;
            Appointment = "нет";
        }
        public CivilPlanes(string name, Company company, int capacity, int speed, string appointment) : this(name, company) // перезагрузка конструктора со ссылкой на предыдущий
        {
            if(capacity <= 0)
            {
                throw new ArgumentException();
            }
            if (speed <= 0)
            {
                throw new ArgumentException();
            }
            if (string.IsNullOrEmpty(appointment))
            {
                throw new ArgumentException();
            }

            Capacity = capacity;
            Speed = speed;
            Appointment = appointment;
        }

        public override string ToString() // При передачи класса в метод WriteLine вызывается данный
        { 
            return $"Гражданский самолет {Name}, имеющий вместимость: {Capacity}, скорость: {Speed} км/ч. Производства компании: {Company.Name}. Предназначение: {Appointment}.";
        }
    }
}
