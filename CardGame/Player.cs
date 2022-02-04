﻿using System.Collections.Generic;

namespace CardGame
{
    public class Player : IPlayable
    {
        public Player()
        {
            LimitOfCards = 8;
            DamageRecieved = 0;
        }
        public string Name { get; set; }
        public int LimitOfCards { get; init; }
        public int DamageRecieved { get; set; }
        public int AmountOfPoints { get; set; }
        public List<Cards.Card> CardsInHand { get; set; } = new List<Cards.Card>();
        public List<Cards.Card> CardsOnTable { get; set; } = new List<Cards.Card>() { null, null, null, null};

    }
}