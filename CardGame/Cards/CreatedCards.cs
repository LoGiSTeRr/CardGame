namespace CardGame.Cards
{
    public class CreatedCards
    {
        public static Card GetShieldManCard()
        {
            return new Card()
            {
                Name = "ShieldMan",
                Atk = 1,
                MaxHp = 6,
                Hp = 6,
                Energy = 2,
                Type = Cards.CardType.Defense,
                Rarity = Cards.CardRarity.Common
            };
        }
        public static Card GetWarriorCard()
        {
            return new Card()
            {
                Name = "Warrior",
                Atk = 3,
                MaxHp = 2,
                Hp = 2,
                Energy = 3,
                Type = Cards.CardType.Attack,
                Rarity = Cards.CardRarity.Common
            };
        }
        public static Card GetReservoirCard()
        {
            return new Card()
            {
                Name = "Energy Reservoir",
                Atk = 0,
                MaxHp = 2,
                Hp = 2,
                Energy = 1,
                Type = Cards.CardType.Support,
                Rarity = Cards.CardRarity.Common
            };
        }
        public static Card GetKnightCard()
        {
            return new Card()
            {
                Name = "Knight",
                Atk = 5,
                MaxHp = 2,
                Hp = 2,
                Energy = 5,
                Type = Cards.CardType.Attack,
                Rarity = Cards.CardRarity.Common
            };
        }
        public static Card GetSkeletonCard()
        {
            return new Card()
            {
                Name = "Skeleton",
                Atk = 2,
                MaxHp = 2,
                Hp = 2,
                Energy = 2,
                Type = Cards.CardType.Attack,
                Rarity = Cards.CardRarity.Common
            };
        }
        public static Card GetNullCard()
        {
            return new Card();
        }
        
    }
}