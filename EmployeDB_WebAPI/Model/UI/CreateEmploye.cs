using EmployesDB.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployesDB.UI
{
    public static class CreateEmploye
    {
        public static Employe Create()
        {
            Console.Write("Введите имя и нажмите Emter: ");
            string name = Console.ReadLine();
            Console.Write("Введите фамилию и нажмите Emter: ");
            string surname = Console.ReadLine();
            Console.Write("Введите возраст (от 19 до 69 лет)и нажмите Emter: ");
            byte age;
            byte.TryParse(Console.ReadLine(), out age);
            Console.WriteLine("Выбериете департамент: \n 1. IT\n 2.Маркетинг\n 3.Бухгалтерия\n 4.Инженерный\n 5.Правление");
            Department department;
            char choose = Console.ReadKey().KeyChar;
            switch (choose)
            {
                case '1':
                    department = Department.IT;
                    break;
                case '2':
                    department = Department.Marketing;
                    break;
                case '3':
                    department = Department.Financial;
                    break;
                case '4':
                    department = Department.Engineering;
                    break;
                case '5':
                default:
                    department = Department.Managment;
                    break;
            }
            Console.WriteLine("Введите номер телефона(10 цифр):");
            string phoneNumber = Console.ReadLine();
            Console.WriteLine("Введите зарплату:");
            int salary;
            Int32.TryParse(Console.ReadLine(), out salary);

            return new Employe(name, surname, age, department, phoneNumber, salary);
        }
    }
}
