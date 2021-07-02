using NAudio;
using System;
using Terminal.Gui;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System.Threading;
namespace tower_defense
{
    class MainWindow
    {
        private Pos x = Pos.Center();
        private Pos y = Pos.Center();
        public Dialog buttons { get; set; }

        //Ref Sounds
        static public String url = @"./sounds/doom-eternal-ost.wav";
        static public AudioFileReader audioFile = new AudioFileReader(url);
        static public WaveOutEvent outputDevice = new WaveOutEvent();
        static public VolumeSampleProvider volume = new VolumeSampleProvider(audioFile.ToSampleProvider());

        public MainWindow()
        {
            #region mainwindow
            Application.Init();
            var top = Application.Top;
            var player = new Player();

            var win = new Window("tower-defense")
            {
                X = 0,
                Y = 1,

                Width = Dim.Fill(),
                Height = Dim.Fill()

            };
            win.ColorScheme = Colors.Dialog;
            top.Add(win);

            #endregion

            #region menu

            var welcome = new Label("Bienvenu") { X = x, Y = 0 };
            var name = new Label(player.pseudo) { X = x, Y = 1 };
            var topMenu = new Label("F9 pour acceder au top menu") { X = x, Y = (y + y) };
            win.Add(
                welcome,
                name,
                MenuView(top),
                topMenu
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
               new MenuBarItem ("Option/Quitter", new MenuItem [] {
                    new MenuItem ("Accueil" , "" , () => Application.Run(top)),
                    new MenuItem ("Player Setting" , "" , () => playerSettingMethod(playerSetting)),
                    new MenuItem ("Quitter", "", () => { if (Quit ()) top.Running = false; })
                }),
            });
            top.Add(menu);
            #endregion

            //playerSettingMethod(playerSetting);

            volume.Volume = 0.2f;
            outputDevice.Init(volume);
            outputDevice.Play();


            Application.Run();
        }

        static bool Quit()
        {
            var n = MessageBox.Query(50, 7, "Quitter le jeu", "Etes vous sure de vouloir quitter le jeu", "oui", "non");
            return n == 0;
        }

        static void playerSettingMethod(PlayerSetting playerSetting)
        {
            Application.Run(playerSetting);
        }

        public Dialog MenuView(View top)
        {
            var gameButton = new Button("Jeu", false)
            {
                X = x,
                Y = y,
            };

            gameButton.Clicked += () =>
            {

                Game();
            };

            var settingsButton = new Button("Options", false)
            {
                X = x,
                Y = Pos.Bottom(gameButton) + 1
            };

            settingsButton.Clicked += () =>
            {
                Settings(outputDevice);
            };

            var helpButton = new Button("Aide", false)
            {
                X = x,
                Y = Pos.Bottom(settingsButton) + 1
            };

            helpButton.Clicked += () =>
            {
                HelpView();
            };

            var creditButton = new Button("Credit", false)
            {
                X = x,
                Y = Pos.Bottom(helpButton) + 1
            };

            creditButton.Clicked += () =>
            {
                Credit();
            };

            buttons = new Dialog("Menu");

            buttons.Add(
                gameButton,
                settingsButton,
                helpButton,
                creditButton);

            return buttons;
        }

        public void Game()
        {
            Game game = new Game("test");
        }

        public void Credit()
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

            #region buttons

            var exitButton = new Button("Exit", false)
            {
                X = Pos.Bottom(creditJulien),
                Y = Pos.Bottom(creditJulien) + 5
            };
            #endregion

            #region bind-button-events*


            exitButton.Clicked += () =>
            {
                Application.Run();
            };

            #endregion

            creditWindows.Add(credit);
            creditWindows.Add(creditAntoine);
            creditWindows.Add(creditDyklan);
            creditWindows.Add(creditJulien);
            creditWindows.Add(exitButton);
            top.Add(creditWindows);
            Application.Run(top);
        }

        public void Settings(WaveOutEvent outputDevice)
        {
            var top = Application.Top;
            var view = new View("MenuView");
            var optionsWindows = new Window("Options")
            {
                X = 0,
                Y = 1,
                Width = Dim.Fill(),
                Height = Dim.Fill()
            };

            var title = new String("Settings Game");
            var sound = new String("Play Music / Stop Music");
            var titleLabel = new Label(title) { X = 3, Y = 5 };
            var soundLabel = new Label(sound) { X = 3, Y = 6 };

            #region buttons
            var soundIsOff = false;

            var changeStringButton = new String("Stop");
            var buttonSound = new Button(changeStringButton, false)
            {
                X = 50,
                Y = 6
            };

            var exitButton = new Button("Exit", false)
            {
                X = Pos.Bottom(soundLabel),
                Y = Pos.Bottom(soundLabel) + 5
            };
            #endregion

            #region bind-button-events*

            buttonSound.Clicked += () =>
            {
                if (!soundIsOff)
                {
                    outputDevice.Stop();
                    changeStringButton = "Play";
                    soundIsOff = true;
                }
                else
                {
                    outputDevice.Play();
                    changeStringButton = "Stop";
                    soundIsOff = false;
                }
            };

            exitButton.Clicked += () =>
            {
                Application.Run();
            };

            #endregion

            optionsWindows.Add(titleLabel, soundLabel, buttonSound, exitButton);
            top.Add(optionsWindows);
            Application.Run(top);
        }

        public void HelpView()
        {
            
            var top = Application.Top;
            #region layouts
            var helpWindows = new Window("Page d'aide")
            {
                X = 0,
                Y = 1,
                Width = Dim.Fill(),
                Height = Dim.Fill()
            };
            helpWindows.ColorScheme = Colors.Dialog;

            var title = new Label(1, 1, "Le Tower defense");

            var help = new Label("Le Tower defense est un type de jeux qui consiste à defendre ça zone !") { 
                X = Pos.Bottom(title)-1,
                Y = Pos.Bottom(title)+1 };

            var detail = new Label("Les ennemies arriveront successivement et il faudra les tuer avant qu'ils vous atteignent :) \r\nÉquiper votre base, pour éviter aux ennemis de si introduire.\r\nLes différents items possèdes différentes cadencent de tirs ou peux lancer plusieurs missiles d'un cout, mais coute plus chére.\r\nPour ce faire, vous les sélectionnerez à laide des flèches clavier. Puis placez votre équipement sur l'un des emplacements libre, \r\nqui n'est pas sur un obstacle mais qui est suffisement proche du chemin des ennemies."){
                X = Pos.Bottom(help)-3,
                Y = Pos.Bottom(help)+1 };

            #endregion

            #region buttons

            var exitButton = new Button("F9 pour accéder au top menu",false)
            {
                X = Pos.Bottom(detail),
                Y = Pos.Bottom(detail)+5
            };

            exitButton.Clicked += ()=>
                {
                    MenuView(top);
                };
            #endregion


            helpWindows.Add(title);
            helpWindows.Add(help);
            helpWindows.Add(detail);
            helpWindows.Add(exitButton);
            top.Add(helpWindows);
            Application.Run(top);
        }

    }
}
