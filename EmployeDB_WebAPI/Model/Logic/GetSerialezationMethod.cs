using EmployesDB.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EmployesDB.UI
{
    public class SetGetSerialezationMethod
    {
        string optionFile = "option.ini";// const or var?
        private SerializationMethods serialezationMethod;
        public SerializationMethods SerialezationMethod
        {


            set
            {
                try
                {

                    using (StreamWriter sw = new StreamWriter(optionFile, false, Encoding.Default))
                    {
                        sw.Write(value);

                    }
                }
                catch (Exception e)
                {
                    //
                }

            }




            get
            {
                if (File.Exists(optionFile))
                {
                    using (StreamReader sr = new StreamReader(optionFile, Encoding.Default))
                    {
                        //serialezationMethod = (SerializationMethods)Enum.Parse(typeof(SerializationMethods), sr.ReadToEnd());
                        if(Enum.TryParse(sr.ReadToEnd(), out serialezationMethod))
                        { }
                        else
                        {
                            serialezationMethod = SerializationMethods.xml;
                        }
                    }
                }
                else
                {

                    serialezationMethod = SerializationMethods.xml;
                }
                return serialezationMethod;
            }

        }

    }
}





