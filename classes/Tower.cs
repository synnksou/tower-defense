using System;
using System.Collections.Generic;

namespace tower_defense
{
    interface ITower
    {
        string Nom { get; set; }
        int? Puissance{ get; set;}
        ITower cloneTower();
        void degats();
    }

    class BaseTower : ITower
    {
        public string Nom{get; set;}

        public int? Puissance{ get; set;}

        public BaseTower(string nom)
        {
            this.Nom = nom;
            this.Puissance = 50 ;
        }

        public ITower cloneTower()
        {
            return new BaseTower(this.Nom);
        }

        public void degats(){
            Console.WriteLine("panpan");
        }
    }

}