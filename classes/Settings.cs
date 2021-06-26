using System;
using System.Collections.Generic;

namespace tower_defense
{
    class Settings
    {
        public IDictionary<int,string> difficulteList{get;set;}
        
        public IDictionary<int,string> difficulteChoose{get;set;} = new Dictionary<int,string>();

        public Settings()
        {
            difficulteList= new Dictionary<int,string>{
                {1,"Facile"},
                {2,"Normale"},
                {3,"Difficile"}
            };
            //demander au joueur sa difficulté choisie dans la liste au dessus
            //ex boite de dialogue
        }
    }
}