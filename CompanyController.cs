using System;
using System.Collections.Generic;
using System.Text;

namespace Planes
{
    class CompanyController
    {
        private List<Company> companys = new List<Company>(); // показываем список. он приватный 

        private string[] planesCompany = new string[5] { "Airbus", "Boeing", "Chesterfields", "CoM", "OAK" }; // статические данные

        public CompanyController() 
        {
            for(int i = 0; i < planesCompany.Length; i++)  
            {
                companys.Add(new Company(planesCompany[i], i + 5 * 6));
            }
        }

        /// <summary>
        /// Получает экземпляр класса Company по имени
        /// </summary>
        /// <param name="name">Имя компании</param>
        /// <returns>Экземпляр класса Company или null, если его нет</returns>
        public Company GetCompanyByName(string name)
        {
            foreach(var item_company in companys)
            {
                if (item_company.Name == name) return item_company; 
                
            }

            return null;
        }

        /// <summary>
        /// Добавляет в список новый экзеспляр класса КОМПАНИ
        /// </summary>
        /// <param name="name">Имя компании</param>
        /// <param name="countPeople">Штат, кол-во сотрудников</param>
        /// <returns> Возвращает ИСТИНУ, если компании нет и она создалась. Иначе Ложь, если компания с таким именем уже существует </returns>
        public bool AddCompany(string name, int countPeople) 
        {
            foreach(var item_company in companys)
            {
                if (item_company.Name == name) return false;
            }

            companys.Add(new Company(name, countPeople));
            return true;
        }


        
        public List<Company> GetCompanies()
        {
            return companys; 
        }
    }
}
