using System;
using System.Collections.Generic;
using System.Text;

namespace Planes
{
    class MilitaryController // для военного 
    {
        private List<MilitaryPlanes> militaries = new List<MilitaryPlanes>();

        private string[] militariesPurpose = new string[5] { "Штурмовик", "Истребитель", "Десантный", "Бомбардировщик", "БПЛА" };

        public MilitaryController(CompanyController companyController)
        {
            for(int i = 0; i < militariesPurpose.Length; i++)
            {
                List<Company> companys = companyController.GetCompanies();
                militaries.Add(new MilitaryPlanes($"BSM-180{i}", i + 5 * 35, companys[i], militariesPurpose[i]));
            }
        }

        
        public List<MilitaryPlanes> GetMilitaryPlanes()
        {
            return militaries;
        }

        /// <summary>
        /// Добавляет новый самолет
        /// </summary>
        /// <param name="name">Имя самолета</param>
        /// <param name="purpose">Военное назначение</param>
        /// <param name="companyName">Имя компнаии производителя</param>
        /// <param name="speed"> его скорость</param>
        /// <param name="companyController">Экземпляр класса контроллера компаний</param>
        public void AddMilitaryPlane(string name, string purpose, string companyName, int speed, CompanyController companyController)
        {
            if(companyController.AddCompany(companyName, 1)) // аналогично как и в CivilController
            {
                militaries.Add(new MilitaryPlanes(name, speed, companyController.GetCompanyByName(companyName), purpose));
            } else
            {
                militaries.Add(new MilitaryPlanes(name, speed, companyController.GetCompanyByName(companyName), purpose));
            }
        }
    }
}
