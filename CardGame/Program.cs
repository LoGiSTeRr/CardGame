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
            game.CardsInStock.Add(Cards.CreatedCards.ShieldManCard);
            game.CardsInStock.Add(Cards.CreatedCards.WarriorCard);
            game.Players.Add(pl1);
            game.Players.Add(pl2);
            pl1.CardsOnTable[2] = Cards.CreatedCards.ShieldManCard;
            pl2.CardsOnTable[0] = Cards.CreatedCards.WarriorCard;
            game.DisplayGame(false);
            Application.Run();

        }

    }
}
