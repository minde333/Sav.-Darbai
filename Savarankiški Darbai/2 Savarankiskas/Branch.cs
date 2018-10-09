using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2Lab._2Savarankiskas
{

    /// <summary>
    /// Klasė, kuri aprašo fakulteto duomenis
    /// </summary>
    class Branch
    {
        public const int MaxAmountOfStudents = 1000;
        public string Faculty { get; set; }
        public Student[] Students { get; set; }
        public int Count { get; private set; }

        public Branch()
        {
        }

        /// <summary>
        /// Sukuriamas konstruktorius, kuriame yra fakulteto pavadinimas ir studentų sąrašas
        /// </summary>
        /// <param name="faculty"></param>
        public Branch(string faculty)
        {
            Faculty = faculty;
            Students = new Student[MaxAmountOfStudents];
            Count = 0;
        }

        /// <summary>
        /// Pridedamas studentas į sąrašą
        /// </summary>
        /// <param name="student"></param>
        public void AddStudent(Student student)
        {
            Students[Count++] = student;
        }        
    }
}
