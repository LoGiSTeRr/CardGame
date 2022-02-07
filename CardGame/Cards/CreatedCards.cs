using System.Collections.Generic;
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
                MaxHp = 5,
                Hp = 5,
                Energy = 4,
                CardStatus = Status.Sleep,
                Abilities = new List<CardAbility> 
                { 
                    new CardAbility() { Name = "Tank", Type = AbilityType.Defense, Activate = CreatedAbilities.Tank }
                }
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
                Energy = 2,
                CardStatus = Status.Sleep

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
                CardStatus = Status.Sleep,
                Abilities = new List<CardAbility> 
                { 
                    new CardAbility() { Name = "Energy buff", Type = AbilityType.Passive, Activate = CreatedAbilities.EnergyBuff }
                }

            };
        }
        public static Card GetKnightCard()
        {
            return new Card()
            {
                Name = "Knight",
                Atk = 4,
                MaxHp = 3,
                Hp = 3,
                Energy = 4,
                CardStatus = Status.Sleep

            };
        }
        public static Card GetSkeletonCard()
        {
            return new Card()
            {
                Name = "Skeleton",
                Atk = 1,
                MaxHp = 2,
                Hp = 2,
                Energy = 1,
                CardStatus = Status.Sleep

            };
        }
        public static Card GetLittleThornCard()
        {
            return new Card()
            {
                Name = "Little Thorn",
                Atk = 0,
                MaxHp = 2,
                Hp = 2,
                Energy = 1,
                CardStatus = Status.Sleep,
                Abilities = new List<CardAbility>
                {
                    new CardAbility() { Name = "Thorn", Type = AbilityType.Defense, Activate = CreatedAbilities.Thorn }
                }
            };
        }
        public static Card GetBigThornCard()
        {
            return new Card()
            {
                Name = "Big Thorn",
                Atk = 0,
                MaxHp = 5,
                Hp = 5,
                Energy = 3,
                CardStatus = Status.Sleep,
                Abilities = new List<CardAbility>
                {
                    new CardAbility() { Name = "Thorn", Type = AbilityType.Defense, Activate = CreatedAbilities.Thorn }
                }
            };
        }
        public static Card GetAssasinCard()
        {
            return new Card()
            {
                Name = "Assasin",
                Atk = 2,
                MaxHp = 2,
                Hp = 2,
                Energy = 3,
                CardStatus = Status.Sleep,
                Abilities = new List<CardAbility>
                {
                    new CardAbility() { Name = "Player Murder", Type = AbilityType.Attack, Activate = CreatedAbilities.PlayerMurder }
                }
            };
        }
        public static Card GetCardHaterCard()
        {
            return new Card()
            {
                Name = "Cards Hater",
                Atk = 2,
                MaxHp = 2,
                Hp = 2,
                Energy = 3,
                CardStatus = Status.Sleep,
                Abilities = new List<CardAbility>
                {
                    new CardAbility() { Name = "Card Murder", Type = AbilityType.Attack, Activate = CreatedAbilities.CardMurder }
                }
            };
        }
        public static Card GetCrazyDudeCard()
        {
            return new Card()
            {
                Name = "Crazy Dude",
                Atk = 7,
                MaxHp = 7,
                Hp = 7,
                Energy = 10,
                CardStatus = Status.Sleep,
                Abilities = new List<CardAbility>
                {
                    new CardAbility() { Name = "Card Murder", Type = AbilityType.Attack, Activate = CreatedAbilities.CardMurder },
                    new CardAbility() { Name = "Player Murder", Type = AbilityType.Attack, Activate = CreatedAbilities.PlayerMurder }
                }
            };
        }
        public static Card GetBigWarriorCard()
        {
            return new Card()
            {
                Name = "Big Warrior",
                Atk = 5,
                MaxHp = 5,
                Hp = 5,
                Energy = 6,
                CardStatus = Status.Sleep,
            };
        }
        public static Card GetNullCard()
        {
            return new Card();
        }
        
    }
}