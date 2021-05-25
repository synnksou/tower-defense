using System;

namespace tower_defense
{
    class Game
    {
        private  Player player;

        private Settings settings;

        private Levels levels {get;set;}

        public Game()
        {
            this.player = new Player();
            this.settings = new Settings();
            this.levels = new Levels();    
            Console.WriteLine("game init");
        }

    }
}