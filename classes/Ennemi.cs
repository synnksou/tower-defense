using System;
using System.Collections.Generic;

namespace tower_defense
{
    interface IEnnemi
    {
        string nom { get; set; }
        int? puissance{ get; set;}
        int? vie { get; set; }
        IDictionary<int,int> Coord {get;set;}
        IEnnemi cloneEnnemi();
        void move();
        void degats();
        void TakeDegats(int nb);
    }

    class Infanterie : IEnnemi
    {
        public string nom{get; set;}
        public int? puissance{ get; set;}
        public int? vie{ get; set;}
        public IDictionary<int,int> Coord {get;set;} = new Dictionary<int,int>();
        
        public Infanterie(string nom,int? puissance)
        {
            this.nom = nom;
            this.puissance = puissance != null ? puissance : 50 ;
            this.vie = 100;
        }

        public IEnnemi cloneEnnemi()
        {
            return new Infanterie(this.nom, this.puissance);
        }

        public void move()
        {
            Console.WriteLine("move");
        }

        public void degats(){
            Console.WriteLine("panpan");
        }

        public void TakeDegats(int nb){
            this.vie-= nb;
        }
    }

    class Char : IEnnemi
    {
        public string nom{get; set;}
        public int? puissance{ get; set;}
        public int? vie{ get; set;}
        public IDictionary<int,int> Coord {get;set;} = new Dictionary<int,int>();

        public Char(string nom,int? puissance){
            this.nom = nom;
            this.puissance = puissance != null ? puissance : 100 ;
            this.vie = 500;
        }

        public IEnnemi cloneEnnemi(){
            return new Infanterie(this.nom,this.puissance);
        }

        public void move(){
            Console.WriteLine("move");
        }

        public void degats(){
            Console.WriteLine("panpan");
        }

        public void TakeDegats(int nb){
            this.vie-= nb;
        }

    }

}