using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2Lab._2Savarankiskas
{
    /// <summary>
    /// Klasė, kuri aprašo grupės duomenis
    /// </summary>
    class Group
    {
        public string NameOfTheGroup { get; set; }
        public Student[] Students { get; set; }
        public int Count { get; private set; }

        public const int MaxGroupAmount = 100;

        /// <summary>
        /// Numatytasis konstruktorius
        /// </summary>
        public Group()
        {

        }

        public Group(string nameOfTheGroup)
        {
            NameOfTheGroup = nameOfTheGroup;
            Students = new Student[MaxGroupAmount];
            Count = 0; 
        }

        /// <summary>
        /// Prideda studentą į grupės sąrašą
        /// </summary>
        /// <param name="student"></param>
        public void AddStudent(Student student)
        {
            Students[Count++] = student;
        }

        //Suskaičiuoja grupės pažymių vidurkį
        public double GetAverage()
        {
            double sum = 0;
            int count = 0;
            for(int i = 0; i < Count; i++)
            {
                sum += Students[i].AverageMarks;
                count++;
            }

            return sum / count;
        }


    }
}
