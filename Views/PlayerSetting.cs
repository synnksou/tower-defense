using System;
using Terminal.Gui;

namespace tower_defense
{
    class PlayerSetting : Window
    {
        public Action<Player> OnSave { get; set; }
        public Action OnExit { get; set; }
        private readonly View _parent;

        public PlayerSetting(Player player, View parent)
        {
            _parent = parent;
            InitControls(player);
            InitStyle();
        }

        public void InitStyle()
        {
            X = Pos.Center();
            Width = Dim.Percent(50);
            Height = 17;
        }

        public void InitControls(Player player)
        {
            var top = Application.Top;
            #region layouts
            var creditWindows = new Window("Player Setting")
            {
                X = 0,
                Y = 1,
                Width = Dim.Fill(),
                Height = Dim.Fill()
            };
            var actualName = new Label(0, 1, "Bonjour " + player.pseudo);
            var nameLabel = new Label(1, 1, "Pseudo");
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
                OnSave?.Invoke(player);
                Console.WriteLine(player.pseudo);
                Close();
            };

            exitButton.Clicked += () =>
            {
                OnExit?.Invoke();
                Close();
            };

            #endregion


            Add(nameLabel);
            Add(nameText);
            Add(saveButton);
            Add(exitButton);
        }

        public void Close()
        {
            _parent?.Remove(this);
        }


    }
}
