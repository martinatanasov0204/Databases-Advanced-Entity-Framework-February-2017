namespace _09_hospital_database
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    class Startup
    {
        static void Main()
        {
            var context = new HospitalContext();

            //Create new database with all tables

            context.Database.Initialize(true);

            context.SaveChanges();
        }
    }
}
