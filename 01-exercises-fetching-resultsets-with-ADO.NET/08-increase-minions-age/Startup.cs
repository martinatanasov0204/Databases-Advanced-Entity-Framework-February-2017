namespace _08_increase_minions_age
{
    using System.Data.SqlClient;
    using System;
    using System.Linq;
    class Startup
    {
        static void Main()
        {
            //Input the id of Minions you'd like to alter

            var input = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            SqlConnection connection = new SqlConnection(@"Server = DESKTOP-TPGP88F;Database=MinionsDB;Integrated Security=true");
            connection.Open();

            string query = @"SELECT Id, MinionName, Age FROM Minions";

            using (connection)
            {
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        if (input.Contains((int)reader["Id"]))
                        {
                            int currId = (int)reader["Id"];
                            string newName = (string)reader["MinionName"];
                            newName = char.ToUpper(newName[0]) + newName.Substring(1);
                            
                            string updateQuery = $"UPDATE Minions SET MinionName = '{newName}', Age = Age + 1 WHERE Id = {currId}";

                            SqlConnection updateConnection = new SqlConnection(@"Server = DESKTOP-TPGP88F;Database=MinionsDB;Integrated Security=true"); ;
                            updateConnection.Open();

                            using (updateConnection)
                            {
                                SqlCommand updateCommand = new SqlCommand(updateQuery, updateConnection);
                                updateCommand.ExecuteNonQuery();
                            }
                        }
                    }
                }

                reader = command.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        //Print each line

                        Console.WriteLine("{0} {1}", (string)reader["MinionName]"], (int)reader["Age"]);
                    }
                }
            }
        }
    }
}
