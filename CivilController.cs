using System;
using System.Collections.Generic;
using System.Text;

namespace Planes
{
    class CivilController // для гражданского 
    {
        private List<CivilPlanes> planes = new List<CivilPlanes>();

        private string[] planesAppointment = new string[5] { "Пассажирский", "Транспортный", "Сельскохозяйственный", "Спортивный", "Пожарный" }; // статические данные снова 

        public CivilController(CompanyController companyController)
        {
            for(int i = 0; i < planesAppointment.Length; i++) 
            {
                List<Company> companys = companyController.GetCompanies();
                planes.Add(new CivilPlanes($"BH-12{i}", companys[i], i + 5*6, i+20*4, planesAppointment[i]));
            }
        }


       
        public List<CivilPlanes> GetCivilPlanes()
        {
            return planes;
        }

       
        public void AddPlane(string nameCivil, string appointment, string companyNameCivil, int speed, int capacity, CompanyController companyController)
        {
            if (companyController.AddCompany(companyNameCivil, 1)) // вот этот метод проверяет наличие компании в базе, если ее нет создает и возвращает истину, иначе фолз
            {
                planes.Add(new CivilPlanes(nameCivil, companyController.GetCompanyByName(companyNameCivil), capacity, speed, appointment));
            }
            else
            {
                planes.Add(new CivilPlanes(nameCivil, companyController.GetCompanyByName(companyNameCivil), capacity, speed, appointment));
            }
        }
    }
}
