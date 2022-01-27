using System;
using Terminal.Gui;
namespace CardGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cards.Card card = new Cards.Card()
            {
                Name = "Test name",
                Atk = 2,
                Hp = 5,
                Energy = 5,
                Type = Cards.CardType.Defense,
                Rarity = Cards.CardRarity.Rare
            };
            Application.Init();

            MessageBox.Query(50, 7, "Question", "Do you like console apps?", "Yes", "No");

        }
    }
}
