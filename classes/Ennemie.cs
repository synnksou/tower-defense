using System;
using System.Collections.Generic;

namespace tower_defense
{
    interface IEnnemie
    {
        string Nom { get; set; }
        int? Puissance{ get; set;}
        int? Vie { get; set; }
        IEnnemie cloneEnnemie();
        void move();
    }

    class Infanterie : IEnnemie
    {
        public string Nom{get; set;}

        public int? Puissance{ get; set;}

        public int? Vie{ get; set;}
        public Infanterie(string nom,int? puissance)
        {
            this.Nom = nom;
            this.Puissance = puissance != null ? puissance : 50 ;
            this.Vie = 100;
        }

        public IEnnemie cloneEnnemie()
        {
            return new Infanterie(this.Nom, this.Puissance);
        }

        public void move()
        {
            Console.WriteLine("move");
        }

        public void tirer(){
            Console.WriteLine("panpan");
        }
    }

    class Char : IEnnemie
    {
        public string Nom{get; set;}
        public int? Puissance{ get; set;}
        public int? Vie{ get; set;}
        public Char(string nom,int? puissance){
            this.Nom = nom;
            this.Puissance = puissance != null ? puissance : 100 ;
            this.Vie = 500;
        }

        public IEnnemie cloneEnnemie(){
            return new Infanterie(this.Nom,this.Puissance);
        }

        public void move(){
            Console.WriteLine("move");
        }

        public void tirer(){
            Console.WriteLine("panpan");
        }

    }

}