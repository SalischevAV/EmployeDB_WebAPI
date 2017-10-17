using EmployesDB.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EmployesDB.DeserializationImpl
{
    class XMLDeserializator:IDeserializable
    {
        public List<Employe> Plant { get; set; }

        public List<Employe> Deserialize()
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Employe>));
            using (FileStream fs = new FileStream(@"C:\Users\salischev.a\Documents\Visual Studio 2015\Projects\EmployesDB\EmployesDB\bin\Debug\plant.xml", FileMode.OpenOrCreate))//hard code - very bad
            {
                List<Employe> newPlant = (List<Employe>)xs.Deserialize(fs);
                Plant = newPlant;
                return newPlant;
            }
        }
    }
}
