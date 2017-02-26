namespace _07_print_all_minion_names
{
    using System.Data.SqlClient;
    using System;
    using System.Collections.Generic;
    class Startup
    {
        static void Main()
        {
            Dictionary<int, string> storageInfo = new Dictionary<int, string>();
            int countId = 1;

            SqlConnection connection = new SqlConnection("Server=DESKTOP-TPGP88F;Database=MinionsDB;Integrated Security = true");
            connection.Open();

            //Select the info we need to process

            string query = @"SELECT MinionName FROM Minions";

            using (connection)
            {
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string mName = (string) reader["MinionName"];

                    storageInfo.Add(countId, mName);
                    countId++;
                }
            }

            string lastMName = string.Empty;
            int startPos = 1;
            int dataLength = countId - 1;

            //Probably the dumbest logic ever

            if (dataLength % 2 != 0)
            {
                foreach (var item in storageInfo)
                {
                    if (dataLength / 2 != startPos - 1)
                    {
                        Console.WriteLine(storageInfo[startPos]);
                        Console.WriteLine(storageInfo[dataLength - startPos + 1]);
                    }
                    else
                    {
                        lastMName = storageInfo[dataLength / 2 + 1];
                        Console.WriteLine(lastMName);
                        break;
                    }
                    startPos++;
                }
            }
            else
            {
                foreach (var item in storageInfo)
                {
                    if (dataLength / 2 != startPos - 1)
                    {
                        Console.WriteLine(storageInfo[startPos]);
                        Console.WriteLine(storageInfo[dataLength - startPos + 1]);
                    }
                    else
                    {
                        break;
                    }
                    startPos++;
                }
            }           
        }
    }
}
