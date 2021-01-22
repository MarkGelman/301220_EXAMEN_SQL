using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _301220_EXAMEN_SQL
{
    class CarsDAO : ICarsDAO
    {
        string _query;
        
       
        public void AddCar(Cars c)
        {
            _query = $"INSERT INTO tests" +
                     $"VALUES ({c.Manufacturer},{c.Model},{c.Year})";
            int row = NonReader(_query,"Add Car");
        }

        public void DeleteCar(int id)
        {
             _query = $"DELETE FROM cars WHERE id ={id}";
             int row = NonReader(_query,"Delete Car");
        }

        public void GetAllByManufacturer(string manufacturer)
        {
          _query = $"Select * FROM cars WHERE manufacturer = {manufacturer}";
           PrintAll(Reader(_query, "Get All By Manufacturer"), "Get All By Manufacturer"); 
        }

        public void GetAllCar()
        {
            _query = $"SELECT * FROM cars"; 
            PrintAll(Reader(_query,"Get All Cars"), "Get All Cars");
        }

        public void UpdateCar(int id, Cars c)
        {
            _query = $"UPDATE tests SET id = {c.Id},manufacturer = {c.Manufacturer}, model = {c.Model},year = {c.Year} ";
            NonReader(_query,"Update Car");
        }

        public List<Cars> Reader(string query,string function)
        {
            List<Cars> allCars = new List<Cars>();
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(_30122020_EXAMEN_SQLAppConfig.ConnectionString))
                {
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Cars c = new Cars
                                {
                                    Id = (long)reader["id"],
                                    Manufacturer = reader["manufacturer"].ToString(),
                                    Model = reader["model"].ToString(),
                                    Year = (int)reader["year"]
                                };
                                allCars.Add(c);
                            }
                        }
                        return allCars;
                    }

                }
            
            }
            catch (Exception ex)
            {
                _30122020_EXAMEN_SQLAppConfig._log.Error($"Process '{ function}' failed.Exception : {ex}");
                
                Console.WriteLine($"Process '{ function}' failed.Exception : {ex}");
                Console.ReadKey();
                Environment.Exit(-1);
            }
            return null;
        }
        public int NonReader(string query,string function)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(_30122020_EXAMEN_SQLAppConfig.ConnectionString))
                {
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        return command.ExecuteNonQuery();
                    }
                }
            }

            catch (Exception ex)
            {
                _30122020_EXAMEN_SQLAppConfig._log.Error($"{function} method.\nException {ex}");
                Console.WriteLine($"Process '{ function}' failed.Exception : {ex}");
                Console.ReadKey();
                Environment.Exit(-1);
            }
            return 0;
        }

        void PrintAll (List<Cars> allCars,string name_function)
        {
            Console.WriteLine($"                ******** {name_function}*********");
            Console.WriteLine();
            allCars.ForEach(c => Console.WriteLine($"{c}"));
            Console.WriteLine();
            Console.WriteLine();
        }

    }
}
