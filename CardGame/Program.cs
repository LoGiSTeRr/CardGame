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
            
            Cards.Card card1 = new Cards.Card()
            {
                Name = "ShieldMan",
                Atk = 2,
                MaxHp = 10,
                Hp = 10,
                Energy = 5,
                Type = Cards.CardType.Defense,
                Rarity = Cards.CardRarity.Legendary
            };
            Cards.Card card2 = new Cards.Card()
            {
                Name = "Warrior",
                Atk = 10,
                MaxHp = 2,
                Hp = 2,
                Energy = 5,
                Type = Cards.CardType.Attack,
                Rarity = Cards.CardRarity.Common
            };
            Player pl1 = new Player() { Name = "test1"};
            Player pl2 = new Player() { Name = "test2" };
            for (int i = 0; i < 8; i++) { pl1.CardsInHand.Add(card1); }
            for (int i = 0; i < 4; i++) { pl2.CardsInHand.Add(card2); }
            Game game = new Game();
            game.Players.Add(pl1);
            game.Players.Add(pl2);
            pl1.CardsOnTable[2] = card1;
            pl2.CardsOnTable[0] = card2;
            game.DisplayGame(false);
            Application.Run();

        }

    }
}
