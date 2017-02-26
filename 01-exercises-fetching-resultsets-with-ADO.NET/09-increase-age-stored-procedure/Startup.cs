namespace _09_increase_age_stored_procedure
{
    using System;
    using System.Data.SqlClient;
    class Startup
    {
        static void Main()
        {
            int minionId = int.Parse(Console.ReadLine());
            SqlConnection connection = new SqlConnection(@"Server = DESKTOP-TPGP88F;Database=MinionsDB;Integrated Security=true");
            connection.Open();

            using (connection)
            {
                SqlCommand execCommand = new SqlCommand("EXEC usp_GetOlder @minionId", connection);
                SqlParameter param = new SqlParameter("@minionId", minionId);
                execCommand.Parameters.Add(param);
                execCommand.ExecuteNonQuery();
                SqlCommand selectCommand = new SqlCommand("SELECT MinionName, Age FROM Minions WHERE Id = " + minionId, connection);

                SqlDataReader readMinions = selectCommand.ExecuteReader();
                using (readMinions)
                {
                    while (readMinions.Read())
                    {
                        Console.WriteLine("{0} {1}", readMinions[0], readMinions[1]);
                    }
                }
            }
        }
    }
}
