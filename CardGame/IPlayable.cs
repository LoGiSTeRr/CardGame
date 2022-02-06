using System.Collections.Generic;

namespace CardGame
{
    public interface IPlayable
    {
        public string Name { get; set; }
        public int LimitOfCards { get; init; }
        public int AmountOfPoints { get; set; }
        public float Energy { get; set; }
        public bool CardWasTaken { get; set; }
        public List<Cards.Card> CardsInHand { get; set; }
        public List<Cards.Card> CardsOnTable { get; set; }
    }
}