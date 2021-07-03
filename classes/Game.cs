using System.Linq;
using System;
using System.Collections.Generic;

namespace tower_defense
{
    class Game
    {
        private  Player player{get;set;}
        private Settings settings{get;set;}
        private IList<Manche> manches {get;set;} = new List<Manche>();
        private Base home{get;set;}

        private MapOne mapOne{get;set;}

        private int nbManches {get;set;}

        public Game(Player player)
        {
            this.player = player;
            
            Console.WriteLine(player.pseudo);

            this.settings = new Settings();
            this.home = new Base();
            this.mapOne = new MapOne();
            
            settings.difficulteChoose.Add(settings.difficulteList.Single(diff => diff.Key == 1));

            int difficulte = settings.difficulteChoose.First().Key;

            ComputeNbManches(difficulte);

            //! to delete
            Console.WriteLine("nb manche :"+this.nbManches);


            for(int i=0;i<nbManches;i++){
                this.manches.Append(new Manche(i+1,settings.difficulteChoose));    
            }

            this.manches.ToString();

            //!to delete
            Console.WriteLine("game init");

            //Launch();
        }

        private void ComputeNbManches(int? diff = 2){
            switch (diff)
            {
                case 1: 
                this.nbManches = 5;
                return;
                
                case 2: 
                this.nbManches = 10;
                return;

                case 3: 
                this.nbManches = 15;
                return;

                default: this.nbManches = 10;
                return;
            }
        }

        private void Launch(){
            int i=0;
            while(this.manches.Count!=0 || this.home.vie == 0){
                while(this.manches[i].ennemies.Count!=0 || this.home.vie == 0){
                    
                }
                i++;
            }
        }

        private void Enemiesove(IEnnemi E){
            E.Move(this.mapOne);
        }
    }
}