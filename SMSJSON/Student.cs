using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMSJSON.JSON;  // Add this to reference Enums

namespace SMSJSON
{
    public class Studenttype
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public Enums.Class Class { get; set; }
        public double Percentage { get; set; }
        public Enums.Grade Grade { get; set; }

        // Uncomment the constructor if needed
        // public Studenttype(string name, int id, Enums.Class classLevel, double percentage, Enums.Grade grade)
        // {
        //     Name = name;
        //     Id = id;
        //     Class = classLevel;
        //     Percentage = percentage;
        //     Grade = grade;
        // }
    }
}
