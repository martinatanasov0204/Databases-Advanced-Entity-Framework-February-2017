namespace _03_get_minion_names
{
    using System.IO;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    class Startup
    {
        static void Main()
        {
            //Input a Villain ID

            int searchedId = int.Parse(Console.ReadLine());
            string villianName = string.Empty;

            Dictionary<string, int> allInfo = new Dictionary<string, int>();

            string query = File.ReadAllText(@"D:\myStuff\SoftUni\Databases-Advanced\ExercisesIntroductionToDBApps\03-get-minion-names\03-get-minion-names.sql");
            SqlConnection connection = new SqlConnection("Server=DESKTOP-TPGP88F;Database=MinionsDB;Integrated Security = true");
            connection.Open();

            //Execute the sql query to get all the useful data

            SqlCommand filterData = new SqlCommand(query, connection);

            using (connection)
            {
                SqlDataReader reader = filterData.ExecuteReader();

                while (reader.Read())
                {
                    if ((int)reader["vId"] == searchedId)
                    {
                        villianName = (string) reader["vName"];
                        string minName = (string) reader["mName"];
                        int minAge = (int) (reader["mAge"]);
                        if (!allInfo.ContainsKey(minName))
                        {
                            allInfo.Add(minName, minAge);
                        }
                    }
                }
            }

            //Print the results

            if (villianName == string.Empty)
            {
                Console.WriteLine("No villain with ID {0} exists in the database.", searchedId);
            }
            else
            {
                Console.WriteLine("Villain: {0}.", villianName);

                if (allInfo.Count == 0)
                {
                    Console.WriteLine("(no minions)");
                }
                else
                {
                    int br = 1;
                    foreach (var item in allInfo)
                    {
                        Console.WriteLine("{0}. {1} {2}", br++, item.Key, item.Value);
                    }
                }
            }
        }
    }
}
