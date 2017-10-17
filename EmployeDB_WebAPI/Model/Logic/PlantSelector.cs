using EmployesDB.DB;
using EmployesDB.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployesDB.UI
{
    class PlantSelector
    {
        private IEnumerable<Employe> plant;
        public IEnumerable<Employe> Plant
        {
            set
            {
                plant = value;
            }
            get
            {
                return plant;
            }

        }

        public PlantSelector(IEnumerable<Employe> plant)
        {
            this.plant = plant;
        }
       

        public IEnumerable<Employe> ShowEmloyerByName(string name)
        {
            IEnumerable<Employe> showEmloyerBy = Plant.OrderBy(empl => empl.Age).Where(empl => empl.Name == name);
            return showEmloyerBy;
        }

        public IEnumerable<Employe> ShowEmloyerBySurname(string name)
        {
            IEnumerable<Employe> showEmloyerBy = Plant.OrderBy(empl => empl.Age).Where(empl => empl.Surname == name);
            return showEmloyerBy;
        }

        public IEnumerable<Employe> ShowEmloyerByAge(byte age)
        {
            IEnumerable<Employe> showEmloyerBy = Plant.OrderBy(empl => empl.Name).Where(empl => empl.Age == age);
            return showEmloyerBy;

        }

        public IEnumerable<Employe> ShowEmloyerByDepartment(Department department)
        {
            IEnumerable<Employe> showEmloyerBy = Plant.OrderBy(empl => empl.Name).Where(empl => empl.Department == department);
            return showEmloyerBy;

        }

        public int ShowPlantSalary()
        {
            return Plant.Sum(empl => empl.Salary);
        }

        public int ShowPlantCount()
        {
            return Plant.Count();

        }
    }
}
