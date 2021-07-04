using System.Linq;
using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using Terminal.Gui;

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

        public Game(Player player, Window prevWindows)
        {
            this.player = player;
            var top = Application.Top;
            var gameWindows = new Window();

            this.settings = new Settings();
            this.home = new Base();
            this.mapOne = new MapOne(gameWindows);
            
            settings.difficulteChoose.Add(settings.difficulteList.Single(diff => diff.Key == 1));

            int difficulte = settings.difficulteChoose.First().Key;

            ComputeNbManches(difficulte);

          


            for(int i=0;i<nbManches;i++){
                this.manches.Append(new Manche(i+1,settings.difficulteChoose));    
            }

            this.manches.ToString();

         
            #region attributs_Gui.cs
            Label labelGameInfo = new Label("------ GAME INFO ------")
            {
                X = 3,
                Y = 3,
            };
            Label labelPseudo = new Label("Pseudo : " + player.pseudo)
            {
                X = 3,
                Y = 4,
            };
            Label labelManche = new Label("Nombre de Manches : " + nbManches)
            {
                X = 3,
                Y = 5,
            };
            Label labelDiff = new Label("Difficulté : " + difficulte)
            {
                X = 3,
                Y = 6,
            };
            Label LabelInfoMapGame = new Label(" # =  Depart Ennemi  \r\n B = Finalité a protégés  \r\n H = Chemin Ennemi \r\n 0 = Emplacement tours sur la carte "){
                X = 3,
                Y = 10
            };
          
            #endregion

          
            gameWindows.Add(labelGameInfo,labelManche,labelPseudo,labelDiff,LabelInfoMapGame);
            top.Remove(prevWindows);
            gameWindows.ColorScheme = Colors.Dialog;
            top.Add(gameWindows);
            Application.Run();
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