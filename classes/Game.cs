using System;

namespace tower_defense
{
    class Game
    {
        private  Player player;

        private  Menu menu;

        private Settings settings;

        private Levels levels;

        public Game()
        {
            this.player = new Player();
            this.menu = new Menu();
            this.settings = new Settings();
            this.levels = new Levels();    
            Console.WriteLine("game init");
        }
    }
}