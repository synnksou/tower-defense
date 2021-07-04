using System;
using System.IO;
using Terminal.Gui;

namespace tower_defense
{
    interface IMap
    {
        int YLength { get; set; }

        int XLength { get; set; }

        int[,] MapGround {get;set;}

        View Map { get;set; }
        
    }

    class MapOne : IMap
    {
        private readonly Window windows;
        public int YLength { get; set; }

        public int XLength { get; set; }

        public int[,] MapGround {get;set;} = new int[9,9];
        public View Map { get; set; } = new View()
        {
            X = 10,
            Y = 10
        };
        

        

        public MapOne(Window windows)
        {
            this.YLength = 10;
            this.XLength = 10;
            this.windows = windows;
            mapInit();
        }

        private void mapInit()
        {
                StreamReader sr = new StreamReader("classes/Map/MapOne.txt");

            YLength = File.ReadAllLines("classes/Map/MapOne.txt").Length;
            XLength = YLength;

            string Line = "";

            MapGround = new int[YLength, XLength];

            for (int i = 0; i <= (YLength-1) ; i++)
            {
                for (int j = 0; j <= (XLength-1); j++)
                {
                    MapGround[i, j] = 0;
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
                            MapGround[i, j] = 0;
                            this.windows.Add( new Label("0")
                            {
                                X = i  + 50,
                                Y = j + 5
                            });
                            j += 1;
                        }
                        if(terrain == '1')
                        {
                            MapGround[i, j] = 1;
                            this.windows.Add( new Label("#")
                            {
                                X =i + 50,
                                Y = j + 5
                            });
                            j += 1;
                        }
                        if (terrain == '2')
                        {
                            MapGround[i, j] = 2;
                            this.windows.Add( new Label("H")
                            {
                                X =i + 50,
                                Y = j + 5
                            });
                            j += 1;
                        }
                        if(terrain == '3')
                        {
                            MapGround[i, j] = 3;
                            this.windows.Add( new Label("B")
                            {
                                X = i + 50,
                                Y = j + 5
                            });
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
                    Console.Write(MapGround[i, j]);
                }
                Console.WriteLine();
            }

            Label labelMapInfo = new Label(" ------ MAP INFO ------ ")
            {
                X = 43,
                Y = 3
            };
            this.windows.Add(labelMapInfo);

        }
    }


}