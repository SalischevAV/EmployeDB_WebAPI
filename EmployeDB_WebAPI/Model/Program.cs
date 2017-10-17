using EmployesDB.DB;
using EmployesDB.Enums;
using EmployesDB.Logic;
using EmployesDB.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployesDB
{
    class Program
    {

        static void Main(string[] args)
        {
            List<Employe> plant = new List<Employe>();
            //plant.Add(new Employe { Name = "aa", Surname = "bg", Age = 23, Department = Department.IT, PhoneNumber = "1234567890", Salary = 600 });
            //plant.Add(new Employe { Name = "ab", Surname = "bh", Age = 24, Department = Department.Managment, PhoneNumber = "1234567890", Salary = 600 });
            //plant.Add(new Employe { Name = "ac", Surname = "bj", Age = 25, Department = Department.Financial, PhoneNumber = "1234567890", Salary = 600 });
            //plant.Add(new Employe { Name = "ad", Surname = "bk", Age = 23, Department = Department.Marketing, PhoneNumber = "1234567890", Salary = 600 });
            //plant.Add(new Employe { Name = "ae", Surname = "bb", Age = 23, Department = Department.IT, PhoneNumber = "1234567890", Salary = 600 });
            Saver sv = new Saver(plant);

            plant = sv.Loader();//error here



            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Plant! \n");
                PrinterCollections.PrintCollection(plant);
                Console.WriteLine("Available commands:");
                Console.WriteLine("- View list of employes: View.");
                Console.WriteLine("- Add\\ Remove employe : CRUT.");
                Console.WriteLine("- Exit \n");
                Console.Write("Enter command: ");

                string commands = Console.ReadLine();

                if (commands.ToLower() == "exit")
                {
                    sv.Unloader();
                    //ExitOperations();
                    Console.ReadKey();
                    return;
                }
                if (commands.ToLower() == "view")
                {
                    ViewOperations(plant);
                    continue;
                }
                if (commands.ToLower() == "crut")
                {
                    CRUTOperations(plant);
                    continue;
                }
                else
                {
                    MainHelp();
                    continue;
                }

            }
        }


        private static void ViewOperations(List<Employe> sameList)
        {
            Console.WriteLine("To view all list enter: View");
            Console.WriteLine("To view list by name enter: Name");
            Console.WriteLine("To view list by suname enter: Surname");
            Console.WriteLine("To view list by age enter: Age");
            Console.WriteLine("To view list by dpertment enter: Department");
            Console.WriteLine("To view count employe enter: Count");
            Console.WriteLine("To view total salary enter: Salary");

            PlantSelector viewer = new PlantSelector(sameList);
            string viewCommand = Console.ReadLine();
            switch (viewCommand.ToLower())
            {



                case "name":
                    Console.WriteLine("Enter name:");
                    string viewedName = Console.ReadLine();
                    string[] splitedViewedName = viewedName.Split(' ');
                    if (splitedViewedName.Length == 1)
                    {
                        PrinterCollections.PrintCollection(viewer.ShowEmloyerByName(viewedName));
                    }
                    else
                    {
                        Console.WriteLine("Nonexeіting name");
                    }
                    break;
                case "surname":
                    Console.WriteLine("Enter surname:");
                    string viewedSurname = Console.ReadLine();
                    string[] splitedViewedSurname = viewedSurname.Split(' ');
                    if (splitedViewedSurname.Length == 1)
                    {
                        PrinterCollections.PrintCollection(viewer.ShowEmloyerBySurname(viewedSurname));
                    }
                    else
                    {
                        Console.WriteLine("Nonexeіting surname");
                    }
                    break;
                case "age":
                    Console.WriteLine("Enter Age: ");
                    byte viewedAge;
                    if (Byte.TryParse(Console.ReadLine(), out viewedAge))
                    {
                        PrinterCollections.PrintCollection(viewer.ShowEmloyerByAge(viewedAge));
                    }
                    else
                    {
                        Console.WriteLine("Wrong age format");
                    }
                    break;
                case "department":
                    ListOfDepartments();
                    Console.WriteLine("Enter Department: ");
                    Department viewedDepartment;
                    string enteredViewedDepartment = Console.ReadLine().ToLower();
                    //--------------------------------------
                    switch (enteredViewedDepartment)
                    {
                        case "it":
                            viewedDepartment = Department.IT;
                            break;
                        case "marketing":
                            viewedDepartment = Department.Managment;
                            break;
                        case "financial":
                            viewedDepartment = Department.Financial;
                            break;
                        case "engineering":
                            viewedDepartment = Department.Engineering;
                            break;
                        case "managment":
                        default:
                            viewedDepartment = Department.Managment;
                            break;

                    }
                    PrinterCollections.PrintCollection(viewer.ShowEmloyerByDepartment(viewedDepartment));
                    //----------------------------------------
                    break;
                case "count":
                    Console.WriteLine(viewer.ShowPlantCount());
                    break;
                case "salary":
                    Console.WriteLine(viewer.ShowPlantSalary());
                    break;
                case "view":
                default:
                    PrinterCollections.PrintCollection(sameList);
                    break;


            }


            Console.WriteLine("press any key");
            Console.ReadKey();
        }

        private static void CRUTOperations(List<Employe> sameList)
        {
            Console.WriteLine("To add employe to Plant enter: Add");
            Console.WriteLine("To delete employe by name enter: Name");
            Console.WriteLine("To delete employe by surname enter: Surame");
            Console.WriteLine("May be late we'll make upgrate employe information");

            string crudCommand = Console.ReadLine();
            switch (crudCommand.ToLower())
            {
                case "name":
                    Console.WriteLine("Enter name: ");
                    string nameForDelite = Console.ReadLine();
                    DeleteEmploye.RemoveByName(sameList, nameForDelite);
                    break;

                case "surname":
                    Console.WriteLine("Enter surname: ");
                    string surNameForDelite = Console.ReadLine();
                    DeleteEmploye.RemoveByName(sameList, surNameForDelite);
                    break;

                case "add":
                default:
                    sameList.Add(CreateEmploye.Create());
                    break;

            }

            Console.WriteLine("press any key");
            Console.ReadKey();
        }
        private static void ExitOperations()
        {

            Console.WriteLine("press any key");

            Console.ReadKey();


        }

        private static void MainHelp()
        {
            Console.WriteLine("Available commands: ");
            Console.WriteLine("-View \n-CRUT \n-Exit");
            Console.WriteLine("press any key");
            Console.ReadKey();
        }

        private static void SelectorHelp()
        {
            Console.WriteLine("To view all list enter: View");
            Console.WriteLine("To view list by name enter: Name");
            Console.WriteLine("To view list by suname enter: Surname");
            Console.WriteLine("To view list by age enter: Age");
            Console.WriteLine("To view list by dpertment enter: Department");
            Console.WriteLine("To view count employe enter: Count");
            Console.WriteLine("To view total salary enter: Salary");
            Console.WriteLine("press any key");
            Console.ReadKey();
        }

        private static void ListOfDepartments()
        {
            Console.WriteLine("List of Drpartmets:");
            Console.WriteLine("-IT");
            Console.WriteLine("-Marketing");
            Console.WriteLine("-Financial");
            Console.WriteLine("-Engineering");
            Console.WriteLine("-Managment");
        }
    }
}


