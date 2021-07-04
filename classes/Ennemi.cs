using System;
using System.Collections.Generic;

namespace tower_defense
{
    interface IEnnemi
    {
        (int, int,int) coord {get;set;}
        string Nom { get; set; }
        int Puissance{ get; set;}
        int? Vie { get; set; }
        IEnnemi cloneEnnemi();
        int Degats();
        void TakeDegats(int nb);
        void Move(IMap map);
    }

    class Infanterie : IEnnemi
    {
        public (int, int,int) coord {get;set;}
        public string Nom{get; set;}
        public int Puissance{ get; set;}
        public int? Vie{ get; set;}
        
        public Infanterie(string nom,int? puissance)
        {
            this.Nom = nom;
            this.Puissance = 50 ;
            this.Vie = 100;
            this.coord = (0,0,1);
        }

        public IEnnemi cloneEnnemi()
        {
            return new Infanterie(this.Nom, this.Puissance);
        }

        public void Move(IMap map)
        {
            int myX = this.coord.Item1;
            int myY = this.coord.Item2;
            bool Next = true;
            while(Next){
                if(map.MapGround[myX+1,myY] == 2){
                    Next= !Next;
                    this.coord = (myY+1,myY,2);
                }
                if(map.MapGround[myX,myY-1] == 2){
                    Next= !Next;
                    this.coord = (myY+1,myY+1,2);
                }
                if(map.MapGround[myX+1,myY] == 3){
                    Next= !Next;
                    this.coord = (myY+1,myY,3);
                }
                if(map.MapGround[myX,myY-1] == 3){
                    Next= !Next;
                    this.coord = (myY+1,myY+1,3);
                }
            }
        }

        public int Degats(){
            return this.Puissance;
        }

        public void TakeDegats(int nb){
            this.Vie-= nb;
        }
    }

    class Char : IEnnemi
    {
        public (int, int,int) coord {get;set;}
        public string Nom{get; set;}
        public int Puissance{ get; set;}
        public int? Vie{ get; set;}

        public Char(string nom,int? puissance){
            this.Nom = nom;
            this.Puissance = 100 ;
            this.Vie = 500;
        }

        public IEnnemi cloneEnnemi(){
            return new Infanterie(this.Nom,this.Puissance);
        }

        public void Move(IMap map )
        {
            int myX = this.coord.Item1;
            int myY = this.coord.Item2;
            bool Next = true;
            while(Next){
                if(map.MapGround[myX+1,myY] == 2){
                    Next= !Next;
                    this.coord = (myY+1,myY,2);
                }
                if(map.MapGround[myX,myY-1] == 2){
                    Next= !Next;
                    this.coord = (myY+1,myY+1,2);
                }
                if(map.MapGround[myX+1,myY] == 3){
                    Next= !Next;
                    this.coord = (myY+1,myY,3);
                }
                if(map.MapGround[myX,myY-1] == 3){
                    Next= !Next;
                    this.coord = (myY+1,myY+1,3);
                }
            }
        }

        public int Degats(){
            return this.Puissance;
        }

        public void TakeDegats(int nb){
            this.Vie-= nb;
        }

    }

}