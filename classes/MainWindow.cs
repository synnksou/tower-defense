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

            // Creates the top-level window to show
            var win = new Window("tower-defense")
            {
                X = 0,
                Y = 1, // Leave one row for the toplevel menu

                // By using Dim.Fill(), it will automatically resize without manual intervention
                Width = Dim.Fill(),
                Height = Dim.Fill()
            };
            top.Add(win);

            // Creates a menubar, the item "New" has a help menu.
            var menu = new MenuBar(new MenuBarItem[] {
               new MenuBarItem ("quitter", new MenuItem [] {
                    /*new MenuItem ("_New", "Creates new file", null),
                    new MenuItem ("_Close", "",null),*/
                    new MenuItem("Credit","", () => Credit()),
                    new MenuItem ("quitter", "", () => { if (Quit ()) top.Running = false; })
                }),/*
                new MenuBarItem ("_Edit", new MenuItem [] {
                    new MenuItem ("_Copy", "", null),
                    new MenuItem ("C_ut", "", null),
                    new MenuItem ("_Paste", "", null)
                })*/
            });
            top.Add(menu);

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

        static void Credit()
        {
            var top = Application.Top;
            var creditWindows = new Window("Credit")
            {
                X = 0,
                Y = 1,
                Width = Dim.Fill(),
                Height = Dim.Fill()
            };
            var stringCredit = new String("L'application Tower-Defense a été realisé en colaboration avec Flinois Dyklan, Brailly Julien, Heinrich Antoine ");
            var stringCreditAntoine = new String("Developpeur   Heinrich Antoine");
            var stringCreditDyklan = new String("Developpeur   Flinois Dyklan");
            var stringCreditJulien = new String("Developpeur   Brailly Julien");
            var credit = new Label(stringCredit) { X = 3, Y = 3 };
            var creditAntoine = new Label(stringCreditAntoine) { X = 3, Y = 5 };
            var creditDyklan = new Label(stringCreditDyklan) { X = 3, Y = 6 };
            var creditJulien = new Label(stringCreditJulien) { X = 3, Y = 7 };
            creditWindows.Add(credit);
            creditWindows.Add(creditAntoine);
            creditWindows.Add(creditDyklan);
            creditWindows.Add(creditJulien);
            top.Add(creditWindows);
            Application.Run(top);
        }

    }
}
