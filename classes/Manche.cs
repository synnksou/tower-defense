using System.Linq;
using System;
using System.Collections.Generic;

namespace tower_defense
{
    class Manche
    {
        private List<IEnnemi> ennemies {get;set;} = new List<IEnnemi>();

        public Manche(int nb,IDictionary<int,string> difficulte)
        {
            Infanterie inf = new Infanterie("soldat",null);
            Char char1 = new Char("Char",null);
            

            for(int i=0;i<computeNbEnemies(nb);i++){
                this.ennemies.Add(computeEnemies(new Random().Next(2)));    
            }
            
            //!to delete
            Console.WriteLine("manche n°"+(nb));
            ennemies.ForEach(e => Console.WriteLine(e.Nom));
        }

        private int computeNbEnemies(int nb){
            switch(nb){
                case 0:
                return 5;
                case 1:
                return 6;
                case 2:
                return 7;
                case 3:
                return 8;
                case 4:
                return 9;
                case 5:
                return 10;
                case 6:
                return 11;
                case 7:
                return 12;
                case 8:
                return 13;
                case 9:
                return 14;
                case 10:
                return 16;
                case 11:
                return 18;
                case 12:
                return 20;
                case 13:
                return 22;
                case 14:
                return 25;
                default: 
                return nb;
            }
        }

        private IEnnemi computeEnemies(int nbAlea){
            switch(nbAlea){
                case 0:
                return new Infanterie("soldat",null);
                case 1:
                return new Char("Char",null);
                default:
                return new Infanterie("soldat",null);
            }
        }

    }
}