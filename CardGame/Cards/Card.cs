using System.Collections.Generic;

namespace CardGame.Cards
{

    public record Card
    {
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
                if (value >= maxHp)
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
        public int PosOnTheTable { get; set; }
        public List<CardAbility> Abilities { get; set; } // max is 3
        public Status CardStatus { get; set; }
        private string MakeNormal(string str)
        {
            string copy = str;
            int len = (19 - copy.Length) / 2;
            copy = copy.Insert(0, new string(' ', len));
            copy = copy.Insert(0, "*");
            if (str.Length % 2 == 0)
            {
                len++;
            }
            copy += new string(' ', len);
            copy += '*';
            return copy;

        }
        public void UpdateVisual()
        {
            Visual = new List<string>()
            {
                $"* * * * * * * * * * *",
                $"*                   *",
                MakeNormal(Name.ToString()),
                $"* * * * * * * * * * *",
                MakeNormal($"Status: {CardStatus}"),
                Abilities?.Count >= 1 ? MakeNormal(Abilities[0].Name.ToString()) : $"*                   *",
                Abilities?.Count >= 2 ? MakeNormal(Abilities[1].Name.ToString()) : $"*                   *",
                Abilities?.Count == 3 ? MakeNormal(Abilities[2].Name.ToString()) : $"*                   *",
                $"* * * * * * * * * * *",
                $"*   ATK      HP     *",
                MakeNormal(Atk.ToString() + "       " + Hp.ToString()),
                $"*                   *",
                $"*      ENERGY       *",
                MakeNormal(Energy.ToString()),
                $"* * * * * * * * * * *",

            };
        }
        public static string GetBack()
        {
            return $"* * * * * * * * * * *\n" +
                   $"*                   *\n" +
                   $"*  * * * * * * * *  *\n" +
                   $"*  *             *  *\n" +
                   $"*  *  * * * * *  *  *\n" +
                   $"*  *  *   *   *  *  *\n" +
                   $"*  *  * * * * *  *  *\n" +
                   $"*  *  *   *   *  *  *\n" +
                   $"*  *  * * * * *  *  *\n" +
                   $"*  *  *   *   *  *  *\n" +
                   $"*  *  * * * * *  *  *\n" +
                   $"*  *             *  *\n" +
                   $"*  * * * * * * * *  *\n" +
                   $"*                   *\n" +
                   $"* * * * * * * * * * *\n";
        }
        public string GetVisual()
        {
            UpdateVisual();
            
            string result = string.Empty;
            for (int i = 0; i < Visual.Count; i++)
            {
                result += Visual[i].ToString() + '\n';
            }
            return result;
        }
        public void GetDamage(Game game, IPlayable attackedPlayer, Card attackedCard)
        {
            for (int i = 0; i < Abilities?.Count; i++)
            {
                if (Abilities[i].Type == AbilityType.Defense)
                {
                    Abilities[i].Activate(game, attackedPlayer, attackedCard);
                }
            }
            this.Hp -= attackedCard.Atk;
        }
    }
}
