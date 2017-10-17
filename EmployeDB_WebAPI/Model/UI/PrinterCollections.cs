using EmployesDB.DB;
using System;
using System.Collections.Generic;

namespace EmployesDB.UI
{
    public static class PrinterCollections
    {
        public static void PrintCollection (IEnumerable<User> sameCollection)
        {
            foreach (var item in sameCollection)
            {
                Console.WriteLine(item);
            }
        }
    }
}
