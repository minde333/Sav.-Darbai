using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2Lab._2Savarankiskas
{
    class Program
    {
        public const int MaxNumberOfFaculties = 100;
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Program p = new Program();
            //Sukuriamas filialų sąrašas, kuris talpina fakultetų skaičių
            Branch[] branches = new Branch[MaxNumberOfFaculties];
            int Count = 0; //Kintamasis, skirtas fakultetų kiekiui skaičiuoti

            //Direktorijoje nuskaito visus esancčius CSV failus
            string[] filePaths = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.csv");
            foreach (string path in filePaths)
            {
                branches[Count++] = p.ReadData(path);
            }

            //Eina pro fakultetų sąrašą
            for (int i = 0; i < Count; i++)
            {
                //Į konteinerį įdeda atitinkamo fakulteto grupes, ir jas išrikiuoja
                GroupsContainer groups = p.GetGroups(branches[i]);
                groups.SortGroups();
                //Išveda fakuleto pavadinimą
                Console.WriteLine(branches[i].Faculty);
                //Išspausdina visų fakultetų grupes ir jų vidurkius
                for (int j = 0; j < groups.Count; j++)
                {
                    Console.WriteLine("| Grupė: {0} | Grupės vidurkis: {1:f} |", groups.GetGroup(j).NameOfTheGroup, groups.GetGroup(j).GetAverage());
                }
            }

        }

        /// <summary>
        /// Nuskaitomas duomenų failas
        /// </summary>
        /// <param name="file">Failo pavadinimas</param>
        /// <returns></returns>
        public Branch ReadData(string file)
        {
            Branch branch = null;
            using (StreamReader reader = new StreamReader(@file))
            {
                string line = null;
                line = reader.ReadLine();
                if (line != null)
                {
                    branch = new Branch(line);
                }
                while (null != (line = reader.ReadLine()))
                {
                    string[] values = line.Split(',');
                    string surname = values[0];
                    string name = values[1];
                    string group = values[2];
                    int amountOFMarks = int.Parse(values[3]);
                    double average;
                    double sum = 0;
                    for (int i = 4; i < amountOFMarks + 4; i++)
                    {
                        int mark = int.Parse(values[i]);
                        sum += mark;
                    }
                    average = sum / amountOFMarks;
                    Student student = new Student(surname, name, group, amountOFMarks, average);
                    branch.AddStudent(student);
                }
                return branch;
            }
        }

        /// <summary>
        /// Fakulteto studentus suskirsto į grupes
        /// </summary>
        /// <param name="branch">Filialas</param>
        /// <returns></returns>
        public GroupsContainer GetGroups(Branch branch)
        {
            GroupsContainer groups = new GroupsContainer();
            for (int i = 0; i < branch.Count; i++)
            {
                bool found = false;
                for (int j = 0; j < groups.Count; j++)
                {
                    if (groups.GetGroup(j).NameOfTheGroup.Equals(branch.Students[i].Group))
                    {
                        groups.GetGroup(j).AddStudent(branch.Students[i]);
                        found = true;
                        break;   
                    }

                }
                if (!found)
                {
                    groups.AddGroup(new Group(branch.Students[i].Group));
                    groups.GetGroup(groups.Count - 1).AddStudent(branch.Students[i]);
                }
            }
            return groups;
        }

    }
}
