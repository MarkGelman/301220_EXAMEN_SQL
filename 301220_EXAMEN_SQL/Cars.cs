using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _301220_EXAMEN_SQL
{
    class Cars
    {
        public Int64 Id { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public Cars()
        {

        }
        public Cars(Int64 id, string manufacturer, string model, int year)
        {
            Id = id;
            Manufacturer = manufacturer;
            Model = model;
            Year = year;
        }

        public override string ToString()
        {
            return $"{Newtonsoft.Json.JsonConvert.SerializeObject(this)}";
        }

        public override bool Equals(object obj)
        {
            Cars test = obj as Cars;
            return this.Id.Equals(test.Id);
        }

        public override int GetHashCode()
        {
            return (int)this.Id;
        }

        public static bool operator ==(Cars c1, Cars c2)
        {

            if (c1 is null && c2 is null)
                return true;
            if (c1.Id == c2.Id)
                return true;
            return false;
        }

        public static bool operator !=(Cars c1, Cars c2)
        {
            return !(c1 == c2);
        }
    }
}
