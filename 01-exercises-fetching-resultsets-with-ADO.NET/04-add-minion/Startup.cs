namespace _04_add_minion
{
    using System.Data.SqlClient;
    using System.IO;
    using System;
    using System.Linq;
    class Startup
    {
        static void Main()
        {
            //Input

            Console.Write("Minion: ");
            var minionInput = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToArray();
            Console.Write("Villain: ");
            var villianName = Console.ReadLine();

            string minionName = minionInput[0];
            int minionAge = int.Parse(minionInput[1]);
            string inputedTown = minionInput[2];

            int villianId = 0;
            int minionId = 0;

            SqlConnection connection = new SqlConnection(@"Server = DESKTOP-TPGP88F;Database=MinionsDB;Integrated Security=true");
            connection.Open();

            string vmQuery = File.ReadAllText(@"D:\myStuff\SoftUni\Databases-Advanced\ExercisesIntroductionToDBApps\04-add-minion\04-add-minion.sql");
            string townsSelectQuery = "SELECT * FROM Towns";
            string villiansSelectQuery = "SELECT * FROM Villians";
            string minionsSelectQuery = "SELECT * FROM Minions";

            bool townDoesNotExist = true;
            bool villianDoesNotExist = true;
            bool minionDoesNotExist = true;


            SqlCommand selectTownsCommand = new SqlCommand(townsSelectQuery, connection);
            SqlCommand selectVilliansCommand = new SqlCommand(villiansSelectQuery, connection);
            SqlCommand selectMinionsCommand = new SqlCommand(minionsSelectQuery, connection);

            using (connection)
            {
                SqlDataReader townsReader = selectTownsCommand.ExecuteReader();

                //Check if town already exist in table Towns

                using (townsReader)
                {
                    while (townsReader.Read())
                    {
                        if (inputedTown == (string)townsReader["TownName"])
                        {
                            townDoesNotExist = false;
                            break;
                        }
                    }
                }

                SqlDataReader villiansReader = selectVilliansCommand.ExecuteReader();

                //Check if villian already exist in table Villians

                using (villiansReader)
                {
                    while (villiansReader.Read())
                    {
                        if (villianName == (string)villiansReader["VillianName"])
                        {
                            villianId = (int) villiansReader["Id"];
                            villianDoesNotExist = false;
                            break;
                        }
                    }
                }

                SqlDataReader mionionsReader = selectMinionsCommand.ExecuteReader();

                //Check if minion already exist in table Minions

                using (mionionsReader)
                {
                    while (mionionsReader.Read())
                    {
                        if (minionName == (string)mionionsReader["MinionName"])
                        {
                            minionId = (int) mionionsReader["Id"];
                            minionDoesNotExist = false;
                            break;
                        }
                    }
                }

                //In case one of the above doesn't exist in the Database

                if (townDoesNotExist)
                {
                    string insertInTownsQuery = $"INSERT INTO Towns VALUES ('{inputedTown}', 'Default')";
                    SqlCommand updateTownsCommand = new SqlCommand(insertInTownsQuery, connection);
                    updateTownsCommand.ExecuteNonQuery();
                    Console.WriteLine("Town {0} was added to the database.", inputedTown);
                }

                if (villianDoesNotExist)
                {
                    string insertInVilliansQuery = $"INSERT INTO Villians VALUES ('{villianName}', 'Evil')";
                    SqlCommand updateVilliansCommand = new SqlCommand(insertInVilliansQuery, connection);
                    updateVilliansCommand.ExecuteNonQuery();
                    string topFirstId = "SELECT TOP 1 Id FROM Villians ORDER BY Id DESC";
                    SqlCommand getVillianId = new SqlCommand(topFirstId, connection);
                    villianId = (int) getVillianId.ExecuteScalar();
                    Console.WriteLine("Villain {0} was added to the database.", villianName);
                }

                if (minionDoesNotExist)
                {
                    string insertInMinionsQuery = $"INSERT INTO Minions VALUES ('{minionName}', {minionAge}, 2)";
                    SqlCommand updateMinionsCommand = new SqlCommand(insertInMinionsQuery, connection);
                    updateMinionsCommand.ExecuteNonQuery();
                    string topFirstId = "SELECT TOP 1 Id FROM Minions ORDER BY Id DESC";
                    SqlCommand getMinionId = new SqlCommand(topFirstId, connection);
                    minionId = (int)getMinionId.ExecuteScalar();
                }

                //Set the minion to be servent of the villain

                string setMinionServent = $"INSERT INTO VilliansMinions VALUES ({villianId}, {minionId})";
                SqlCommand setMinionServentCommand = new SqlCommand(setMinionServent, connection);
                setMinionServentCommand.ExecuteNonQuery();
                Console.WriteLine("Successfully added {0} to be minion of {1}.", minionName, villianName);
            }
        }
    }
}
