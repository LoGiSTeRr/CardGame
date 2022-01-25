using System;

namespace CardGame
{
    public static class Helper
    {
        public static bool IsNameValid(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < 3)
            {
                throw new System.ArgumentException("Invalid name");
            }
            return true;
        }
    }
    public class Card
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
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
