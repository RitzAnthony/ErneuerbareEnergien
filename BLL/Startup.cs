using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Startup
    {
        public static void SetupDatabase()
        {
            DAL.DataInitializer.AddDefaultData();
        }
    }
}
