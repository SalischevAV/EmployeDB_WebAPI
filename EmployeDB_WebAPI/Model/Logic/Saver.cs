using EmployesDB.DeserializationImpl;
using EmployesDB.Interfaces;
using EmployesDB.SerializationImpl;
using EmployesDB.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployesDB.Logic
{
    public class Saver
    {
        public string DBName { set; get; }

        public SetGetSerialezationMethod SerializationFlag { get; set; }
        public ISerializable Serializator { set; get; }

        public IDeserializable Deserializator { set; get; }


        public Saver(List<Employe> plant) //Hidden initialization
        {
            SerializationFlag = new SetGetSerialezationMethod();
            switch (SerializationFlag.SerialezationMethod)
            {
              
                case Enums.SerializationMethods.xml:              
                    Serializator = new XMLSerializator(plant);
                    break;
                case Enums.SerializationMethods.bin:
                default:
                    Serializator = new BinarySerializator(plant);
                    break;
            }

            //string[] filesListWithPath = Directory.GetFiles(Directory.GetCurrentDirectory());
            string[] filesListWithPath = Directory.GetFiles(@"C:\Users\salischev.a\Documents\Visual Studio 2015\Projects\EmployesDB\EmployesDB\bin\Debug\");
            List<string> fileList = new List<string>();

            foreach (string item in filesListWithPath)
            {
                fileList.Add(Path.GetFileName(item));
            }

            string dbFile = null;
            foreach (string fileName in fileList)
            {
                if (fileName.ToLower().Contains("plant"))
                {
                    dbFile = fileName;
                    DBName = dbFile;
                }
            }
            if (dbFile != null)
            {
                IsDBExist = true;
                string[] splittingDBFile = dbFile.Split('.');
                if (splittingDBFile.Length == 2)
                {
                    switch (splittingDBFile[1].ToLower())
                    {
                        case "dat":
                            Deserializator = new BinaryDeserializator();
                            break;
                        case "xml":
                        default:
                            Deserializator = new XMLDeserializator();
                            break;
                    }
                }
            }



        }
        public bool IsDBExist { set; get; }


        public List<Employe> Loader()
        {
            if (IsDBExist)
            {
                return Deserializator.Deserialize();

            }
            else
            {
                return new List<Employe>();
            }
        }

        public string Unloader()
        {
            if (IsDBExist)
            {
                File.Delete(DBName);

            }
            try
            {
                Serializator.Serialize();
                return "List save";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return e.Message;
            }
        }


    }
}
