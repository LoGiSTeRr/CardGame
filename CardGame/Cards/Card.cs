using System.Collections.Generic;

namespace CardGame.Cards
{
    public abstract class CardAbility
    {

    }
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
                MakeNormal(Rarity.ToString()),
                $"*                   *",
                MakeNormal(Name.ToString()),
                $"*                   *",
                MakeNormal(Type.ToString()),
                $"*                   *",
                $"*   ATK      HP     *",
                MakeNormal(Atk.ToString() + "       " + Hp.ToString()),
                $"*                   *",
                $"*      ENERGY       *",
                MakeNormal(Energy.ToString()),
                $"*                   *",
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
    }
}
