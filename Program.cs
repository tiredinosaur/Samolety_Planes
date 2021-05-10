using System;

namespace Planes
{
    class Program
    {
        static CompanyController CompanyController; // static - это статичное поле, поля класса-контроллеры вынесены для того, чтобы получить доступ к ним из любого метода
        static CivilController CivilController;
        static MilitaryController MilitaryController;

        static void Main(string[] args)
        {
            CompanyController = new CompanyController(); //инициализируем контроллеры
            CivilController = new CivilController(CompanyController);
            MilitaryController = new MilitaryController(CompanyController);

            while(true)
            {
                Menu(); // в бесконечном цикле вызываем функцию меню
            }
        }

        private static void Menu()
        {
            Console.WriteLine(); // пишем что нужно делать пользователю
            Console.WriteLine("\t Введите 'showCompany', чтобы просмотреть все компании производители самолетов \t");
            Console.WriteLine("\t Введите 'showPlanes', чтобы просмотреть все самолеты в базе \t");
            Console.WriteLine();
            Console.WriteLine("\t Введите 'addCompany', чтобы добавить компанию производителя \t");
            Console.WriteLine("\t Введите 'addPlanes', чтобы добавить самолет в базу \t");
            Console.WriteLine();

            switch(Console.ReadLine().ToLower()) // читает что пользователь (т.е Я там на калякал) 
            {
                case "showcompany": 
                    ShowCompany();
                    break;
                case "showplanes":
                    ShowPlanes();
                    break;
                case "addcompany":
                    AddCompany();
                    break;
                case "addplanes":
                    AddPlanes();
                    break;
                default:
                    Console.WriteLine();
                    Console.WriteLine("Такой команды не существует (Посмотрите список существующих команд)");
                    break;
            }
        }

        private static void AddPlanes() // тут добавляет самолет очевидно 
        {
            Error: 
            Console.WriteLine("Какой самолет вы хотите добавить? (введите категорию самолета 'военный' либо 'гражданский' ");
            switch (Console.ReadLine().ToLower())
            {
                case "военный":

                    Console.WriteLine("Модель самолета:");
                    string nameMilitary = Console.ReadLine(); 
                    Console.WriteLine("Назначение боевой единицы (штурмовик, истребитель и т.п.):");
                    string purpose = Console.ReadLine();
                    Console.WriteLine("Введите имя компании производителя:");
                    string companyNameMilitary = Console.ReadLine();

                    ErrorIntMilitary: 
                    Console.WriteLine("Введите скорость самолета:");
                    try
                    { 
                        int speed = Convert.ToInt32(Console.ReadLine()); // Проверяется возможность конвертации данных в тип ИНТа

                        MilitaryController.AddMilitaryPlane(nameMilitary, purpose, companyNameMilitary, speed, CompanyController); 
                        // Вызываем метод добавления военного самолета
                    } 
                    catch
                    {
                        Console.WriteLine("Введите корректные данные");
                        goto ErrorIntMilitary; // Если написал неправильные данные возвращает
                    }

                    break;
                case "гражданский":
                    Console.WriteLine("Модель самолета:");
                    string nameCivil = Console.ReadLine();
                    Console.WriteLine("Назначение самолета:");
                    string appointment = Console.ReadLine();
                    Console.WriteLine("Введите имя компании производителя:");
                    string companyNameCivil = Console.ReadLine();

                    ErrorIntCivil:
                    try
                    {
                        Console.WriteLine("Введите скорость самолета:");
                        int speed = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите кол-во пассажиров:");
                        int capacity = Convert.ToInt32(Console.ReadLine());

                        CivilController.AddPlane(nameCivil, appointment, companyNameCivil, speed, capacity, CompanyController);
                    } 
                    catch
                    {
                        Console.WriteLine("Введите корректные данные");
                        goto ErrorIntCivil;
                    }

                    break;
                default:
                    Console.WriteLine("Извините, попробуйте еще раз. (Проверьте правописание)");
                    goto Error;
            }
        }

        private static void AddCompany()
        {
            Console.WriteLine("Введите название компании производителя:");
            string name = Console.ReadLine();

            ErrorInt:
            Console.WriteLine("Введите кол-во штата сотрудников:");
            try 
            {
                int countPeople = Convert.ToInt32(Console.ReadLine());
                CompanyController.AddCompany(name, countPeople);
            } 
            catch
            {
                Console.WriteLine("Введите корректные данные");
                goto ErrorInt;
            }
            
        }

        private static void ShowPlanes()
        {
            Error:
            Console.WriteLine("Какие самолеты вы хотите отобразить? (введите категорию самолета 'военные' либо 'гражданские' ");
            Console.WriteLine();
            switch (Console.ReadLine().ToLower())
            {
                case "военные":
                    Console.WriteLine();
                    foreach (var item_militaryPlanes in MilitaryController.GetMilitaryPlanes()) 

                    {
                        Console.WriteLine(item_militaryPlanes); // у класса Милитаристринг есть метод ТуСтринг, который и вызывается
                    }
                    Console.WriteLine();
                    break;
                case "гражданские":
                    Console.WriteLine();
                    foreach (var item_civilPlanes in CivilController.GetCivilPlanes()) 
                    {
                        Console.WriteLine(item_civilPlanes);
                    }
                    Console.WriteLine();
                    break;
                default:
                    Console.WriteLine("Извините, попробуйте еще раз. (Проверьте правописание)");
                    goto Error;
            }
        }

        private static void ShowCompany()
        {
            Console.WriteLine();
            Console.WriteLine("Компании в базе:");
            Console.WriteLine();
            foreach (var item_company in CompanyController.GetCompanies()) 
            {
                Console.WriteLine(item_company);
            }
            Console.WriteLine();
        }
    }
}
