using System;
using System.Collections.Generic;

namespace tower_defense
{
    class Menu
    {
        private List<string> menu ;
        private int? choice;

        public Menu()
        {
            this.choice = null;
            this.menu = new List<string>{
                "jouer",
                "aide",
                "option",
                "quitter"
            };
        }
    }
}