using System;
using ConsoleGUI;
using ConsoleGUI.Controls;
using ConsoleGUI.Space;

namespace tower_defense
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            ConsoleManager.Setup();

            ConsoleManager.Resize(new Size(150, 40));
            ConsoleManager.Content = new TextBlock { Text = "Hello world" };

        }
    }
}
