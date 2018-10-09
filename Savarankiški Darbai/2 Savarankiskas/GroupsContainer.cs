using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2Lab._2Savarankiskas
{

    /// <summary>
    /// Klasė, skirta atitinkamom grupėm saugoti
    /// </summary>
    class GroupsContainer
    {
        public const int MaxNumberOfGroups = 100;

        private Group[] Groups;
        public int Count { get; private set; }

        public GroupsContainer()
        {
            Groups = new Group[MaxNumberOfGroups];
            Count = 0;           
        }

        /// <summary>
        /// Pridedama grupė
        /// </summary>
        /// <param name="group"></param>
        public void AddGroup(Group group)
        {
            Groups[Count++] = group;
        }

        /// <summary>
        /// Paduodama grupė
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Group GetGroup(int index)
        {
            return Groups[index];
        }


        /// <summary>
        /// Metodas, kuris išrikiuoja grupes pagal vidurkį mažėjančia tvarka, o jeigu vidurkiai lygūs, abėcėlės tvarka
        /// </summary>
        public void SortGroups()
        {
            Group temp;
            for(int i = 0; i < Count; i++)
            {
                for(int j = i + 1; j < Count; j++)
                {
                    if(Groups[i].GetAverage() < Groups[j].GetAverage() ||
                        (Groups[i].GetAverage() == Groups[j].GetAverage()
                        && Groups[i].NameOfTheGroup.CompareTo(Groups[j].NameOfTheGroup)>0))
                    {
                        temp = Groups[i];
                        Groups[i] = Groups[j];
                        Groups[j] = temp;
                    }
                }
            }

        }
    }
}
