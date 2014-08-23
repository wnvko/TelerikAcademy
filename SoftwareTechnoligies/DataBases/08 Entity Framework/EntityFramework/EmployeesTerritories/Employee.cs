using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core.Metadata.Edm;
using NorthWind;

namespace EmployeesTerritories
{
    public partial class Employee
    {
        EntitySet myTerritory = new EntitySet();
    }
}
