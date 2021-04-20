using System;
using System.Collections.Generic;

namespace Domino_Chirkin.Domain
{
    public class Deck
    {
        public readonly List<Stone> PassiveStones;

        public int Count => PassiveStones.Count;

        public Deck()
        {
            PassiveStones = new List<Stone>();
            for (var i = 0; i <= 6; i++)
                for (var j = i; j <= 6; j++)
                    PassiveStones.Add(new Stone(i, j));
        }

        public Stone GetStone()
        {
            var random = new Random();
            var number = random.Next(0, PassiveStones.Count);
            var stone = PassiveStones[number];
            PassiveStones.RemoveAt(number);
            return stone;
        }
    }
}
