using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _301220_EXAMEN_SQL
{
    interface ICarsDAO
    {
        void GetAllCar();
        void AddCar(Cars t);
        void UpdateCar(int id, Cars c);
        void DeleteCar(int id);
        void GetAllByManufacturer(string manufacturer);
    }
}
