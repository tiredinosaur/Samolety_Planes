using System;
using System.Collections.Generic;
using System.Text;

namespace Planes
{
    class MilitaryPlanes // тут уже с военным самолетом
    {
        public string Name { get; set; } 
        public int Speed { get; set; } 
        public Company Company { get; set; } 
        public string Purpose { get; set; } 

        public MilitaryPlanes(string name, int speed, Company company)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException();
            }
            if (speed <= 0) // скорость не может быть меньше или равна нулю
            {
                throw new ArgumentException();
            }


            Name = name;
            Speed = speed;
            Company = company ?? throw new ArgumentException();
            Purpose = "нет";
        }
        public MilitaryPlanes(string name, int speed, Company company, string purpose) : this(name, speed, company) // перегрузка конструктора
        {
           
            if (string.IsNullOrEmpty(purpose))
            {
                throw new ArgumentException();
            }

            Purpose = purpose;
        }

        public override string ToString()
        {
            return $"Военные самолет {Name}. Со скоростью: {Speed} км/ч. Производство компанией: {Company.Name}. Вид: {Purpose}";
        }
    }
}