// plant.Add(CreateEmploye.Create());
//SetGetSerialezationMethod gsm = new SetGetSerialezationMethod ();
//gsm.SerialezationMethod = SerializationMethods.json;
//Console.WriteLine(gsm.SerialezationMethod);

//plant.Add(new Employe("Nick", "Smith", 25, Department.IT, "1234567890", 500));
//            plant.Add(new Employe("Adam", "Wilder", 35, Department.Financial, "9876543210", 600));
//            plant.Add(new Employe("Lena", "Markoni", 40, Department.Financial, "1234098765", 200));
//            plant.Add(new Employe("Nick", "McGregor", 24, Department.Engineering, "1209876543", 800));
//            plant.Add(new Employe("John", "Smith", 43, Department.Managment, "9801234567", 1500));
//            plant.Add(new Employe("Angel", "Petrova", 25, Department.Marketing, "2345678901", 700));



//            PlantSelector ui = new PlantSelector(plant);
//PrinterCollections.PrintCollection(plant);
//            Console.WriteLine("-------------------------------");
//            Console.WriteLine("Общая зарплата " + ui.ShowPlantSalary());
//            Console.WriteLine("-------------------------------");

//            PrinterCollections.PrintCollection(ui.ShowEmloyerByName("Nick"));
//            Console.WriteLine("-------------------------------");

//            PrinterCollections.PrintCollection(ui.ShowEmloyerByAge(25));
//            Console.WriteLine("-------------------------------");
//            PrinterCollections.PrintCollection(ui.ShowEmloyerByDepartment(Department.Financial));
