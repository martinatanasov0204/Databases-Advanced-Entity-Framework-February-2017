namespace _05_change_town_names_casing
{
    using System.Data.SqlClient;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class Startup
    {
        static void Main()
        {
            //Input a country name

            string country = Console.ReadLine();
            List<string> allCities = new List<string>();

            SqlConnection connection = new SqlConnection("Server=DESKTOP-TPGP88F;Database=MinionsDB;Integrated Security = true");
            connection.Open();

            //Select the info we need to process
            
            SqlCommand selectQuery = new SqlCommand($"SELECT TownName FROM Towns WHERE CountryName = '{country}'", connection);

            using (connection)
            {
                SqlDataReader reader = selectQuery.ExecuteReader();
                
                while (reader.Read())
                {
                    string cityToAdd = ((string)reader["TownName"]).ToUpper();

                    if (!allCities.Contains(cityToAdd))
                    {
                        allCities.Add(cityToAdd);
                    }

                    SqlConnection updateConnection = new SqlConnection("Server=DESKTOP-TPGP88F;Database=MinionsDB;Integrated Security = true");
                    updateConnection.Open();

                    //Update tables with the same but upperCased name

                    using (updateConnection)
                    {
                        SqlCommand updateQuery = new SqlCommand($"UPDATE Towns SET TownName = '{cityToAdd}' WHERE CountryName = '{country}'", updateConnection);
                        updateQuery.ExecuteNonQuery();
                    }
                }
            }       
            
            //Print the results     

            if (!allCities.Any())
            {
                Console.WriteLine("No town names were affected.");
            }
            else
            {
                Console.WriteLine("{0} town names were affected.", allCities.Count);
                Console.Write("[");
                Console.Write(string.Join(", ", allCities.ToArray()));
                Console.WriteLine("]");
            }
        }
    }
}
