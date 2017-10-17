using EmployesDB.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployesDB.UI
{
    public static class DeleteEmploye
    {     
        public static void RemoveByName(List<Employe> Plant, string name)
        {
            for (int i = 0; i<Plant.Count; i++)
            {
                if (Plant[i].Name == name)
                {
                    Plant.Remove(Plant[i]);

                }
            }
        }

        public static void RemoveBySurname(List<Employe> Plant, string surname)
        {
            for (int i = 0; i < Plant.Count; i++)
            {
                if (Plant[i].Surname == surname)
                {
                    Plant.Remove(Plant[i]);

                }
            }
        }



    }
}
