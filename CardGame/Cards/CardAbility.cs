using System;

namespace CardGame.Cards
{
    public class CardAbility
    {
        private string name;
        public string Name
        {
            get => name;
            set
            {
                if (Helper.IsNameValid(value))
                {
                    name = value;
                }
            }
        }
        public AbilityType Type { get; set; }
        public Action<Game, IPlayable, Card> Activate;
    }
}
