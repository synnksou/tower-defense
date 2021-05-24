using System;
using System.Collections.Generic;
using Terminal.Gui;
using NStack;

namespace tower_defense
{
    class MainWindow
    {

        public MainWindow(List<IEnnemie> Ennemies)
        {
            Application.Init();
            var top = Application.Top;
            var player = new Player();
            var win = new Window("MyApp")
            {
                X = 0,
                Y = 1, // Leave one row for the toplevel menu

                // By using Dim.Fill(), it will automatically resize without manual intervention
                Width = Dim.Fill(),
                Height = Dim.Fill()
            };
            top.Add(win);

            // Creates a menubar, the item "New" has a help menu.

            static bool Quit()
            {
                var n = MessageBox.Query(50, 7, "Quitter le jeu", "Etes vous sure de vouloir quitter le jeu", "oui", "non");
                return n == 0;
            }


            var login = new Label(Ennemies[0].Nom + Ennemies[0].Puissance + Ennemies[0].Vie) { X = 3, Y = 2 };
            var welcome = new Label("Bienvenu") { X = 3, Y = 0 };
            var name = new Label(player.pseudo) { X = 3, Y = 1 };


            win.Add(
                login,
                welcome,
                name,
                new Label(3, 18, "F9 pour acceder au top menu")
            );

            var playerSetting = new PlayerSetting(player, top)
            {
                OnExit = Application.RequestStop,
                OnSave = (player) =>
                {
                    Application.MainLoop.Invoke(() =>
                    {
                        name.Text = player.pseudo;
                    });
                    Application.Run();
                }
            };

             var menu = new MenuBar(new MenuBarItem[] {
               new MenuBarItem ("quitter", new MenuItem [] {
                    new MenuItem ("Player Setting" , "" , () => playerSettingMethod(playerSetting)),
                    new MenuItem ("quitter", "", () => { if (Quit ()) top.Running = false; })
                }),
            });
            top.Add(menu);


            Application.Run();
        }

        static void playerSettingMethod(PlayerSetting playerSetting)
        {
            Application.Run(playerSetting);
        }

    }
}
