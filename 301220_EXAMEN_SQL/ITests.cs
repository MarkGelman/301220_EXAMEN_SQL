using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _301220_EXAMEN_SQL
{
    interface ITests
    {
        void GetAllTests();
        void AddTests(Tests t);
        void UpdateTests(int id, Tests c);
        void DeleteTests(int id);
        void GetAllTestsWithCars();

       
    }
}
