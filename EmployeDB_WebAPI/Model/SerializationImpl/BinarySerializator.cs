using EmployesDB.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace EmployesDB.SerializationImpl
{
    class BinarySerializator: ISerializable
    {     

        public List<Employe> Plant { set; get; }

        public BinarySerializator(List<Employe> plant)
        {
            Plant = plant;
        }
        public void Serialize()
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = new FileStream(@"C:\Users\salischev.a\Documents\Visual Studio 2015\Projects\EmployesDB\EmployesDB\bin\Debug\plant.dat", FileMode.OpenOrCreate))
            {
                bf.Serialize(fs, Plant);
             }


        }
   
    }
}

 
