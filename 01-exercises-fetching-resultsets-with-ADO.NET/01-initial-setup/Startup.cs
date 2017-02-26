namespace _01_initial_setup
{
    using System.IO;
    using System.Data.SqlClient;
    class Startup
    {
        static void Main()
        {
            //We assume that the Database MinionsDB already exist, so we don't create it.

            string query = File.ReadAllText(@"D:\myStuff\SoftUni\Databases-Advanced\ExercisesIntroductionToDBApps\01-initial-setup\01-initial-setup.sql");
            SqlConnection connection = new SqlConnection("Server=DESKTOP-TPGP88F;Database=MinionsDB;Integrated Security = true");
            connection.Open();

            //Create tables and insert data

            SqlCommand createInsertTablesCommad = new SqlCommand(query, connection);

            using (connection)
            {
                createInsertTablesCommad.ExecuteNonQuery();
            }
        }
    }
}
