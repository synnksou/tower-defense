using System;

namespace tower_defense
{
    class Base
    {
        public int vie { get; set; }

        public Base()
        {
            this.vie = 1000;
        }

        public void Degats(int nb){
            this.vie-= nb;
            homeState();
        }

        private void homeState(){
            switch(this.vie){
                case 500:
                Console.WriteLine("il reste 50% de vie a la base");
                return;
                case 250:
                Console.WriteLine("il reste 25% de vie a la base");
                return;
                case <=0:
                Console.WriteLine("Il ne vous reste plus de vie");
                return;
            }
        }
    }
}
