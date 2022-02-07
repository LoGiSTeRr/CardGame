using System;
using Terminal.Gui;

namespace CardGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Application.Init();
            Colors.Base.Normal = Application.Driver.MakeAttribute(Color.Green, Color.Black);
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);

            Menu.DisplayMainMenu();
            Application.Run();
        }

    }
}
