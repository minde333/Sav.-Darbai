using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _1savarankiskas
{
    class FlatContainer
    {
        private Flat[] Flats { get; set; }
        public int Count { get; private set; }

        /// <summary>
        /// Butų konteineris
        /// </summary>
        /// <param name="size"></param>
        public FlatContainer(int size)
        {
            Flats = new Flat[size];
        }

        /// <summary>
        /// Prideda butą
        /// </summary>
        /// <param name="flat"></param>
        public void AddFlat(Flat flat)
        {
            Flats[Count++] = flat;
        }

        /// <summary>
        /// Paduoda butą
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Flat GetFlat(int index)
        {
            return Flats[index];
        }

        /// <summary>
        /// Paduoda namo aukštą
        /// </summary>
        public void GetFloor()
        {
            for (int i = 0; i < Count; i++)
            {
                Flats[i].FindFloor();
            }
        }
    }
}
