using System.Collections.Generic;

namespace CardGame
{
    public static class ListExtensions
    {
        private static System.Random rng = new System.Random();
        public static void Shuffle<T>(this List<T> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                int random = rng.Next(list.Count);
                (list[i], list[random]) = (list[random], list[i]); 
            }
        }
    }
}