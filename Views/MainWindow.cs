using NAudio;
using System;
using Terminal.Gui;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
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
            var topMenuLabel = new Label("F9 pour acceder au top menu") { X = x, Y = (y + y) };
            win.Add(
                welcome,
                MenuView(win,player,top),
                topMenuLabel
            );

            

            var menu = new MenuBar(new MenuBarItem[] {
               new MenuBarItem ("Option/Quitter", new MenuItem [] {
                    new MenuItem ("Accueil" , "" , () => {
                    top.Remove(top.Focused);
                    top.Add(win);
                    Application.Run();
                    }),
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

        public Dialog MenuView(Window previousWin,Player player,Toplevel top)
        {
            
            var gameButton = new Button("Jeu", false)
            {
                X = x,
                Y = y,
            };

            gameButton.Clicked += () =>
            {
                ChoosePseudoToLaunchGame(player,previousWin);
            };

            var settingsButton = new Button("Options", false)
            {
                X = x,
                Y = Pos.Bottom(gameButton) + 1
            };

            settingsButton.Clicked += () =>
            {
                Settings(outputDevice,previousWin);
            };

            var helpButton = new Button("Aide Jeu", false)
            {
                X = x,
                Y = Pos.Bottom(settingsButton) + 1
            };

            helpButton.Clicked += () =>
            {
                HelpView(previousWin);
            };

            var creditButton = new Button("Credits", false)
            {
                X = x,
                Y = Pos.Bottom(helpButton) + 1
            };

            creditButton.Clicked += () =>
            {
                Credit(previousWin);
            };

            buttons = new Dialog("Menu");

            buttons.Add(
                gameButton,
                settingsButton,
                helpButton,
                creditButton);

            return buttons;
        }

        
        static void ChoosePseudoToLaunchGame(Player player,Window previousWin)
        {
            var top = Application.Top;
            #region layouts
            var PseudoWindow = new Window("Choisit ton pseudo")
            {
                X = 0,
                Y = 1,
                Width = Dim.Fill(),
                Height = Dim.Fill()
            };

            PseudoWindow.ColorScheme = Colors.Dialog;

            var nameLabel = new Label(3, 5, "Pseudo");

            var nameText = new TextField("")
            {
                X = Pos.Left(nameLabel),
                Y = Pos.Top(nameLabel) + 1,
                Width = Dim.Fill()
            };
            #endregion

            #region buttons
            var saveButton = new Button("Sauver", false)
            {
                X = Pos.Left(nameText) + 1,
                Y = Pos.Top(nameText) + 1
            };

            var exitButton = new Button("Exit")
            {
                X = Pos.Right(saveButton) + 5,
                Y = Pos.Top(saveButton)
            };
            #endregion

            #region bind-button-events*

            saveButton.Clicked += () =>
            {
                if (nameText.Text.ToString().TrimStart().Length == 0)
                {
                    MessageBox.ErrorQuery(25, 8, "Erreur", "Pseudo ne peut etre vide", "Ok");
                    return;
                }
                player.pseudo = nameText.Text.ToString();
                Console.WriteLine(player.pseudo);
                Game(player);
            };

            exitButton.Clicked += () =>
            {
                top.Remove(PseudoWindow);
                top.Add(previousWin);
                Application.Run();
            };

            #endregion


            PseudoWindow.Add(nameLabel);
            PseudoWindow.Add(nameText);
            PseudoWindow.Add(saveButton);
            PseudoWindow.Add(exitButton);

            top.Remove(previousWin);
            top.Add(PseudoWindow);
            Application.Run();
        }

        public static void Game(Player player)
        {
            Game game = new Game(player);
        }

        public void Credit(Window previousWin)
        {
            var top = Application.Top;
            var creditWindows = new Window("Credit")
            {
                X = 0,
                Y = 1,
                Width = Dim.Fill(),
                Height = Dim.Fill()
            };

            creditWindows.ColorScheme = Colors.Dialog;


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
                top.Remove(creditWindows);
                top.Add(previousWin);
                Application.Run();
            };

            #endregion

            creditWindows.Add(credit);
            creditWindows.Add(creditAntoine);
            creditWindows.Add(creditDyklan);
            creditWindows.Add(creditJulien);
            creditWindows.Add(exitButton);

            top.Remove(previousWin);
            top.Add(creditWindows);
            Application.Run();
        }

        public void Settings(WaveOutEvent outputDevice,Window previousWin)
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

            optionsWindows.ColorScheme = Colors.Dialog;
            

            var title = new String("Settings Game");
            var sound = new String("Play Music / Stop Music");
            var titleLabel = new Label(title) { X = 3, Y = 5 };
            var soundLabel = new Label(sound) { X = 3, Y = 6 };

            #region buttons
            var soundIsOff = false;

            var changeStringButton = new String("Stop");
            var buttonSound = new Button(changeStringButton)
            {
                X = 50,
                Y = 6
            };

            var exitButton = new Button("Exit")
            {
                X = Pos.Bottom(soundLabel),
                Y = Pos.Bottom(soundLabel) + 5
            };
            #endregion

            #region bind-button-events

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
                top.Remove(optionsWindows);
                top.Add(previousWin);
                Application.Run();
            };

            #endregion

            optionsWindows.Add(titleLabel, soundLabel, buttonSound, exitButton);
            top.Remove(previousWin);
            top.Add(optionsWindows);
            Application.Run();

        }

        public void HelpView(Window previousWin)
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

            var comandes = new Label("Au début déburt de partie vous aurez 100points , de quoi achter une tour \r\nA chaque enemie tué vous gagner un nombre de point en fonctions de sa puissance \r\nUtilisez les fleches pour choisir la Tour a acheter puis [Entrer] pour valider l'achat \r\nUne fois la tour achetée placé la sur un terrain contructible \r\nLa tour tire automatiquement et sans aucune intervention de choix de cible \r\nVeillez sur notre base camarade !"){
                X = Pos.Bottom(detail)-9,
                Y = Pos.Bottom(detail)+1};

            #endregion

            #region buttons

            var exitButton = new Button("exit",false)
            {
                X = Pos.Bottom(comandes),
                Y = Pos.Bottom(comandes)+5
            };

            exitButton.Clicked += () =>
            {
                top.Remove(helpWindows);
                top.Add(previousWin);
                Application.Run();
            };
            #endregion


            helpWindows.Add(title);
            helpWindows.Add(help);
            helpWindows.Add(detail);
            helpWindows.Add(comandes);
            helpWindows.Add(exitButton);

            top.Remove(previousWin);
            top.Add(helpWindows);
            Application.Run(top);
        }

    }
}
