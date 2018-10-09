using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _1savarankiskas
{
    class Program
    {
        public const int MaxFlatAmount = 514;
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.Write("Įveskite kambarių skaičių: ");
            int roomAmount = int.Parse(Console.ReadLine());
            Console.Write("Įveskite kainą: ");
            double maxprice = double.Parse(Console.ReadLine());
            Console.Write("Aukštai nuo: ");
            int minfloor = int.Parse(Console.ReadLine());
            Console.Write("Iki: ");
            int maxfloor = int.Parse(Console.ReadLine());

            FlatContainer flats = new FlatContainer(MaxFlatAmount);
            ReadFlatData(flats);

            flats.GetFloor();

            Console.WriteLine("");
            Console.WriteLine("Pradiniai duomenys");
            Console.WriteLine("");

            PrintToConsole(flats);

            FlatContainer filteredFlats = FilteredFlats(flats, roomAmount, maxprice, minfloor, maxfloor);
            Console.WriteLine("");
            Console.WriteLine("Atrinkti butai");
            Console.WriteLine("");

            PrintToConsole(filteredFlats);

            Console.ReadKey();
        }

        /// <summary>
        /// Nuskaito failo duomenis
        /// </summary>
        /// <param name="flats"></param>
        private static void ReadFlatData(FlatContainer flats)
        {
            using (StreamReader reader = new StreamReader(@"Sav.D.1.Data.csv"))
            {
                string line = null;
                line = reader.ReadLine();

                while (null != (line = reader.ReadLine()))
                {
                    string[] values = line.Split(';');
                    int number = int.Parse(values[0]);
                    double area = double.Parse(values[1]);
                    int rooms = int.Parse(values[2]);
                    double price = double.Parse(values[3]);
                    string phone = values[4];

                    Flat flat = new Flat(number, area, rooms, price, phone);

                    flats.AddFlat(flat);
                }
            }

        }

        /// <summary>
        /// Spausdina butus į konsolę
        /// </summary>
        /// <param name="flats"></param>
        private static void PrintToConsole(FlatContainer flats)
        {
            for (int i = 0; i < flats.Count; i++)
            {
                Console.WriteLine(flats.GetFlat(i));
            }
        }

        /// <summary>
        /// Suranda pageidaujamus butus
        /// </summary>
        /// <param name="flats"></param>
        /// <param name="roomAmount"></param>
        /// <param name="maxprice"></param>
        /// <param name="minfloor"></param>
        /// <param name="maxfloor"></param>
        /// <returns></returns>
        private static FlatContainer FilteredFlats(FlatContainer flats, int roomAmount, double maxprice, int minfloor, int maxfloor)
        {
            FlatContainer filteredFlats = new FlatContainer(MaxFlatAmount);
            for (int i = 0; i < flats.Count; i++)
            {
                if (flats.GetFlat(i).Rooms == roomAmount)
                {
                    if (flats.GetFlat(i).Price <= maxprice)
                    {
                        Console.WriteLine(flats.GetFlat(i).Floor);
                        if (flats.GetFlat(i).Floor >= minfloor && flats.GetFlat(i).Floor <= maxfloor)
                        {
                            filteredFlats.AddFlat(flats.GetFlat(i));
                        }
                    }
                }
            }
            return filteredFlats;
        }
    }
}
