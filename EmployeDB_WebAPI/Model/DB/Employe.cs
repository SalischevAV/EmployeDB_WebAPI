using EmployeDB_WebAPI.Model.Exeptions;
using EmployesDB.DB;
using EmployesDB.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EmployesDB
{
    [DataContract]
    [Serializable]
    public class Employe: User
    {
        private byte age;
        private string phoneNumber;
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Surname { set; get; }
        [DataMember]
        public Department Department { set; get; }

        [DataMember]
        public byte Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value > 18 && value < 70)
                {
                    age = value;
                }
            }
        }
        [DataMember]
        public int Salary { set; get; }

        [DataMember]
        public string PhoneNumber // write nornal RegEx
        {

            set
            {
                string pattern = @"^\d{10}$";
                if (Regex.IsMatch(value, pattern))
                {
                    phoneNumber = value;
                }
                else
                {
                    phoneNumber = null;
                    //throw new PhoneNumberExeption("Неверный формат номера");
                }
            }
            get
            {
                return phoneNumber;
            }
        }
        public Employe()//for XML Serialization
        {
                
        }
        public Employe(string name, string surname, byte age,  Department department,  string phoneNumber, int salary)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Department = department;
            PhoneNumber = phoneNumber;
            Salary = salary;   
        }

        public override string ToString()
        {
            return String.Format(" Фамилия {0}, Имя {1}, возраст {2}, cотрудник отдела {3}, телефон {4}, зарплата - {5}уе.", Name, Surname, Age, Department, PhoneNumber, Salary);
        }

    }
}
