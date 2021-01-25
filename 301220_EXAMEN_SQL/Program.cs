using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _301220_EXAMEN_SQL
{
    class Program
    {
        
        static void Main(string[] args)
        {
            _30122020_EXAMEN_SQLAppConfig._log.Info("******************** System startup");
            TestsDAO test = new TestsDAO();
            CarsDAO car = new CarsDAO();
            Tests test1 = new Tests()
            {
                Id = 2,
                Car_Id = 3,
                IsPassed = false,
                Date = Convert.ToDateTime("2007-10-05")

            };


            _30122020_EXAMEN_SQLAppConfig _config = new _30122020_EXAMEN_SQLAppConfig();

            _30122020_EXAMEN_SQLAppConfig.GetOpenConnection();

                //test.AddTests(test1);
                test.GetAllTests();
                //test.UpdateTests(1); */ 
                //test.GetAllTestsWithCars();       
            
            _30122020_EXAMEN_SQLAppConfig._log.Info("******************** System shutdown");
        }
    }
}
