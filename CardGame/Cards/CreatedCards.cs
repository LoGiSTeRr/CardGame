namespace CardGame.Cards
{
    public static class CreatedCards
    {
        public static Card ShieldManCard = new Card()
        {
            Name = "ShieldMan",
            Atk = 1,
            MaxHp = 6,
            Hp = 6,
            Energy = 2,
            Type = Cards.CardType.Defense,
            Rarity = Cards.CardRarity.Common
        };
        public static Card WarriorCard = new Card()
        {
            Name = "Warrior",
            Atk = 3,
            MaxHp = 2,
            Hp = 2,
            Energy = 3,
            Type = Cards.CardType.Attack,
            Rarity = Cards.CardRarity.Common
        };
        public static Card ReservoirCard = new Card()
        {
            Name = "Energy Reservoir",
            Atk = 0,
            MaxHp = 2,
            Hp = 2,
            Energy = 1,
            Type = Cards.CardType.Support,
            Rarity = Cards.CardRarity.Common
        };
        public static Card KnightCard = new Card()
        {
            Name = "Knight",
            Atk = 4,
            MaxHp = 2,
            Hp = 2,
            Energy = 5,
            Type = Cards.CardType.Attack,
            Rarity = Cards.CardRarity.Common
        };
        public static Card SkeletonCard = new Card()
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
}