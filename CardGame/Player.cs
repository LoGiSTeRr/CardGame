using System.Collections.Generic;

namespace CardGame
{
    public class Player : IPlayable
    {
        public string Name { get; set; }
        public List<Cards.Card> CardsInHand { get; set; } = new List<Cards.Card>();
        public List<Cards.Card> CardsOnTable { get; set; } = new List<Cards.Card>();

    }
}