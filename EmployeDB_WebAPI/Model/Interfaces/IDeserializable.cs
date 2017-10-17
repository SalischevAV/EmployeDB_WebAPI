using EmployesDB.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployesDB.Interfaces
{
   public interface IDeserializable
    {
        List<Employe> Plant { get; }
        List<Employe> Deserialize();
    }
}
