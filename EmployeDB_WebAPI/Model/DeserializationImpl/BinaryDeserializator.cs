using EmployesDB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace EmployesDB.DeserializationImpl
{
    class BinaryDeserializator : IDeserializable
    {
        public List<Employe> Plant{get; set;}

        public List<Employe> Deserialize()
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = new FileStream(@"C:\Users\salischev.a\Documents\Visual Studio 2015\Projects\EmployesDB\EmployesDB\bin\Debug\plant.dat", FileMode.OpenOrCreate)) //Hard code
            {
                List<Employe> newPlant = (List<Employe>)bf.Deserialize(fs);
                Plant = newPlant;
                return newPlant;
            }
        }
    }
}
