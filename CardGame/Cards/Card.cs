using System.Collections.Generic;

namespace CardGame.Cards
{

    public class Card
    {
        public Card()
        {
            Visual = new List<string>()
            {
                $"* * * * * * * * * * *",
                $"*                   *",
                $"*      {Rarity}       *",
                $"*                   *",
                $"*       {Name}        *",
                $"*                   *",
                $"*     {Type}      *",
                $"*                   *",
                $"*                   *",
                $"*   ATK  DEF   HP   *",
                $"*    {Atk}    {Def}    {Hp}    *",
                $"*                   *",
                $"*      ENERGY       *",
                $"*         {Energy}         *",
                $"*                   *",
                $"* * * * * * * * * * *",
            };
        }

        public List<string> Visual { get; set; }
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

        private int maxHp;
        public int MaxHp
        {
            get => maxHp;
            set
            {
                if (value > 0)
                {
                    maxHp = value;
                }
            }
        }

        private int hp;
        public int Hp
        {
            get => hp;
            set
            {
                if (value <= 0)
                {
                    hp = 0;
                }
                else if (value >= maxHp)
                {
                    hp = maxHp;
                }
                else
                {
                    hp = value;
                }
            }
        }

        private int atk;
        public int Atk
        {
            get => atk;
            set
            {
                if (value > 0)
                {
                    atk = value;
                }
            }
        }

        private int def;
        public int Def
        {
            get => def;
            set
            {
                if (value > 0)
                {
                    def = value;
                }
            }
        }

        private int energy;
        public int Energy
        {
            get => energy;
            set
            {
                if (value > 0)
                {
                    energy = value;
                }
            }
        }
        public CardRarity Rarity { get; set; } = new CardRarity();
        public CardType Type { get; set; } = new CardType();

        public void Display()
        {
            for (int i = 0; i < Visual.Count; i++)
            {
                System.Console.WriteLine(Visual[i]);
            }
        }
    }
}
