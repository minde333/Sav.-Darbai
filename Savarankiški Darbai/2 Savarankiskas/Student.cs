using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2Lab._2Savarankiskas
{
    /// <summary>
    /// Klasė, studento duomenims aprašyti
    /// </summary>
    class Student
    {
        public string Surname { get; set; } 
        public string Name { get; set; }
        public string Group { get; set; }
        public int AmountOfMarks { get; set; }
        public double AverageMarks { get; set; }

        /// <summary>
        /// Numatytasis konstruktorius
        /// </summary>
        public Student()
        {

        }

        /// <summary>
        /// Parametrų kontruktorius
        /// </summary>
        /// <param name="surname"></param>
        /// <param name="name"></param>
        /// <param name="group"></param>
        /// <param name="amountOfMarks"></param>
        /// <param name="averageMarks"></param>
        public Student(string surname, string name, string group, int amountOfMarks, double averageMarks)
        {
            Surname = surname;
            Name = name;
            Group = group;
            AmountOfMarks = amountOfMarks;
            AverageMarks = averageMarks;
        }
    }
}
