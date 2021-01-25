using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _301220_EXAMEN_SQL
{
    class TestsDAO : ITests
    {
        string _query;
       
       
        
        public void AddTests(Tests t)
        {

            _query = $"INSERT INTO tests VALUES ({t.Car_Id},{t.IsPassed},{t.Date})";
                    
            int row = NonReader(_query, "Add Tests");
        }

        public void DeleteTests(int id)
        {
            _query = $"DELETE FROM tests WHERE id ={id}";
            int row = NonReader(_query, "Delete Tests");
        }

        public void GetAllTests()
        {
            _query = $"SELECT * FROM tests";

            PrintAll(Reader(_query, "Get All Tests"), "Get All Tests");
        }

        public void GetAllTestsWithCars()
        {
           
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(_30122020_EXAMEN_SQLAppConfig.ConnectionString))
                {
                    connection.Open();
                    _query = $"SELECT t.isPassed,t.date,c.Manufacturer,c.Model,c.Year FROM tests t JOIN cars c ON c.id = t.car_id"; 
                         
                    using (SQLiteCommand command = new SQLiteCommand(_query, connection))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            int i = 0;
                            while (reader.Read())
                            {
                                var Cars_With_Tests = new
                                {
                                    Id = i++,
                                    Manufacturer = (string)reader["c.manufacturer"],
                                    Model = (string)reader["c.model"],
                                    Year = (int)reader["c.year"],
                                    IsPassed = (bool)reader["t.isPassed"],
                                    Date = Convert.ToDateTime(reader["t.date"])
                                };

                                Console.WriteLine($"{Cars_With_Tests}");
                            }

                        }
                    }
                }
            }

            catch (Exception ex)
            {
                _30122020_EXAMEN_SQLAppConfig._log.Error($"Connection failed.Exception: {ex}");
                Console.WriteLine($"Process 'Get All Tests With Cars' failed.Exception : {ex}");
                Console.ReadKey();
                Environment.Exit(-1);
            }
        }
        public void UpdateTests(int id, Tests t)
        {
            _query = $"UPDATE tests SET id = {t.Id},car_id = {t.Car_Id}, isPassed = {t.IsPassed},date = {t.Date} ";
            int row = NonReader(_query, "Update Tests");
        }

        public  List<Tests> Reader (string query,string function)
        {
            List<Tests> allTests = new List<Tests>();
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(_30122020_EXAMEN_SQLAppConfig.ConnectionString))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                bool isPassed = false;
                                if (Convert.ToInt32(reader["isPassed"]) == 1)
                                    isPassed = true;
                                Tests t = new Tests
                                {
                                    Id = (long)reader["id"],
                                    Car_Id = (long)reader["car_id"],
                                    IsPassed = isPassed,
                                    Date = Convert.ToDateTime(reader["date"])
                                };
                                allTests.Add(t);
                            }
                            return allTests;

                        }
                    }
                }
            }

            catch (Exception ex)
            {
                _30122020_EXAMEN_SQLAppConfig._log.Error($"Connection failed.Exception: {ex}");
                Console.WriteLine($"Connection failed.Exception: {ex}");
                Console.ReadKey();
                Environment.Exit(-1);
                return null;
            }
            
        }

        public int NonReader(string query, string function)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(_30122020_EXAMEN_SQLAppConfig.ConnectionString))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        return command.ExecuteNonQuery();
                    }
                }
            }

            catch (Exception ex)
            {
                _30122020_EXAMEN_SQLAppConfig._log.Error($"Connection failed.Exception: {ex}");
                Console.WriteLine($"Process '{ function}' failed.Exception : {ex}");
                Console.ReadKey();
                Environment.Exit(-1);
            }

            return 0;
        }

        void PrintAll(List<Tests> allCars, string name_function)
        {
            Console.WriteLine($"                ******** {name_function}*********");
            Console.WriteLine();
            allCars.ForEach(c => Console.WriteLine($"{c}"));
            Console.WriteLine();
            Console.WriteLine();
        }


    }
}
