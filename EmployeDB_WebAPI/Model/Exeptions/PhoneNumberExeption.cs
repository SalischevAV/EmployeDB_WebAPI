using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace EmployeDB_WebAPI.Model.Exeptions
{
    public class PhoneNumberExeption: ApplicationException
    {
        public PhoneNumberExeption(string message) : base(message) { }
    }
}