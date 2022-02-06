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


            Player pl1 = new Player() { Name = "test1" };
            Player pl2 = new Player() { Name = "test2" };
            Game game = new Game();
            game.StartGame(pl1, pl2);
            Application.Run();
        }

    }
}
