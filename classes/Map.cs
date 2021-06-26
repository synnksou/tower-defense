using System;
using System.IO;

namespace tower_defense
{
    interface IMap
    {
        int YLength { get; set; }

        int XLength { get; set; }

        int[,,] MapGround {get;set;}

    }

    class MapOne : IMap
    {
        public int YLength { get; set; }

        public int XLength { get; set; }

        public int[,,] MapGround {get;set;} = new int[9,9,4];
        

        public MapOne()
        {
            this.YLength = 10;
            this.XLength = 10;
            //!to delete
            Console.WriteLine("test");
            mapInit();
        }

        private void mapInit(){
            StreamReader sr = new StreamReader("classes/Map/MapOne.txt");

            YLength = File.ReadAllLines("classes/Map/MapOne.txt").Length;
            XLength=YLength;

            string Line = "";

            MapGround = new int[YLength, XLength, 3];

            for (int i = 0; i <= (YLength-1) ; i++)
            {
                for (int j = 0; j <= (XLength-1); j++)
                {
                    MapGround[i, j, 0] = 0;
                }
            }
            for (int i = 0; (i <= XLength-1); i++)
            {
                Line = sr.ReadLine().ToString();

                int j = 0;
                if(i>=0)
                {
                    foreach (char terrain in Line)
                    {
                        if(terrain == '0')
                        {
                            MapGround[i, j,0] = 0;
                            j += 1;

                        }
                        if(terrain == '1')
                        {
                            MapGround[i, j,0] = 1;
                            j += 1;

                        }
                        if (terrain == '2')
                        {
                            MapGround[i, j, 0] = 2;
                            j += 1;

                        }
                        if(terrain == '3')
                        {
                            MapGround[i, j,0] = 3;
                            j += 1;

                        }
                    }
                }

            }
            sr.Close();
            //!to delete
            for (int i = 0; i <= (YLength-1) ; i++)
            {
                for (int j = 0; j <= (XLength-1); j++)
                {
                    Console.Write(MapGround[i, j, 0]);
                }
                Console.WriteLine();
            }
            
        }
    }


}