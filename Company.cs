using System;
using System.Collections.Generic;
using System.Text;

namespace Planes
{
    class Company
    {
        public string Name { get; set; } // имя компании
        public int CountPeople { get; set; } // кол-во человек в штате

        public Company(string name, int countPeople)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException();
            }
            if (countPeople <= 0)
            {
                throw new ArgumentException();
            }

            Name = name;
            CountPeople = countPeople;
        }

        public override string ToString()
        {
            return $"Компания производитель: {Name}. Штат сотрудников: {CountPeople}";
        }
    }
}
