using System;
using System.Collections.Generic;

namespace tower_defense
{
    class Levels
    {
        //find right attributs
        /*private List<string,int> settings = new List<string,int>{
            "score",null,
            };
        */

        private List<IEnnemie> Ennemies = new List<IEnnemie>();

        public Levels()
        {
            Infanterie inf = new Infanterie("soldat",null);
            Char char1 = new Char("Char",null);
            Ennemies.AddRange(new List<IEnnemie>
                {inf,char1}
            );
            Console.WriteLine(Ennemies[1].Puissance);
        }

        public List<IEnnemie> getEnnemies(){return Ennemies;}
    }
}