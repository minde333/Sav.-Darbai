using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _1savarankiskas
{

    class Flat
    {
        public const int MaxNumberOfFlats = 50;
        public int Number { get; set; }
        public double Area { get; set; }
        public int Rooms { get; set; }
        public double Price { get; set; }
        public string Phone { get; set; }
        public int Staircase { get; set; }
        public int Floor { get; set; }

        /// <summary>
        /// Numatytasis konstruktorius
        /// </summary>
        public Flat()
        {
        }

        /// <summary>
        /// Parametrų konstruktorius
        /// </summary>
        /// <param name="number"></param>
        /// <param name="area"></param>
        /// <param name="rooms"></param>
        /// <param name="price"></param>
        /// <param name="phone"></param>
        public Flat(int number, double area, int rooms, double price, string phone)
        {
            Number = number;
            Area = area;
            Rooms = rooms;
            Price = price;
            Phone = phone;

        }

        /// <summary>
        /// Suranda laiptinę
        /// </summary>
        private void FindStaircase()
        {
            double staircase = Number * 1.0 / 27;
            if (staircase - (int)staircase == 0)
            {
                Staircase = (int)staircase;
            }
            else
            {
                Staircase = (int)staircase + 1;
            }
        }

        /// <summary>
        /// Suranda namo aukštą
        /// </summary>
        public void FindFloor()
        {
            FindStaircase();
            if (Number < 27)
            {
                Floor = (int)Math.Ceiling(Number * 1.0 / 3);
            }
            else
            {
                Floor = (int)Math.Ceiling((Number * 1.0 - ((Staircase - 1) * 27 * 1.0)) / 3);
            }
        }

        /// <summary>
        /// Perrašo numatytą Stringą
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {

            return String.Format("| Buto nr. {0,-2} | Plotas {1, 1} kv.m. | Kambarių skaičius {2, -2} | Kaina {3, 6} eu. | Tel nr. {4, 9} |", Number, Area, Rooms, Price, Phone);
        }
    }


}
