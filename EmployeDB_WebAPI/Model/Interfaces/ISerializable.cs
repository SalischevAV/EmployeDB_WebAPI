using EmployesDB.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployesDB.Interfaces
{
   public interface ISerializable
    {
        List<Employe> Plant { set; }
        void Serialize();
    }
}
