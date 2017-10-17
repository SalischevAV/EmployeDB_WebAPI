using EmployesDB;
using EmployesDB.Enums;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.Web.Http;
using System.Linq;
using EmployesDB.UI;
using EmployesDB.Logic;

namespace EmployeDB_WebAPI.Controllers
{
    public class ValuesController : ApiController
    {

        List<Employe> plant = new List<Employe>();
        //PlantSelector ajaxSelector = new PlantSelector(plant);

        //public IList<Employe> GetOne(string surname)
        //{
        //    PlantSelector ajaxSelector = new PlantSelector(plant);
        //    return (IList<Employe>)ajaxSelector.ShowEmloyerBySurname(surname);
        //}
        public IList<Employe> Get()
        {
            //plant.Add(new Employe { Name = "aa", Surname = "bg", Age = 23, Department = Department.IT, PhoneNumber = "1234567890", Salary = 600 });
            //plant.Add(new Employe { Name = "ab", Surname = "bh", Age = 24, Department = Department.Managment, PhoneNumber = "1234567890", Salary = 600 });
            //plant.Add(new Employe { Name = "ac", Surname = "bj", Age = 25, Department = Department.Financial, PhoneNumber = "1234567890", Salary = 600 });
            //plant.Add(new Employe { Name = "ad", Surname = "bk", Age = 23, Department = Department.Marketing, PhoneNumber = "1234567890", Salary = 600 });
            //plant.Add(new Employe { Name = "ae", Surname = "bb", Age = 23, Department = Department.IT, PhoneNumber = "1234567890", Salary = 600 });

            Saver sv = new Saver(plant);
            plant = sv.Loader();
            Saver sv1 = new Saver(plant);
            sv1.Unloader();

            return plant;
        }

        public IList<Employe> Post(Employe emp)
        {
            Saver sv = new Saver(plant);
            plant = sv.Loader();

            plant.Add(emp);
            Saver sv1 = new Saver(plant);
            sv1.Unloader();
            return plant;
        }

        public IList<Employe> Delete(string surname)
        {

            Saver sv = new Saver(plant);
            plant = sv.Loader();
            
            Employe itemForRemove = plant.SingleOrDefault(item => item.Surname == surname);
            if (itemForRemove != null)
            {
                plant.Remove(itemForRemove);
            }
            Saver sv1 = new Saver(plant);
            sv1.Unloader();
            return plant;
        }

        public IList<Employe> Put(string surname, Employe emp)
        {
            Saver sv = new Saver(plant);
            plant = sv.Loader();
            
            Employe itemForEdit = plant.SingleOrDefault(item => item.Surname == surname);
            if (itemForEdit != null)
            {
                itemForEdit.Name = emp.Name;
                itemForEdit.PhoneNumber = emp.PhoneNumber;
                itemForEdit.Salary = emp.Salary;
                itemForEdit.Department = emp.Department;
                itemForEdit.Age = emp.Age;
            }
            Saver sv1 = new Saver(plant);
            sv1.Unloader();
            return plant;
        }
    }
}
