using System;
using System.Collections.Generic;
using Terminal.Gui;
namespace CardGame
{
    public interface IPlayable
    {
        public string Name { get; set; }
        public List<Cards.Card> CardsInHand { get; set; }
        public List<Cards.Card> CardsOnTable { get; set; }
    }
    public class Player : IPlayable
    {
        public string Name { get; set; }
        public List<Cards.Card> CardsInHand { get; set; } = new List<Cards.Card>();
        public List<Cards.Card> CardsOnTable { get; set; } = new List<Cards.Card>();

    }
    public class Game
    {
        private List<IPlayable> players { get; set; } = new List<IPlayable>();
        private List<Cards.Card> cardsInStock { get; set; } = new List<Cards.Card>();

        public void DisplayGame()
        {

        }
    }
    internal class Program
    {

        static void Main(string[] args)
        {
            Application.Init();
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
            card1.UpdateVisual();
            card2.UpdateVisual();
            Colors.Base.Normal = Application.Driver.MakeAttribute(Color.Green, Color.Black);
            var mainScreen = new Window()
            {
                X = 0,
                Y = 0,
                Width = Dim.Fill(),
                Height = Dim.Fill(),

            };
            var yourHand = new Window()
            {
                X = Pos.Center(),
                Y = Pos.Center() + 15,
                Width = 65,
                Height = 20,

            };
            mainScreen.Add(yourHand);
            yourHand.Add(new Label(card1.GetVisual()) { X = 5, Y = 1 });
            yourHand.Add(new Label(card2.GetVisual()) { X = 30, Y = 1 });
            
            Application.Top.Add(mainScreen);
            
            Application.Run();

        }

    }
}
