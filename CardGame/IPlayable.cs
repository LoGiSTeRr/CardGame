using System.Collections.Generic;

namespace CardGame
{
    public interface IPlayable
    {
        public string Name { get; set; }
        public int LimitOfCards { get; init; }
        public List<Cards.Card> CardsInHand { get; set; }
        public List<Cards.Card> CardsOnTable { get; set; }
    }
}