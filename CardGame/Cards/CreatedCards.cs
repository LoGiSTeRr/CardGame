namespace CardGame.Cards
{
    public static class CreatedCards
    {
        public static Card ShieldManCard = new Card()
        {
            Name = "ShieldMan",
            Atk = 2,
            MaxHp = 10,
            Hp = 10,
            Energy = 5,
            Type = Cards.CardType.Defense,
            Rarity = Cards.CardRarity.Legendary
        };
        public static Card WarriorCard = new Card()
        {
            Name = "Warrior",
            Atk = 10,
            MaxHp = 2,
            Hp = 2,
            Energy = 5,
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
    }
}