using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _301220_EXAMEN_SQL
{
    class Tests
    {
        public Int64 Id { get; set; }
        public Int64 Car_Id { get; set; }
        public bool IsPassed { get; set; }
        public DateTime Date { get; set; }

        public Tests()
        {

        }
        public Tests(long id,long car_id,bool isPassed,DateTime date)
        {
            Id = id;
            Car_Id = car_id;
            IsPassed = isPassed;
            Date = date;
        }

        public override string ToString()
        {
            return $"{Newtonsoft.Json.JsonConvert.SerializeObject(this)}";
        }

        public override bool Equals(object obj)
        {
            Tests test = obj as Tests;
            return this.Id.Equals(test.Id);
        }

        public override int GetHashCode()
        {
            return (int)this.Id ;
        }  

        
        public static bool operator == (Tests t1,Tests t2)
        {
           
            if (t1 is null && t2 is null)
                return true;
            if (t1.Id == t2.Id)
                return true;
            return false;
        }

        public static bool operator != (Tests t1, Tests t2)
        {
            return !(t1 == t2);
        }
    }
}
