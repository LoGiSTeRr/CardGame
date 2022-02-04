﻿using System.Collections.Generic;

namespace CardGame
{
    public static class ListExtensions
    {
        private static System.Random rng = new System.Random();
        public static void Shuffle<T>(this List<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];

            }
        }
    }
}