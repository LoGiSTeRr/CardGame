using System.Collections.Generic;

namespace CardGame
{
    public class Player : IPlayable
    {
        public Player()
        {
            LimitOfCards = 8;
            AmountOfPoints = 0;
            CardWasTaken = false;
        }
        public string Name { get; set; }
        public int LimitOfCards { get; init; }
        public float Energy { get; set; }
        public int AmountOfPoints { get; set; }
        public bool CardWasTaken { get; set; }
        public List<Cards.Card> CardsInHand { get; set; } = new List<Cards.Card>();
        public List<Cards.Card> CardsOnTable { get; set; } = new List<Cards.Card>() { Cards.CreatedCards.GetNullCard(), Cards.CreatedCards.GetNullCard(), Cards.CreatedCards.GetNullCard(), Cards.CreatedCards.GetNullCard() };

    }
}