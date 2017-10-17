using EmployesDB.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EmployesDB.SerializationImpl
{
    class XMLSerializator : ISerializable
    {
        public List<Employe> Plant{ set; get;}

        public XMLSerializator(List<Employe> plant)
        {
            Plant = plant;   
        }

        public void Serialize()
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Employe>));
            using (FileStream fs = new FileStream(@"C:\Users\salischev.a\Documents\Visual Studio 2015\Projects\EmployesDB\EmployesDB\bin\Debug\plant.xml", FileMode.OpenOrCreate)) //Hard code
            {
                xs.Serialize(fs, Plant);
            }
        }
    }
}
