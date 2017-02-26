namespace _02_get_Villains_names
{
    using System.Data.SqlClient;
    using System.IO;
    using System;
    class Startup
    {
        static void Main()
        {
            string query = File.ReadAllText(@"D:\myStuff\SoftUni\Databases-Advanced\ExercisesIntroductionToDBApps\02-get-Villains-names\02-get-villains-names.sql");
            SqlConnection connection = new SqlConnection("Server=DESKTOP-TPGP88F;Database=MinionsDB;Integrated Security = true");
            connection.Open();

            SqlCommand filterVillainsCommand = new SqlCommand(query, connection);

            using (connection)
            {
                SqlDataReader reader = filterVillainsCommand.ExecuteReader();

                while (reader.Read())
                {
                    //Changed condition => sql query selects villains’ names of those who has more than 0 minions

                    string name = (string) (reader["VillianName"]);
                    int numOfMinions = (int) (reader["NumOfMinions"]);

                    Console.WriteLine("{0} {1}", name, numOfMinions);
                }
            }
        }
    }
}
